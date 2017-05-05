// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditViewModel.cs" company="">
//   Edit view model
// </copyright>
// <summary>
//   Defines the EditViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TimerControlPanel.Connected_Services.TimerService;

namespace TimerControlPanel.ViewModels
{
    /// <summary>
    /// The edit view model.
    /// </summary>
    public class EditViewModel : ViewModelBase
    {
        /// <summary>
        /// The client.
        /// </summary>
        private readonly TimerServiceClient client = new TimerServiceClient();

        private string changedStartTime;
        private string changedEndTime;
        private DateTime selectedDate;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditViewModel"/> class.
        /// </summary>
        public EditViewModel()
        {
            this.UpdateCommand = new RelayCommand(this.UpdateTime);
        }

        /// <summary>
        /// Gets or sets the cancel command.
        /// </summary>
        public RelayCommand CancelCommand { get; set; }

        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        public RelayCommand UpdateCommand { get; set; }

        public DateTime SelectedDate
        {
            get
            {
                return this.selectedDate;
            }

            set
            {
                this.selectedDate = value;
                this.RaisePropertyChanged();
            }
        }

        public string ChangedStartTime
        {
            get
            {
                return this.changedStartTime;
            }

            set
            {
                this.changedStartTime = value;
                this.RaisePropertyChanged();
            }
        }

        public string ChangedEndTime
        {
            get
            {
                return this.changedEndTime;
            }

            set
            {
                this.changedEndTime = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The update time.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void UpdateTime()
        {
            var time = new TimeDataMember()
            {
                //TimeId = ,
                StartTime = this.ChangedStartTime,
                EndTime = this.ChangedEndTime,
                WorkDate = this.SelectedDate
            };
            this.client.UpdateAsyncTime(time);
        }
    }
}
