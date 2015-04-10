// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="RequiresPostSharp.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="RequiresPostSharp.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
#if !POSTSHARP
#error PostSharp is not introduced in the build process. If NuGet just restored the PostSharp package, you need to rebuild the solution.
#endif