using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using EFC.Samples.WPhone.BusinessControllers;
using EFC.Samples.WPhone.Messages;
using EFC.Samples.WPhone.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.Unity;
using ViewModel = EFC.Samples.WPhone.Base.ViewModel;

namespace EFC.Samples.WPhone.ViewModels
{
    /// <summary>
    /// LoginViewModel.
    /// </summary>
    public class LoginViewModel : ViewModel
    {
        /// <summary>
        /// The model
        /// </summary>
        private LoginModel model;

        /// <summary>
        /// Gets or sets the login button command.
        /// </summary>
        /// <value>
        /// The login button command.
        /// </value>
        public ICommand LoginButtonCommand { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public LoginModel Model
        {
            get { return model; }
            set
            {
                model = value;
                RaisePropertyChanged("Model");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public LoginViewModel(IUnityContainer container)
            : base(container)
        {
            Model = new LoginModel();
            InitilizeCommands();
        }

        /// <summary>
        /// Initilizes the commands.
        /// </summary>
        private void InitilizeCommands()
        {
            LoginButtonCommand = new RelayCommand(LoginButtonCommandHandler);
        }

        /// <summary>
        /// Logins the button command handler.
        /// </summary>
        private void LoginButtonCommandHandler()
        {
            var controller = Unity.Resolve<SampleController>();
            if (controller.IsValidUserData(Model.Username, Model.Password))
            {
                //MessageBox.Show("Loging success");
                Messenger.Default.Send(new NavigateToPageMessage { PageName = "Home" });
            }
        }
    }
}
