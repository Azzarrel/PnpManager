﻿using PnPManager.Client.Interfaces.Main.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnPManager.Client.Essentials
{
  public class ModuleBase : NotifyBase
  {

    public int ID
    {
      get { return Get<int>(); }
      set { Set(value); }
    }

    public string IconPath
    {
      get { return Get<string>(); }
      set { Set(value); }
    }

    public string Name
    {
      get { return Get<string>(); }
      set { Set(value); }
    }

    public List<IToolBarButton> ToolBar
    {
      get { return Get<List<IToolBarButton>>(); }
      set { Set(value); }
    }

    
  }
}
