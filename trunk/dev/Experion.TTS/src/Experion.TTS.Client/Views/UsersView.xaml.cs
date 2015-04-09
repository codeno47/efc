
namespace Experion.TTS.Client.Views
{
    using Infragistics.Windows.DataPresenter.Events;
    using System.Windows.Controls;

    /// <summary>
    /// Description for UsersView.
    /// </summary>
    public partial class UsersView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the UsersView class.
        /// </summary>
        public UsersView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when [user selection changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectedItemsChangedEventArgs"/> instance containing the event data.</param>
        private void OnUserSelectionChanged(object sender, SelectedItemsChangedEventArgs e)
        {

        }
    }
}