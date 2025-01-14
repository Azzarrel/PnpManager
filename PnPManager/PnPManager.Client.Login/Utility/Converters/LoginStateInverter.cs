﻿using PnPManager.Client.Login.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PnPManager.Client.Login.Utility.Converters
{
  public class LoginStateInverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if(value is LoginState state)
      {
        if(state == LoginState.Register)
          return LoginState.Login;
      }
      return LoginState.Register;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
