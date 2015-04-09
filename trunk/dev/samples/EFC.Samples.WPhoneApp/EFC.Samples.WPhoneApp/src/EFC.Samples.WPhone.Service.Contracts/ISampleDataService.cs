using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using EFC.Samples.WPhone.Service.Contracts.Dtos;

namespace EFC.Samples.WPhone.Service.Contracts
{
    public interface ISampleDataService
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserDto> GetAllUsers();
    }
}
