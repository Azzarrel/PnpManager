﻿
using PnPManager.Client.Elements.Interfaces;
using System;
using System.Collections;

namespace PnPManager.Client.Elements
{
  /// <summary>
  /// A generic suggestion provider. 
  /// </summary>
  public class SuggestionProvider : ISuggestionProvider
  {


    #region Private Fields

    private readonly Func<string, IEnumerable> _method;

    #endregion Private Fields

    #region Public Constructors

    public SuggestionProvider(Func<string, IEnumerable> method)
    {
      if (method == null)
      {
        throw new ArgumentNullException("method");
      }
      _method = method;
    }

    #endregion Public Constructors

    #region Public Methods

    public IEnumerable GetSuggestions(string filter)
    {
      return _method(filter);
    }

    #endregion Public Methods

  }
}
