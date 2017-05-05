using System.Windows.Controls;
using TimerControlPanel.ViewModels;

namespace TimerControlPanel.Views
{
    /// <summary>
    /// Interaction logic for CreateUserView.xaml
    /// </summary>
    public partial class CreateUserView : UserControl
    {
        /// <summary>
        /// Gets or sets the create user view model.
        /// </summary>
        public CreateUserViewModel CreateUserViewModel { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserView"/> class.
        /// </summary>
        public CreateUserView()
        {
            InitializeComponent();
            this.CreateUserViewModel = new CreateUserViewModel();
            this.DataContext = this.CreateUserViewModel;
        }
    }
}
