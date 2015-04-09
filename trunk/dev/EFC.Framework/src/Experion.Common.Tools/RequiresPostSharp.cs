// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="RequiresPostSharp.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="RequiresPostSharp.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------
#if !POSTSHARP
#error PostSharp is not introduced in the build process. If NuGet just restored the PostSharp package, you need to rebuild the solution.
#endif