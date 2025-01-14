﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace PnPManager.Client.Core.API
{
  public static class AssemblyResolver
  {



    private static string m_ModulePath;

    #region AssemblyResolve 


    public static void AssemblyResolve(string exePath)
    {
      try
      {

        List<string> references = new List<string>();
        //Add all references to the project
        references.AddRange(Directory.GetFiles(Path.Combine(exePath, "ref"), "*.dll"));
        references.AddRange(Directory.GetFiles(Path.Combine(exePath, "lib"), "*.dll"));
        m_ModulePath = (Path.Combine(exePath, "modules"));
        if(Directory.Exists(m_ModulePath))
        {
          foreach(string folder in Directory.GetDirectories(m_ModulePath))
          {
            string path = Path.Combine(m_ModulePath, folder);

            references.AddRange(Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories));

          }
        }

        AppDomain.CurrentDomain.AssemblyResolve += (obj, arg) =>
        {
          var name = $"{new AssemblyName(arg.Name).Name}.dll";

          //If for whatever reason an AssemblyResolve event for an already loaded assembly fires, return loaded assembly. 
          var loaded = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName.EndsWith(name));
          if(loaded != null)
            return loaded;

          #if DEBUG
          //DataSetVisualizer causes errors in .Net Core when subscribed to the AsseblyResolve event in debug, which are being handeled here.
          if(arg.Name.StartsWith("DataSetVisualizer"))
            return null;
          #endif


          var assemblyFile = references.Where(x => x.EndsWith(name)).FirstOrDefault();
          if(assemblyFile != null)
            return Assembly.LoadFrom(assemblyFile);

          //Don't throw error on resources
          if(name.Contains("resources"))
          //Throw exception when an assembly failed to load
          throw new Exception($"'{name}' Not found");

          return null;
        };
      }
      catch { }
    }
  }
  
  #endregion AssemblyResolve

}
