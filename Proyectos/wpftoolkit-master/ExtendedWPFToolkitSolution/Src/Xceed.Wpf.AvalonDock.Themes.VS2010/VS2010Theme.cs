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

namespace Xceed.Wpf.AvalonDock.Themes
{
  public class VS2010Theme : Theme
  {
    public override Uri GetResourceUri()
    {
      string assemblyName = "Xceed.Wpf.AvalonDock.Themes.VS2010";

#if NETCORE
        assemblyName += ".NETCore";
#elif NET5
        assemblyName += ".NET5";
#endif

      return new Uri(
                "/" + assemblyName + ";component/Theme.xaml",
                UriKind.Relative );
    }
  }
}
