﻿/***************************************************************************************

   Toolkit for WPF

   Copyright (C) 2007-2023 Xceed Software Inc.

   This program is provided to you under the terms of the XCEED SOFTWARE, INC.
   COMMUNITY LICENSE AGREEMENT (for non-commercial use) as published at 
   https://github.com/xceedsoftware/wpftoolkit/blob/master/license.md  

   For more features, controls, and fast professional support,
   pick up the Plus Edition at https://xceed.com/xceed-toolkit-plus-for-wpf/

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  *************************************************************************************/
using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.LiveExplorer.Samples.Zoombox.Converters
{
  public class PointConverter : SimpleConverter
  {
    protected override object Convert( object value )
    {
      return PointConverter.ConvertPoint( ( Point )value );
    }

    public static string ConvertPoint( Point point )
    {
      return string.Format( "{0},{1}",
        Math.Round( point.X ), Math.Round( point.Y ) );
    }
  }
}
