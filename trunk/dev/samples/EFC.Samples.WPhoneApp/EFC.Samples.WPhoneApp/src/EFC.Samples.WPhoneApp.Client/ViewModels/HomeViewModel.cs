using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Samples.WPhone.Base;
using GalaSoft.MvvmLight;
using Microsoft.Practices.Unity;

namespace EFC.Samples.WPhone.ViewModels
{
    public class HomeViewModel:ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public HomeViewModel(IUnityContainer container) : base(container)
        {

        }
    }
}
