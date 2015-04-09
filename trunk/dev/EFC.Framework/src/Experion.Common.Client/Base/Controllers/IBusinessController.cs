// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="IBusinessController.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="IBusinessController.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;
using EFC.Components.Unity;

namespace EFC.Client.Common.Base.Controllers
{
    public interface IBusinessController : IDisposable
    {
        UnityContainerManager Unity { get; }
    }
}