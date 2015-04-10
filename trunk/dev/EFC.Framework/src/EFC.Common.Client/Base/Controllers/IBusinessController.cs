// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IBusinessController.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IBusinessController.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using EFC.Components.Unity;

namespace EFC.Client.Common.Base.Controllers
{
    public interface IBusinessController : IDisposable
    {
        UnityContainerManager Unity { get; }
    }
}