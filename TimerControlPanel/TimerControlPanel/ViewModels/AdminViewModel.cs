// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminViewModel.cs" company="Admin View Model">
//   Admin View Model
// </copyright>
// <summary>
//   Defines the AdminViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using TimerControlPanel.Connected_Services.TimerService;
using TimerControlPanel.Views;

namespace TimerControlPanel.ViewModels
{
    /// <summary>
    /// The admin view model.
    /// </summary>
    public class AdminViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the add department command.
        /// </summary>
        public RelayCommand AddDepartmentCommand { get; set; }

        /// <summary>
        /// Gets or sets the add project command.
        /// </summary>
        public RelayCommand AddProjectCommand { get; set; }

        /// <summary>
        /// Gets or sets the create new user command.
        /// </summary>
        public RelayCommand CreateNewUserCommand { get; set; }

        /// <summary>
        /// The client.
        /// </summary>
        private TimerServiceClient client;

        /// <summary>
        /// The dept name.
        /// </summary>
        private string deptName;

        /// <summary>
        /// The dept mail.
        /// </summary>
        private string deptMail;

        /// <summary>
        /// The proj name.
        /// </summary>
        private string projName;

        /// <summary>
        /// The proj desc.
        /// </summary>
        private string projDesc;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminViewModel"/> class.
        /// </summary>
        public AdminViewModel()
        {
            this.AddDepartmentCommand = new RelayCommand(this.AddDepartment);
            this.AddProjectCommand = new RelayCommand(this.AddProject);
            this.CreateNewUserCommand = new RelayCommand(this.CreateNewUser);
        }

        /// <summary>
        /// Gets or sets the department name.
        /// </summary>
        public string DeptName
        {
            get
            {
                return this.deptName;
            }

            set
            {
                this.deptName = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the department mail.
        /// </summary>
        public string DeptMail
        {
            get
            {
                return this.deptMail;
            }

            set
            {
                this.deptMail = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        public string ProjName
        {
            get
            {
                return this.projName;
            }

            set
            {
                this.projName = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the project description.
        /// </summary>
        public string ProjDesc
        {
            get
            {
                return this.projDesc;
            }

            set
            {
                this.projDesc = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The add department.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        private async void AddDepartment()
        {
            this.client = new TimerServiceClient();
            this.client.CreateAsyncDepartment(new DepartmentDataMember
            {
                DepartmentName = this.DeptName,
                DepartmentEmail = this.DeptMail
            });

            var metroWindow = Application.Current.MainWindow as MetroWindow;
            await metroWindow.ShowMessageAsync("Info", "Your department is saved!");
        }

        /// <summary>
        /// The add project.
        /// </summary>
        private async void AddProject()
        {
            this.client = new TimerServiceClient();
            this.client.CreateAsyncProject(new ProjectDataMember
            {
                ProjectName = this.ProjName,
                ProjectDescription = this.ProjDesc
            });

            var metroWindow = Application.Current.MainWindow as MetroWindow;
            await metroWindow.ShowMessageAsync("Info", "Your project is saved!");
        }

        /// <summary>
        /// The create new user.
        /// </summary>
        private void CreateNewUser()
        {
            var window = new MetroWindow
            {
                Title = "Create user",
                SizeToContent = SizeToContent.WidthAndHeight,
                BorderBrush = Brushes.Red,
                ResizeMode = ResizeMode.NoResize,
                Content = new CreateUserView()
            };

            window.ShowDialog();
        }
    }
}
