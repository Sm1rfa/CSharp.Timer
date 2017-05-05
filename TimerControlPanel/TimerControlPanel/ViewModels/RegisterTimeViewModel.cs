// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterTimeViewModel.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the RegisterTimeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using TimerControlPanel.Connected_Services.TimerService;
using TimerControlPanel.Mappers;
using TimerControlPanel.Models;

namespace TimerControlPanel.ViewModels
{
    /// <summary>
    /// The register time view model.
    /// </summary>
    public class RegisterTimeViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        public RelayCommand SaveCommand { get; set; }

        /// <summary>
        /// Gets or sets the start box.
        /// </summary>
        private string startBox { get; set; }

        /// <summary>
        /// Gets or sets the end box.
        /// </summary>
        private string endBox { get; set; }

        /// <summary>
        /// The selected break.
        /// </summary>
        private string selectedBreak;

        /// <summary>
        /// Gets or sets the choosen date.
        /// </summary>
        private DateTime? choosenDate { get; set; }

        /// <summary>
        /// Gets or sets the time note.
        /// </summary>
        private string timeNote { get; set; }

        /// <summary>
        /// Gets or sets the users list.
        /// </summary>
        public ObservableCollection<UserModel> UsersList { get; set; }

        /// <summary>
        /// Gets or sets the project list.
        /// </summary>
        public ObservableCollection<ProjectModel> ProjectList { get; set; }

        /// <summary>
        /// Gets or sets the break list.
        /// </summary>
        public ObservableCollection<int> BreakList { get; set; }

        /// <summary>
        /// The user selected.
        /// </summary>
        private UserModel userSelected;

        /// <summary>
        /// The project selected.
        /// </summary>
        private ProjectModel projectSelected;

        /// <summary>
        /// The client.
        /// </summary>
        private TimerServiceClient client = new TimerServiceClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterTimeViewModel"/> class.
        /// </summary>
        public RegisterTimeViewModel()
        {
            this.SaveCommand = new RelayCommand(this.SaveTimeForUser);
            
            this.UsersList = new ObservableCollection<UserModel>();
            var users = (from u in this.client.GetAsyncUsers() select u).ToList();

            foreach (var item in users)
            {
                this.UsersList.Add(new UserModel
                {
                    UserId = item.UserId,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    Account = item.Account,
                    IsAdmin = item.IsAdmin,
                    Email = item.Email,
                    Password = item.Password,
                    Department = item.Department,
                    Projects = item.Projects.ToList(),
                    FullName = item.Firstname + " " + item.Lastname
                });
            }
            
            this.BreakList = new ObservableCollection<int> { 0, 15, 30 };

            this.ProjectList = new ObservableCollection<ProjectModel>();
            var projects = (from p in this.client.GetAsyncProjects() select p).ToList();

            foreach (var item in projects)
            {
                this.ProjectList.Add(new ProjectModel
                {
                    ProjectId = item.ProjectId,
                    ProjectName = item.ProjectName,
                    ProjectDescription = item.ProjectDescription,
                    Users = item.Users.ToList(),
                    Times = item.Times.ToList()
                });
            }
        }

        /// <summary>
        /// Gets or sets the user selected.
        /// </summary>
        public UserModel UserSelected
        {
            get { return this.userSelected; }
            set
            {
                if (this.userSelected != value)
                {
                    this.userSelected = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected break.
        /// </summary>
        public string SelectedBreak
        {
            get
            {
                return this.selectedBreak;
            }
            set
            {
                this.selectedBreak = value;
                this.RaisePropertyChanged();
            }
        }

        public ProjectModel SelectedProject
        {
            get
            {
                return this.projectSelected;
            }
            set
            {
                this.projectSelected = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the start box.
        /// </summary>
        public string StartBox
        {
            get
            {
                return this.startBox;
            }
            set
            {
                this.startBox = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the end box.
        /// </summary>
        public string EndBox
        {
            get
            {
                return this.endBox;
            }

            set
            {
                this.endBox = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the choosen date.
        /// </summary>
        public DateTime? ChoosenDate
        {
            get
            {
                if (this.choosenDate == null)
                {
                    return DateTime.Now.Date;
                }

                return this.choosenDate;
            }

            set
            {
                this.choosenDate = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the time note.
        /// </summary>
        public string TimeNote
        {
            get { return this.timeNote; }
            set { this.timeNote = value; }
        }

        /// <summary>
        /// The save time for user.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        private async void SaveTimeForUser()
        {
            var convertedbreak = int.Parse(this.SelectedBreak);

            var mapper = new ObjectMap();
            var user = mapper.MapUser(this.userSelected.UserId);
            var project = mapper.MapProject(this.projectSelected.ProjectId);

            this.client.CreateAsyncTime(new TimeDataMember
            {
                WorkDate = this.ChoosenDate.Value.Date,
                StartTime = this.StartBox,
                EndTime = this.EndBox,
                Break = convertedbreak,
                Note = this.TimeNote,
                Users = new[] { user },
                Projects = new[] { project }
            });

            var start = "Start time: " + this.ChoosenDate.Value.Date.ToShortDateString() + " " + this.StartBox;
            var end = "End time: " + this.ChoosenDate.Value.Date.ToShortDateString() + " " + this.EndBox;

            var metroWindow = Application.Current.MainWindow as MetroWindow;
            await metroWindow.ShowMessageAsync("Info", "You have saved your time!\n" + start + "\n" + end);
        }
    }
}
