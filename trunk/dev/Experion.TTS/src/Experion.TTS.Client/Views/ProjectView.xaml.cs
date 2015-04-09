using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Experion.TTS.Client.Views
{
    using Experion.TTS.Client.ViewModels;

    using Infragistics.Windows.DataPresenter.Events;

    /// <summary>
    /// Interaction logic for AddProject.xaml
    /// </summary>
    public partial class ProjectView : UserControl
    {
        public ProjectView()
        {
            InitializeComponent();
        }

        private void DataPresenterBase_OnSelectedItemsChanged(object sender, SelectedItemsChangedEventArgs e)
        {
        }
    }
}
