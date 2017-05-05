// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateUserViewModel.cs" company="">
//   Create user
// </copyright>
// <summary>
//   The create user view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TimerControlPanel.Connected_Services.TimerService;
using TimerControlPanel.Models;

namespace TimerControlPanel.ViewModels
{
    /// <summary>
    /// The create user view model.
    /// </summary>
    public class CreateUserViewModel : ViewModelBase
    {
        /// <summary>
        /// The client.
        /// </summary>
        private TimerServiceClient client = new TimerServiceClient();

        /// <summary>
        /// The first name.
        /// </summary>
        private string firstName;

        /// <summary>
        /// The last name.
        /// </summary>
        private string lastName;

        /// <summary>
        /// The account.
        /// </summary>
        private string account;

        /// <summary>
        /// The password.
        /// </summary>
        private string password;

        /// <summary>
        /// The email.
        /// </summary>
        private string email;

        /// <summary>
        /// The is admin.
        /// </summary>
        private bool isAdmin;

        /// <summary>
        /// The selected department.
        /// </summary>
        private DepartmentModel selectedDepartment;

        /// <summary>
        /// The selected project.
        /// </summary>
        private ProjectModel selectedProject;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserViewModel"/> class.
        /// </summary>
        public CreateUserViewModel()
        {
            this.CreateUserCommand = new RelayCommand(this.CreateNewUser);

            this.DepartmentList = new List<DepartmentModel>();
            var deparartments = (from d in this.client.GetAsyncDepartments() select d).ToList();
            this.DepartmentList.AddRange(deparartments.Select(d => new DepartmentModel
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName,
                DepartmentEmail = d.DepartmentEmail
            }));

            this.ProjectList = new List<ProjectModel>();
            var projects = (from p in this.client.GetAsyncProjects() select p).ToList();
            this.ProjectList.AddRange(projects.Select(p => new ProjectModel
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName,
                ProjectDescription = p.ProjectDescription
            }));
        }

        /// <summary>
        /// Gets or sets the create user command.
        /// </summary>
        public RelayCommand CreateUserCommand { get; set; }

        /// <summary>
        /// Gets or sets the department list.
        /// </summary>
        public List<DepartmentModel> DepartmentList { get; set; }

        /// <summary>
        /// Gets or sets the project list.
        /// </summary>
        public List<ProjectModel> ProjectList { get; set; }

        /// <summary>
        /// Gets or sets the department lists.
        /// </summary>
        public List<DepartmentModel> DepartmentLists
        {
            get
            {
                return this.DepartmentList;
            }

            set
            {
                this.DepartmentList = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        public string Account
        {
            get
            {
                return this.account;
            }

            set
            {
                this.account = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is admin.
        /// </summary>
        public bool IsAdmin
        {
            get
            {
                return this.isAdmin;
            }

            set
            {
                this.isAdmin = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected department.
        /// </summary>
        public DepartmentModel SelectedDepartment
        {
            get
            {
                return this.selectedDepartment;
            }

            set
            {
                this.selectedDepartment = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected project.
        /// </summary>
        public ProjectModel SelectedProject
        {
            get
            {
                return this.selectedProject;
            }

            set
            {
                this.selectedProject = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The create new user.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        private void CreateNewUser()
        {
            var dept = new Department
            {
                DepartmentId = this.SelectedDepartment.DepartmentId,
                DepartmentName = this.SelectedDepartment.DepartmentName,
                DepartmentEmail = this.SelectedDepartment.DepartmentEmail
            };

            var proj = new Project
            {
                ProjectId = this.SelectedProject.ProjectId,
                ProjectName = this.SelectedProject.ProjectName,
                ProjectDescription = this.SelectedProject.ProjectDescription
            };

            this.client.CreateAsyncUser(new UserDataMember
            {
                Firstname = this.FirstName,
                Lastname = this.LastName,
                Account = this.Account,
                Password = this.Password,
                Email = this.Email,
                IsAdmin = this.IsAdmin,
                Projects = new[] { proj },
                Department = dept
            });
        }
    }
}
