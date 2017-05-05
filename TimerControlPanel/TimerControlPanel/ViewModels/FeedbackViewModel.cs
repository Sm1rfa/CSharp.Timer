// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedbackViewModel.cs" company="Project Time Register">
//   Project Time Register
// </copyright>
// <summary>
//   The feedback view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using TimerControlPanel.Connected_Services.TimerService;
using TimerControlPanel.Models;

namespace TimerControlPanel.ViewModels
{
    /// <summary>
    /// The feedback view model.
    /// </summary>
    public class FeedbackViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the projects list.
        /// </summary>
        public List<UserModel> UsersList { get; set; }

        /// <summary>
        /// The client.
        /// </summary>
        private TimerServiceClient client = new TimerServiceClient();

        /// <summary>
        /// The selected sender.
        /// </summary>
        private UserModel selectedSender;

        /// <summary>
        /// The selected receiver.
        /// </summary>
        private UserModel selectedReceiver;

        /// <summary>
        /// The mail message.
        /// </summary>
        private string mailMessage;

        /// <summary>
        /// The subject box.
        /// </summary>
        private string subjectBox;

        /// <summary>
        /// Gets or sets the send command.
        /// </summary>
        public RelayCommand SendCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackViewModel"/> class.
        /// </summary>
        public FeedbackViewModel()
        {
            this.SendCommand = new RelayCommand(this.SendMessage);

            this.UsersList = new List<UserModel>();
            var users = (from u in this.client.GetAsyncUsers() select u).ToList();

            this.UsersList.AddRange(users.Select(u => new UserModel
            {
                UserId = u.UserId,
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                Account = u.Account,
                IsAdmin = u.IsAdmin,
                Email = u.Email,
                Password = u.Password,
                Department = u.Department,
                Projects = u.Projects.ToList(),
                FullName = u.Firstname + " " + u.Lastname
            }));
        }

        /// <summary>
        /// Gets or sets the selected sender.
        /// </summary>
        public UserModel SelectedSender
        {
            get
            {
                return this.selectedSender;
            }

            set
            {
                this.selectedSender = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected receiver.
        /// </summary>
        public UserModel SelectedReceiver
        {
            get
            {
                return this.selectedReceiver;
            }

            set
            {
                this.selectedReceiver = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the subject box.
        /// </summary>
        public string SubjectBox
        {
            get
            {
                return this.subjectBox;
            }

            set
            {
                this.subjectBox = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the mail message.
        /// </summary>
        public string MailMessage
        {
            get
            {
                return this.mailMessage;
            }

            set
            {
                this.mailMessage = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The send message.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private async void SendMessage()
        {
            try
            {
                this.client.SendMessage(
                this.SelectedSender.Email,
                this.SelectedReceiver.Email,
                this.SubjectBox,
                this.MailMessage);

                var metroWindow = Application.Current.MainWindow as MetroWindow;
                await metroWindow.ShowMessageAsync("Info", "Your message was sent!");
            }
            catch (Exception)
            {
                var metroWindow = Application.Current.MainWindow as MetroWindow;
                await metroWindow.ShowMessageAsync("Error", "Your message was NOT sent!");
            }
        }
    }
}
