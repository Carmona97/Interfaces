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
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls
{
  public class LayoutDocumentTabItem : Control
  {
    #region Members

    private static double MinDragBuffer = 5d;
    private static double MaxDragBuffer = 50d;

    private List<Rect> _otherTabsScreenArea = null;
    private List<TabItem> _otherTabs = null;
    private Rect _parentDocumentTabPanelScreenArea;
    private Panel _parentTabPanel;
    private bool _isMouseDown = false;
    private Point _mouseDownPoint;
    private double _mouseLastChangePositionX;
    private double _dragBuffer = MinDragBuffer;

    #endregion

    #region Contructors

    static LayoutDocumentTabItem()
    {
      DefaultStyleKeyProperty.OverrideMetadata( typeof( LayoutDocumentTabItem ), new FrameworkPropertyMetadata( typeof( LayoutDocumentTabItem ) ) );
    }

    public LayoutDocumentTabItem()
    {
    }

    #endregion

    #region Properties

    #region Model

    /// <summary>
    /// Model Dependency Property
    /// </summary>
    public static readonly DependencyProperty ModelProperty = DependencyProperty.Register( "Model", typeof( LayoutContent ), typeof( LayoutDocumentTabItem ),
            new FrameworkPropertyMetadata( ( LayoutContent )null, new PropertyChangedCallback( OnModelChanged ) ) );

    /// <summary>
    /// Gets or sets the Model property.  This dependency property 
    /// indicates the layout content model attached to the tab item.
    /// </summary>
    public LayoutContent Model
    {
      get
      {
        return ( LayoutContent )GetValue( ModelProperty );
      }
      set
      {
        SetValue( ModelProperty, value );
      }
    }

    /// <summary>
    /// Handles changes to the Model property.
    /// </summary>
    private static void OnModelChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
    {
      ( ( LayoutDocumentTabItem )d ).OnModelChanged( e );
    }


    /// <summary>
    /// Provides derived classes an opportunity to handle changes to the Model property.
    /// </summary>
    protected virtual void OnModelChanged( DependencyPropertyChangedEventArgs e )
    {
      if( ( this.Model != null ) && ( this.Model.Root != null ) && ( this.Model.Root.Manager != null ) )
        this.SetLayoutItem( Model.Root.Manager.GetLayoutItemFromModel( Model ) );
      else
        this.SetLayoutItem( null );
    }

    #endregion

    #region LayoutItem

    /// <summary>
    /// LayoutItem Read-Only Dependency Property
    /// </summary>
    private static readonly DependencyPropertyKey LayoutItemPropertyKey = DependencyProperty.RegisterReadOnly( "LayoutItem", typeof( LayoutItem ), typeof( LayoutDocumentTabItem ),
            new FrameworkPropertyMetadata( ( LayoutItem )null ) );

    public static readonly DependencyProperty LayoutItemProperty = LayoutItemPropertyKey.DependencyProperty;

    /// <summary>
    /// Gets the LayoutItem property.  This dependency property 
    /// indicates the LayoutItem attached to this tag item.
    /// </summary>
    public LayoutItem LayoutItem
    {
      get
      {
        return ( LayoutItem )GetValue( LayoutItemProperty );
      }
    }

    /// <summary>
    /// Provides a secure method for setting the LayoutItem property.  
    /// This dependency property indicates the LayoutItem attached to this tag item.
    /// </summary>
    /// <param name="value">The new value for the property.</param>
    protected void SetLayoutItem( LayoutItem value )
    {
      SetValue( LayoutItemPropertyKey, value );
    }

    #endregion

    #endregion

    #region Overrides

    protected override void OnMouseLeftButtonDown( System.Windows.Input.MouseButtonEventArgs e )
    {
      base.OnMouseLeftButtonDown( e );

      Model.IsActive = true;

      var layoutDocument = Model as LayoutDocument;
      if( ( layoutDocument != null ) && !layoutDocument.CanMove )
        return;

      if( e.ClickCount == 1 )
      {
        _mouseDownPoint = e.GetPosition( this );
        _isMouseDown = true;
      }
    }

    protected override void OnMouseMove( System.Windows.Input.MouseEventArgs e )
    {
      base.OnMouseMove( e );

      var ptMouseMove = e.GetPosition( this );

      if( _isMouseDown )
      {
        if( Math.Abs( ptMouseMove.X - _mouseDownPoint.X ) > SystemParameters.MinimumHorizontalDragDistance ||
            Math.Abs( ptMouseMove.Y - _mouseDownPoint.Y ) > SystemParameters.MinimumVerticalDragDistance )
        {
          this.UpdateDragDetails();
          this.CaptureMouse();
          _isMouseDown = false;
        }
      }

      if( this.IsMouseCaptured )
      {
        var mousePosInScreenCoord = this.PointToScreenDPI( ptMouseMove );

        if( !_parentDocumentTabPanelScreenArea.Contains( mousePosInScreenCoord ) )
        {
          this.StartDraggingFloatingWindowForContent();
        }
        else
        {
          int indexOfTabItemWithMouseOver = _otherTabsScreenArea.FindIndex( r => r.Contains( mousePosInScreenCoord ) );
          if( indexOfTabItemWithMouseOver >= 0 )
          {
            var targetModel = _otherTabs[ indexOfTabItemWithMouseOver ].Content as LayoutContent;
            var container = this.Model.Parent as ILayoutContainer;
            var containerPane = this.Model.Parent as ILayoutPane;
            var currentTabScreenArea = this.FindLogicalAncestor<TabItem>().GetScreenArea();

            // Inside current TabItem, do not care about _mouseLastChangePosition for next change position.
            if( targetModel == this.Model )
            {
              _mouseLastChangePositionX = currentTabScreenArea.Left + ( currentTabScreenArea.Width / 2 );
            }

            if( ( containerPane is LayoutDocumentPane ) && !( ( LayoutDocumentPane )containerPane ).CanRepositionItems )
              return;
            if( ( containerPane.Parent != null ) && ( containerPane.Parent is LayoutDocumentPaneGroup ) && !( ( LayoutDocumentPaneGroup )containerPane.Parent ).CanRepositionItems )
              return;

            var childrenList = container.Children.ToList();
            var currentIndex = childrenList.IndexOf( this.Model );
            var newIndex = childrenList.IndexOf( targetModel );

            if( currentIndex != newIndex )
            {
              // Moving left when cursor leave tabItem or moving left past last change position.
              // Or, moving right cursor leave tabItem or moving right past last change position.
              if( ( ( mousePosInScreenCoord.X < currentTabScreenArea.Left ) && ( mousePosInScreenCoord.X < _mouseLastChangePositionX ) )
                || ( ( mousePosInScreenCoord.X > ( currentTabScreenArea.Left + currentTabScreenArea.Width ) ) && ( mousePosInScreenCoord.X > _mouseLastChangePositionX ) ) )
              {
                containerPane.MoveChild( currentIndex, newIndex );
                _dragBuffer = MaxDragBuffer;
                this.Model.IsActive = true;
                _parentTabPanel.UpdateLayout();
                this.UpdateDragDetails();
                _mouseLastChangePositionX = mousePosInScreenCoord.X;
              }
            }
          }
        }
      }
    }

    protected override void OnMouseLeftButtonUp( System.Windows.Input.MouseButtonEventArgs e )
    {
      if( IsMouseCaptured )
      {
        this.ReleaseMouseCapture();
      }
      _isMouseDown = false;
      _dragBuffer = MinDragBuffer;

      base.OnMouseLeftButtonUp( e );
    }

    protected override void OnMouseLeave( System.Windows.Input.MouseEventArgs e )
    {
      base.OnMouseLeave( e );
      _isMouseDown = false;
    }

    protected override void OnMouseEnter( MouseEventArgs e )
    {
      base.OnMouseEnter( e );
      _isMouseDown = false;
    }

    protected override void OnMouseDown( MouseButtonEventArgs e )
    {
      if( e.ChangedButton == MouseButton.Middle )
      {
        if( LayoutItem.CloseCommand.CanExecute( null ) )
          LayoutItem.CloseCommand.Execute( null );
      }

      base.OnMouseDown( e );
    }

    #endregion

    #region Private Methods

    private void UpdateDragDetails()
    {
      _parentTabPanel = this.FindLogicalAncestor<DocumentPaneTabPanel>();

      if( _parentTabPanel == null )
      {
        _parentTabPanel = this.GetParentPanel();
      }

      if( _parentTabPanel == null )
        return;

      _parentDocumentTabPanelScreenArea = _parentTabPanel.GetScreenArea();
      _parentDocumentTabPanelScreenArea.Inflate( 0, _dragBuffer );
      _otherTabs = _parentTabPanel.Children.Cast<TabItem>().Where( ch => ch.Visibility != System.Windows.Visibility.Collapsed ).ToList();
      var currentTabScreenArea = this.FindLogicalAncestor<TabItem>().GetScreenArea();
      _otherTabsScreenArea = _otherTabs.Select( ti =>
      {
        var screenArea = ti.GetScreenArea();
        var rect = new Rect( screenArea.Left, screenArea.Top, screenArea.Width, screenArea.Height );
        rect.Inflate( 0, _dragBuffer );
        return rect;
      } ).ToList();
    }

    private Panel GetParentPanel()
    {
      var parents = this.FindLogicalAncestorsAndSelf();

      foreach( var parent in parents )
      {
        var panel = parent as Panel;
        if( panel != null && ( panel.Children[ 0 ] as TabItem ) != null )
        {
          return panel;
        }
      }
      return null;
    }

    private void StartDraggingFloatingWindowForContent()
    {
      this.ReleaseMouseCapture();

      if( this.Model is LayoutAnchorable )
      {
        ( ( LayoutAnchorable )this.Model ).ResetCanCloseInternal();
      }
      var manager = this.Model.Root.Manager;
      manager.StartDraggingFloatingWindowForContent( this.Model );
    }

    #endregion
  }
}
