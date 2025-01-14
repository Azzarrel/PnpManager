﻿using System.Windows;

namespace PnPManager.Client.Structure.WPF.Utility
{
  public class BindingProxy : Freezable
  {
    protected override Freezable CreateInstanceCore()
    {
      return new BindingProxy();
    }

    public static readonly DependencyProperty DataProerty = DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));

    public object Data
    {
      get { return GetValue(DataProerty); }
      set { SetValue(DataProerty, value); }
    }

  }
}
