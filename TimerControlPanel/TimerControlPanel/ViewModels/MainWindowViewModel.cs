// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Timer Project">
// Timer Project  
// </copyright>
// <summary>
//   Defines the MainWindowViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GalaSoft.MvvmLight;

namespace TimerControlPanel.ViewModels
{
    /// <summary>
    /// The main window view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the register time view model.
        /// </summary>
        public RegisterTimeViewModel RegisterTimeViewModel { get; set; }

        /// <summary>
        /// Gets or sets the overview view model.
        /// </summary>
        public OverviewViewModel OverviewViewModel { get; set; }

        /// <summary>
        /// Gets or sets the feedback view model.
        /// </summary>
        public FeedbackViewModel FeedbackViewModel { get; set; }

        /// <summary>
        /// Gets or sets the admin view model.
        /// </summary>
        public AdminViewModel AdminViewModel { get; set; }

        /// <summary>
        /// The selected tab index.
        /// </summary>
        private int selectedTabIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.AdminViewModel = new AdminViewModel();
            this.RegisterTimeViewModel = new RegisterTimeViewModel();
            this.OverviewViewModel = new OverviewViewModel();
            this.FeedbackViewModel = new FeedbackViewModel();
        }

        /// <summary>
        /// Gets or sets the selected tab index.
        /// </summary>
        public int SelectedTabIndex
        {
            get
            {
                return this.selectedTabIndex;
            }

            set
            {
                if (value == this.selectedTabIndex)
                {
                    return;
                }
                
                this.selectedTabIndex = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
