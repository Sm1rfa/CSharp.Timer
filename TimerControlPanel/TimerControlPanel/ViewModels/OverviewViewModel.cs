// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OverviewViewModel.cs" company="Time Registration Client">
//  Time Registration Client 
// </copyright>
// <summary>
//   Defines the OverviewViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MahApps.Metro.Controls;
using Microsoft.Office.Interop.Excel;
using TimerControlPanel.Connected_Services.TimerService;
using TimerControlPanel.Models;
using TimerControlPanel.Views;

namespace TimerControlPanel.ViewModels
{
    /// <summary>
    /// The overview view model.
    /// </summary>
    public class OverviewViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the edit view model.
        /// </summary>
        public EditViewModel EditViewModel { get; set; }

        /// <summary>
        /// Gets or sets the load command.
        /// </summary>
        public RelayCommand LoadCommand { get; set; }

        /// <summary>
        /// Gets or sets the edit command.
        /// </summary>
        public RelayCommand EditCommand { get; set; }

        /// <summary>
        /// Gets or sets the excel command.
        /// </summary>
        public RelayCommand ExcelCommand { get; set; }

        /// <summary>
        /// Gets or sets the projects list.
        /// </summary>
        public ObservableCollection<UserModel> UsersList { get; set; }

        /// <summary>
        /// Gets or sets the time list.
        /// </summary>
        public ObservableCollection<TimeModel> TimeList { get; set; }

        /// <summary>
        /// The selected project.
        /// </summary>
        private UserModel selectedUser;

        /// <summary>
        /// The selected time.
        /// </summary>
        private TimeModel selectedTime;

        /// <summary>
        /// The date from.
        /// </summary>
        private DateTime? dateFrom;

        /// <summary>
        /// The date to.
        /// </summary>
        private DateTime? dateTo;

        /// <summary>
        /// The client.
        /// </summary>
        private TimerServiceClient client = new TimerServiceClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="OverviewViewModel"/> class.
        /// </summary>
        public OverviewViewModel()
        {
            this.LoadCommand = new RelayCommand(this.LoadInfo);
            this.EditCommand = new RelayCommand(this.EditTime);
            this.ExcelCommand = new RelayCommand(this.OpenInExcel);

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
        }

        /// <summary>
        /// Gets or sets the selected project.
        /// </summary>
        public UserModel SelectedUser
        {
            get
            {
                return this.selectedUser;
            }

            set
            {
                this.selectedUser = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected time.
        /// </summary>
        public TimeModel SelectedTime
        {
            get
            {
                return this.selectedTime;
            }

            set
            {
                this.selectedTime = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the date from.
        /// </summary>
        public DateTime? DateFrom
        {
            get
            {
                if (this.dateFrom == null)
                {
                    return DateTime.Now;
                }

                return this.dateFrom;
            }

            set
            {
                this.dateFrom = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the date to.
        /// </summary>
        public DateTime? DateTo
        {
            get
            {
                if (this.dateTo == null)
                {
                    return DateTime.Now;
                }

                return this.dateTo;
            }

            set
            {
                this.dateTo = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the timing schema.
        /// </summary>
        public ObservableCollection<TimeModel> TimingSchema
        {
            get
            {
                return this.TimeList;
            }

            set
            {
                this.TimeList = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The load info.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        private void LoadInfo()
        {
            //var time = this.client.GetAsyncTimes();

            //this.TimingSchema = new ObservableCollection<TimeModel>();

            //foreach (var item in time)
            //{
            //    this.TimingSchema.Add(new TimeModel
            //    {
            //        TimeId = item.TimeId,
            //        WorkDate = item.WorkDate,
            //        StartTime = item.StartTime,
            //        EndTime = item.EndTime,
            //        Break = item.Break,
            //        Note = item.Note,
            //        Users = item.Users.ToList(),
            //        Projects = item.Projects.ToList()
            //    });
            //}

            var time = this.client.RetrieveTimeForUser(
                this.SelectedUser.UserId, this.DateFrom.Value, this.DateTo.Value);

            this.TimingSchema = new ObservableCollection<TimeModel>();

            foreach (var item in time)
            {
                this.TimingSchema.Add(new TimeModel
                {
                    TimeId = item.TimeId,
                    WorkDate = item.WorkDate,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Break = item.Break,
                    Note = item.Note,
                    Users = item.Users.ToList(),
                    Projects = item.Projects.ToList()
                });
            }
        }

        /// <summary>
        /// The edit time.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        private void EditTime()
        {
            //var time = this.client.GetAsyncTime(this.SelectedTime.TimeId);
            var window = new MetroWindow()
            {
                Title = "Edit window",
                SizeToContent = SizeToContent.WidthAndHeight,
                BorderBrush = Brushes.Red,
                ResizeMode = ResizeMode.NoResize,
                Content = new EditView(
                    this.SelectedTime.TimeId,
                    this.SelectedTime.StartTime,
                    this.SelectedTime.EndTime,
                    this.SelectedTime.WorkDate)
            };

            window.ShowDialog();
        }

        /// <summary>
        /// The open in excel.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        private void OpenInExcel()
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application
            {
                Visible = true
            };

            var wb = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            var ws = (Worksheet)wb.Worksheets[1];

            var header = 1;
            for (var i = 1; i <= 5; i++)
            {
                if (i == 1)
                {
                    var theRange = ws.Range["A1", "A1"];
                    theRange.Value = "Date";
                }
                if (i == 2)
                {
                    var theRange = ws.Range["B1", "B1"];
                    theRange.Value = "Start Time";
                }
                if (i == 3)
                {
                    var theRange = ws.Range["C1", "C1"];
                    theRange.Value = "End Time";
                }
                if (i == 4)
                {
                    var theRange = ws.Range["D1", "D1"];
                    theRange.Value = "Break";
                }
                if (i == 5)
                {
                    var theRange = ws.Range["E1", "E1"];
                    theRange.Value = "Note";
                }
            }
            
            var count = 2;
            foreach (var item in this.TimingSchema)
            {
                var theRange1 = ws.Range["A4", "A" + count.ToString()];
                var theRange2 = ws.Range["B4", "B" + count.ToString()];
                var theRange3 = ws.Range["C4", "C" + count.ToString()];
                var theRange4 = ws.Range["D4", "D" + count.ToString()];
                var theRange5 = ws.Range["E4", "E" + count.ToString()];

                theRange1.Value = item.WorkDate.ToShortDateString();
                theRange2.Value = item.StartTime;
                theRange3.Value = item.EndTime;
                theRange4.Value = item.Break;
                theRange5.Value = item.Note;

                count++;
            }
        }
    }
}
