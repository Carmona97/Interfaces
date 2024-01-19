﻿/*************************************************************************************
   
   Toolkit for WPF

   Copyright (C) 2007-2022 Xceed Software Inc.

   This program is provided to you under the terms of the XCEED SOFTWARE, INC.
   COMMUNITY LICENSE AGREEMENT (for non-commercial use) as published at 
   https://github.com/xceedsoftware/wpftoolkit/blob/master/license.md 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout
{
  [ContentProperty( "Content" )]
  [Serializable]
  public abstract class LayoutContent : LayoutElement, IXmlSerializable, ILayoutElementForFloatingWindow, IComparable<LayoutContent>, ILayoutPreviousContainer, ILayoutInitialContainer
  {
    #region Constructors

    internal LayoutContent()
    {
    }

    #endregion

    #region Properties

    #region Title

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register( "Title", typeof( string ), typeof( LayoutContent ), new UIPropertyMetadata( null, OnTitlePropertyChanged, CoerceTitleValue ) );

    public string Title
    {
      get
      {
        return ( string )GetValue( TitleProperty );
      }
      set
      {
        SetValue( TitleProperty, value );
      }
    }

    private static object CoerceTitleValue( DependencyObject obj, object value )
    {
      var lc = ( LayoutContent )obj;
      if( ( ( string )value ) != lc.Title )
      {
        lc.RaisePropertyChanging( LayoutContent.TitleProperty.Name );
      }
      return value;
    }

    private static void OnTitlePropertyChanged( DependencyObject obj, DependencyPropertyChangedEventArgs args )
    {
      ( ( LayoutContent )obj ).RaisePropertyChanged( LayoutContent.TitleProperty.Name );
    }

    #endregion //Title

    #region Content
    [NonSerialized]
    private object _content = null;
    [XmlIgnore]
    public object Content
    {
      get
      {
        return _content;
      }
      set
      {
        if( _content != value )
        {
          RaisePropertyChanging( "Content" );
          _content = value;
          RaisePropertyChanged( "Content" );

          if( this.ContentId == null )
          {
            var contentAsControl = _content as FrameworkElement;
            if( contentAsControl != null && !string.IsNullOrWhiteSpace( contentAsControl.Name ) )
            {
              this.SetCurrentValue( LayoutContent.ContentIdProperty, contentAsControl.Name );
            }
          }
        }
      }
    }

    #endregion

    #region ContentId

    public static readonly DependencyProperty ContentIdProperty = DependencyProperty.Register( "ContentId", typeof( string ), typeof( LayoutContent ), new UIPropertyMetadata( null, OnContentIdPropertyChanged ) );

    public string ContentId
    {
      get
      {
        return ( string )GetValue( ContentIdProperty );
      }
      set
      {
        SetValue( ContentIdProperty, value );
      }
    }

    private static void OnContentIdPropertyChanged( DependencyObject obj, DependencyPropertyChangedEventArgs args )
    {
      var layoutContent = obj as LayoutContent;
      if( layoutContent != null )
      {
        layoutContent.OnContentIdPropertyChanged( ( string )args.OldValue, ( string )args.NewValue );
      }
    }

    private void OnContentIdPropertyChanged( string oldValue, string newValue )
    {
      if( oldValue != newValue )
      {
        this.RaisePropertyChanged( "ContentId" );
      }
    }

    #endregion //ContentId

    #region IsSelected

    private bool _isSelected = false;
    public bool IsSelected
    {
      get
      {
        return _isSelected;
      }
      set
      {
        if( _isSelected != value )
        {
          bool oldValue = _isSelected;
          RaisePropertyChanging( "IsSelected" );
          _isSelected = value;
          var parentSelector = ( Parent as ILayoutContentSelector );
          if( parentSelector != null )
            parentSelector.SelectedContentIndex = _isSelected ? parentSelector.IndexOf( this ) : -1;
          OnIsSelectedChanged( oldValue, value );
          RaisePropertyChanged( "IsSelected" );
        }
      }
    }

    /// <summary>
    /// Provides derived classes an opportunity to handle changes to the IsSelected property.
    /// </summary>
    protected virtual void OnIsSelectedChanged( bool oldValue, bool newValue )
    {
      this.UpdateContainedFloatingWindowTaskbarTitle( newValue );

      if( IsSelectedChanged != null )
        IsSelectedChanged( this, EventArgs.Empty );
    }

    public event EventHandler IsSelectedChanged;

    #endregion

    #region IsActive

    [field: NonSerialized]
    private bool _isActive = false;
    [XmlIgnore]
    public bool IsActive
    {
      get
      {
        return _isActive;
      }
      set
      {
        if( _isActive != value )
        {
          RaisePropertyChanging( "IsActive" );
          bool oldValue = _isActive;

          _isActive = value;

          var root = Root;
          if( root != null && _isActive )
            root.ActiveContent = this;

          if( _isActive )
            IsSelected = true;

          OnIsActiveChanged( oldValue, value );
          RaisePropertyChanged( "IsActive" );
        }
      }
    }

    /// <summary>
    /// Provides derived classes an opportunity to handle changes to the IsActive property.
    /// </summary>
    protected virtual void OnIsActiveChanged( bool oldValue, bool newValue )
    {
      if( newValue )
        LastActivationTimeStamp = DateTime.Now;

      if( IsActiveChanged != null )
        IsActiveChanged( this, EventArgs.Empty );
    }

    public event EventHandler IsActiveChanged;

    #endregion

    #region IsLastFocusedDocument

    private bool _isLastFocusedDocument = false;
    public bool IsLastFocusedDocument
    {
      get
      {
        return _isLastFocusedDocument;
      }
      internal set
      {
        if( _isLastFocusedDocument != value )
        {
          RaisePropertyChanging( "IsLastFocusedDocument" );
          _isLastFocusedDocument = value;
          RaisePropertyChanged( "IsLastFocusedDocument" );
        }
      }
    }

    #endregion

    #region PreviousContainer

    [field: NonSerialized]
    private ILayoutContainer _previousContainer = null;

    [XmlIgnore]
    ILayoutContainer ILayoutPreviousContainer.PreviousContainer
    {
      get
      {
        return _previousContainer;
      }
      set
      {
        if( _previousContainer != value )
        {
          _previousContainer = value;
          RaisePropertyChanged( "PreviousContainer" );

          var paneSerializable = _previousContainer as ILayoutPaneSerializable;
          if( paneSerializable != null &&
              paneSerializable.Id == null )
            paneSerializable.Id = Guid.NewGuid().ToString();
        }
      }
    }

    public ILayoutContainer PreviousContainer
    {
      get
      {
        return ( ( ILayoutPreviousContainer )this ).PreviousContainer;
      }
      protected set
      {
        ( ( ILayoutPreviousContainer )this ).PreviousContainer = value;
      }
    }

    [XmlIgnore]
    string ILayoutPreviousContainer.PreviousContainerId
    {
      get;
      set;
    }

    public string PreviousContainerId
    {
      get
      {
        return ( ( ILayoutPreviousContainer )this ).PreviousContainerId;
      }
      protected set
      {
        ( ( ILayoutPreviousContainer )this ).PreviousContainerId = value;
      }
    }

    #endregion

    #region InitialContainer

    [field: NonSerialized]
    private ILayoutContainer _initialContainer = null;

    [XmlIgnore]
    ILayoutContainer ILayoutInitialContainer.InitialContainer
    {
      get
      {
        return _initialContainer;
      }
      set
      {
        if( _initialContainer != value )
        {
          _initialContainer = value;
          RaisePropertyChanged( "InitialContainer" );

          var paneSerializable = _initialContainer as ILayoutPaneSerializable;
          if( paneSerializable != null &&
              paneSerializable.Id == null )
            paneSerializable.Id = Guid.NewGuid().ToString();
        }
      }
    }

    internal ILayoutContainer InitialContainer
    {
      get
      {
        return ( ( ILayoutInitialContainer )this ).InitialContainer;
      }
      set
      {
        ( ( ILayoutInitialContainer )this ).InitialContainer = value;
      }
    }

    [XmlIgnore]
    string ILayoutInitialContainer.InitialContainerId
    {
      get;
      set;
    }

    internal string InitialContainerId
    {
      get
      {
        return ( ( ILayoutInitialContainer )this ).InitialContainerId;
      }
      set
      {
        ( ( ILayoutInitialContainer )this ).InitialContainerId = value;
      }
    }

    #endregion

    #region PreviousContainerIndex
    [field: NonSerialized]
    private int _previousContainerIndex = -1;
    [XmlIgnore]
    public int PreviousContainerIndex
    {
      get
      {
        return _previousContainerIndex;
      }
      set
      {
        if( _previousContainerIndex != value )
        {
          _previousContainerIndex = value;
          RaisePropertyChanged( "PreviousContainerIndex" );
        }
      }
    }

    #endregion

    #region InitialContainerIndex
    [field: NonSerialized]
    private int _initialContainerIndex = -1;
    [XmlIgnore]
    internal int InitialContainerIndex
    {
      get
      {
        return _initialContainerIndex;
      }
      set
      {
        if( _initialContainerIndex != value )
        {
          _initialContainerIndex = value;
          RaisePropertyChanged( "InitialContainerIndex" );
        }
      }
    }

    #endregion

    #region LastActivationTimeStamp

    private DateTime? _lastActivationTimeStamp = null;
    public DateTime? LastActivationTimeStamp
    {
      get
      {
        return _lastActivationTimeStamp;
      }
      set
      {
        if( _lastActivationTimeStamp != value )
        {
          _lastActivationTimeStamp = value;
          RaisePropertyChanged( "LastActivationTimeStamp" );
        }
      }
    }

    #endregion

    #region FloatingWidth

    private double _floatingWidth = 0.0;
    public double FloatingWidth
    {
      get
      {
        return _floatingWidth;
      }
      set
      {
        if( _floatingWidth != value )
        {
          RaisePropertyChanging( "FloatingWidth" );
          _floatingWidth = value;
          RaisePropertyChanged( "FloatingWidth" );
        }
      }
    }

    #endregion

    #region FloatingHeight

    private double _floatingHeight = 0.0;
    public double FloatingHeight
    {
      get
      {
        return _floatingHeight;
      }
      set
      {
        if( _floatingHeight != value )
        {
          RaisePropertyChanging( "FloatingHeight" );
          _floatingHeight = value;
          RaisePropertyChanged( "FloatingHeight" );
        }
      }
    }

    #endregion

    #region FloatingLeft

    private double _floatingLeft = 0.0;
    public double FloatingLeft
    {
      get
      {
        return _floatingLeft;
      }
      set
      {
        if( _floatingLeft != value )
        {
          RaisePropertyChanging( "FloatingLeft" );
          _floatingLeft = value;
          RaisePropertyChanged( "FloatingLeft" );
        }
      }
    }

    #endregion

    #region FloatingTop

    private double _floatingTop = 0.0;
    public double FloatingTop
    {
      get
      {
        return _floatingTop;
      }
      set
      {
        if( _floatingTop != value )
        {
          RaisePropertyChanging( "FloatingTop" );
          _floatingTop = value;
          RaisePropertyChanged( "FloatingTop" );
        }
      }
    }

    #endregion

    #region IsMaximized

    private bool _isMaximized = false;
    public bool IsMaximized
    {
      get
      {
        return _isMaximized;
      }
      set
      {
        if( _isMaximized != value )
        {
          RaisePropertyChanging( "IsMaximized" );
          _isMaximized = value;
          RaisePropertyChanged( "IsMaximized" );
        }
      }
    }

    #endregion

    #region ToolTip

    private object _toolTip = null;
    public object ToolTip
    {
      get
      {
        return _toolTip;
      }
      set
      {
        if( _toolTip != value )
        {
          _toolTip = value;
          RaisePropertyChanged( "ToolTip" );
        }
      }
    }

    #endregion

    #region IsFloating

    private bool _isFloating = false;

    public bool IsFloating
    {
      get
      {
        return _isFloating;
      }
      internal set
      {
        if( _isFloating != value )
        {
          _isFloating = value;
          RaisePropertyChanged( "IsFloating" );
        }
      }
    }

    #endregion






    #region IconSource

    private ImageSource _iconSource = null;
    public ImageSource IconSource
    {
      get
      {
        return _iconSource;
      }
      set
      {
        if( _iconSource != value )
        {
          _iconSource = value;
          RaisePropertyChanged( "IconSource" );
        }
      }
    }

    #endregion

    #region CanClose

    internal bool _canClose = true;
    public bool CanClose
    {
      get
      {
        return _canClose;
      }
      set
      {
        if( _canClose != value )
        {
          _canClose = value;
          RaisePropertyChanged( "CanClose" );
        }
      }
    }

    #endregion

    #region CanFloat

    private bool _canFloat = true;
    public bool CanFloat
    {
      get
      {
        return _canFloat;
      }
      set
      {
        if( _canFloat != value )
        {
          _canFloat = value;
          RaisePropertyChanged( "CanFloat" );
        }
      }
    }

    #endregion

    #region IsEnabled

    private bool _isEnabled = true;
    public bool IsEnabled
    {
      get
      {
        return _isEnabled;
      }
      set
      {
        if( _isEnabled != value )
        {
          _isEnabled = value;
          RaisePropertyChanged( "IsEnabled" );
        }
      }
    }

    #endregion







    #endregion

    #region Overrides

    protected override void OnParentChanging( ILayoutContainer oldValue, ILayoutContainer newValue )
    {
      var root = Root;

      if( oldValue != null )
        IsSelected = false;

      //if (root != null && _isActive && newValue == null)
      //    root.ActiveContent = null;

      base.OnParentChanging( oldValue, newValue );
    }

    protected override void OnParentChanged( ILayoutContainer oldValue, ILayoutContainer newValue )
    {
      if( IsSelected && Parent != null && Parent is ILayoutContentSelector )
      {
        var parentSelector = ( Parent as ILayoutContentSelector );
        parentSelector.SelectedContentIndex = parentSelector.IndexOf( this );
      }

      //var root = Root;
      //if (root != null && _isActive)
      //    root.ActiveContent = this;

      base.OnParentChanged( oldValue, newValue );
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Close the content
    /// </summary>
    /// <remarks>Please note that usually the anchorable is only hidden (not closed). By default when user click the X button it only hides the content.</remarks>
    public abstract void Close();

    public System.Xml.Schema.XmlSchema GetSchema()
    {
      return null;
    }

    public virtual void ReadXml( System.Xml.XmlReader reader )
    {
      if( reader.MoveToAttribute( "Title" ) )
        Title = reader.Value;
      //if (reader.MoveToAttribute("IconSource"))
      //    IconSource = new Uri(reader.Value, UriKind.RelativeOrAbsolute);

      if( reader.MoveToAttribute( "IsSelected" ) )
        IsSelected = bool.Parse( reader.Value );
      if( reader.MoveToAttribute( "ContentId" ) )
        ContentId = reader.Value;
      if( reader.MoveToAttribute( "IsLastFocusedDocument" ) )
        IsLastFocusedDocument = bool.Parse( reader.Value );
      if( reader.MoveToAttribute( "PreviousContainerId" ) )
        PreviousContainerId = reader.Value;
      if( reader.MoveToAttribute( "PreviousContainerIndex" ) )
        PreviousContainerIndex = int.Parse( reader.Value );
      if( reader.MoveToAttribute( "InitialContainerId" ) )
        InitialContainerId = reader.Value;
      if( reader.MoveToAttribute( "InitialContainerIndex" ) )
        InitialContainerIndex = int.Parse( reader.Value );

      if( reader.MoveToAttribute( "FloatingLeft" ) )
        FloatingLeft = double.Parse( reader.Value, CultureInfo.InvariantCulture );
      if( reader.MoveToAttribute( "FloatingTop" ) )
        FloatingTop = double.Parse( reader.Value, CultureInfo.InvariantCulture );
      if( reader.MoveToAttribute( "FloatingWidth" ) )
        FloatingWidth = double.Parse( reader.Value, CultureInfo.InvariantCulture );
      if( reader.MoveToAttribute( "FloatingHeight" ) )
        FloatingHeight = double.Parse( reader.Value, CultureInfo.InvariantCulture );
      if( reader.MoveToAttribute( "IsFloating" ) )
        IsFloating = bool.Parse( reader.Value );
      if( reader.MoveToAttribute( "IsMaximized" ) )
        IsMaximized = bool.Parse( reader.Value );
      if( reader.MoveToAttribute( "CanClose" ) )
        CanClose = bool.Parse( reader.Value );
      if( reader.MoveToAttribute( "CanFloat" ) )
        CanFloat = bool.Parse( reader.Value );
      if( reader.MoveToAttribute( "LastActivationTimeStamp" ) )
        LastActivationTimeStamp = DateTime.Parse( reader.Value, CultureInfo.InvariantCulture );

      reader.Read();
    }

    public virtual void WriteXml( System.Xml.XmlWriter writer )
    {
      if( !string.IsNullOrWhiteSpace( Title ) )
        writer.WriteAttributeString( "Title", Title );

      //if (IconSource != null)
      //    writer.WriteAttributeString("IconSource", IconSource.ToString());

      if( IsSelected )
        writer.WriteAttributeString( "IsSelected", IsSelected.ToString() );

      if( IsLastFocusedDocument )
        writer.WriteAttributeString( "IsLastFocusedDocument", IsLastFocusedDocument.ToString() );

      if( !string.IsNullOrWhiteSpace( ContentId ) )
        writer.WriteAttributeString( "ContentId", ContentId );


      if( ToolTip != null && ToolTip is string )
        if( !string.IsNullOrWhiteSpace( ( string )ToolTip ) )
          writer.WriteAttributeString( "ToolTip", ( string )ToolTip );

      if( FloatingLeft != 0.0 )
        writer.WriteAttributeString( "FloatingLeft", FloatingLeft.ToString( CultureInfo.InvariantCulture ) );
      if( FloatingTop != 0.0 )
        writer.WriteAttributeString( "FloatingTop", FloatingTop.ToString( CultureInfo.InvariantCulture ) );
      if( FloatingWidth != 0.0 )
        writer.WriteAttributeString( "FloatingWidth", FloatingWidth.ToString( CultureInfo.InvariantCulture ) );
      if( FloatingHeight != 0.0 )
        writer.WriteAttributeString( "FloatingHeight", FloatingHeight.ToString( CultureInfo.InvariantCulture ) );
      if( IsFloating )
        writer.WriteAttributeString( "IsFloating", IsFloating.ToString() );
      if( IsMaximized )
        writer.WriteAttributeString( "IsMaximized", IsMaximized.ToString() );
      // Always serialize CanClose because the default value is different for LayoutAnchorable vs LayoutDocument.
      writer.WriteAttributeString( "CanClose", CanClose.ToString() );
      if( !CanFloat )
        writer.WriteAttributeString( "CanFloat", CanFloat.ToString() );


      if( LastActivationTimeStamp != null )
        writer.WriteAttributeString( "LastActivationTimeStamp", LastActivationTimeStamp.Value.ToString( CultureInfo.InvariantCulture ) );

      if( _previousContainer != null )
      {
        var paneSerializable = _previousContainer as ILayoutPaneSerializable;
        if( paneSerializable != null )
        {
          writer.WriteAttributeString( "PreviousContainerId", paneSerializable.Id );
          writer.WriteAttributeString( "PreviousContainerIndex", _previousContainerIndex.ToString() );
        }
      }
      if( _initialContainer != null )
      {
        var paneSerializable = _initialContainer as ILayoutPaneSerializable;
        if( paneSerializable != null )
        {
          writer.WriteAttributeString( "InitialContainerId", paneSerializable.Id );
          writer.WriteAttributeString( "InitialContainerIndex", _initialContainerIndex.ToString() );
        }
      }

    }

    public int CompareTo( LayoutContent other )
    {
      var contentAsComparable = Content as IComparable;
      if( contentAsComparable != null )
      {
        return contentAsComparable.CompareTo( other.Content );
      }

      return string.Compare( Title, other.Title );
    }

    /// <summary>
    /// Float the content in a popup window
    /// </summary>
    public void Float()
    {
      if( PreviousContainer != null &&
          PreviousContainer.FindParent<LayoutFloatingWindow>() != null )
      {

        var currentContainer = Parent as ILayoutPane;
        var currentContainerIndex = ( currentContainer as ILayoutGroup ).IndexOfChild( this );
        var previousContainerAsLayoutGroup = PreviousContainer as ILayoutGroup;

        if( PreviousContainerIndex < previousContainerAsLayoutGroup.ChildrenCount )
          previousContainerAsLayoutGroup.InsertChildAt( PreviousContainerIndex, this );
        else
          previousContainerAsLayoutGroup.InsertChildAt( previousContainerAsLayoutGroup.ChildrenCount, this );

        PreviousContainer = currentContainer;
        PreviousContainerIndex = currentContainerIndex;

        IsSelected = true;
        IsActive = true;
      }
      else
      {
        Root.Manager.StartDraggingFloatingWindowForContent( this, false );

        IsSelected = true;
        IsActive = true;
      }

      Root.CollectGarbage();
    }

    /// <summary>
    /// Dock the content as document
    /// </summary>
    public void DockAsDocument()
    {
      var root = Root as LayoutRoot;
      if( root == null )
        throw new InvalidOperationException();
      if( Parent is LayoutDocumentPane )
        return;

      if( this is LayoutAnchorable )
      {
        if( ( ( LayoutAnchorable )this ).CanClose )
        {
          ( ( LayoutAnchorable )this ).SetCanCloseInternal( true );
        }
      }

      if( PreviousContainer is LayoutDocumentPane )
      {
        Dock();
        return;
      }

      LayoutDocumentPane newParentPane;
      if( root.LastFocusedDocument != null )
      {
        newParentPane = root.LastFocusedDocument.Parent as LayoutDocumentPane;
      }
      else
      {
        newParentPane = root.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
      }

      if( newParentPane != null )
      {
        Root.Manager.RaisePreviewDockEvent( this );
        newParentPane.Children.Add( this );
        Root.Manager.RaiseDockedEvent( this );
      }
      else
      {
        Root.Manager.RaisePreviewDockEvent( this );
        var mainLayoutPanel = new LayoutPanel() { Orientation = Orientation.Horizontal };
        if( root.RootPanel != null )
        {
          mainLayoutPanel.Children.Add( root.RootPanel );
        }

        root.RootPanel = mainLayoutPanel;
        newParentPane = new LayoutDocumentPane() { };
        mainLayoutPanel.Children.Add( ( ILayoutPanelElement )newParentPane );

        newParentPane.Children.Add( this );
        Root.Manager.RaiseDockedEvent( this );
      }

      root.CollectGarbage();

      IsFloating = false;
      IsSelected = true;
      IsActive = true;
    }

    /// <summary>
    /// Re-dock the content to its previous container
    /// </summary>
    public void Dock()
    {
      Root.Manager.RaisePreviewDockEvent( this );

      if( PreviousContainer != null )
      {
        var currentContainer = Parent as ILayoutContainer;
        var currentContainerIndex = ( currentContainer is ILayoutGroup ) ? ( currentContainer as ILayoutGroup ).IndexOfChild( this ) : -1;
        var previousContainerAsLayoutGroup = PreviousContainer as ILayoutGroup;

        if( PreviousContainerIndex < previousContainerAsLayoutGroup.ChildrenCount )
          previousContainerAsLayoutGroup.InsertChildAt( PreviousContainerIndex, this );
        else
          previousContainerAsLayoutGroup.InsertChildAt( previousContainerAsLayoutGroup.ChildrenCount, this );

        if( currentContainerIndex > -1 )
        {
          PreviousContainer = currentContainer;
          PreviousContainerIndex = currentContainerIndex;
        }
        else
        {
          PreviousContainer = null;
          PreviousContainerIndex = 0;
        }

        IsSelected = true;
        IsActive = true;
      }
      else
      {
        InternalDock();
      }

      Root.Manager.RaiseDockedEvent( this );
      IsFloating = false;

      if( this.Root != null )
      {
        Root.CollectGarbage();
      }
    }






    #endregion

    #region Internal Methods

    /// <summary>
    /// Test if the content can be closed
    /// </summary>
    /// <returns></returns>
    internal bool TestCanClose()
    {
      CancelEventArgs args = new CancelEventArgs();

      OnClosing( args );

      if( args.Cancel )
        return false;

      return true;
    }

    internal void CloseInternal()
    {
      var root = Root;
      var parentAsContainer = Parent as ILayoutContainer;
      parentAsContainer.RemoveChild( this );
      if( root != null )
        root.CollectGarbage();

      OnClosed();
    }

    protected virtual void OnClosed()
    {
      if( Closed != null )
        Closed( this, EventArgs.Empty );
    }

    protected virtual void OnClosing( CancelEventArgs args )
    {
      if( Closing != null )
        Closing( this, args );
    }


    protected virtual void InternalDock()
    {
    }

    #endregion

    #region Private Methods

    private void UpdateContainedFloatingWindowTaskbarTitle( bool newValue )
    {
      if( !newValue ) // LayoutContent is being deselected
      {
        // Check if LayoutContent is inside a FloatingWindowControl
        // And set the correct title for Taskbar Title
        var root = Root;

        if( root != null )
        {
          var lfwc = root.Manager.FloatingWindows;
          var containedFloatingWindowControl = lfwc.FirstOrDefault( f => f.Model.Descendents().OfType<LayoutContent>().Where( l => l.ContentId == this.ContentId ).FirstOrDefault() != null );

          if( containedFloatingWindowControl != null )
          {
            var selectedLayoutContent = containedFloatingWindowControl.Model.Descendents().OfType<LayoutContent>().Where( l => l.IsSelected ).FirstOrDefault();

            if( selectedLayoutContent != null )
            {
              if( containedFloatingWindowControl.Title != selectedLayoutContent.Title )
              {
                containedFloatingWindowControl.Title = selectedLayoutContent.Title;
              }
            }
          }
        }
      }
    }

    #endregion // Private Methods

    #region Events

    /// <summary>
    /// Event fired when the content is closed (i.e. removed definitely from the layout)
    /// </summary>
    public event EventHandler Closed;

    /// <summary>
    /// Event fired when the content is about to be closed (i.e. removed definitely from the layout)
    /// </summary>
    /// <remarks>Please note that LayoutAnchorable also can be hidden. Usually user hide anchorables when click the 'X' button. To completely close 
    /// an anchorable the user should click the 'Close' menu item from the context menu. When an LayoutAnchorable is hidden its visibility changes to false and
    /// IsHidden property is set to true.
    /// Hanlde the Hiding event for the LayoutAnchorable to cancel the hide operation.</remarks>
    public event EventHandler<CancelEventArgs> Closing;


    #endregion
  }
}
