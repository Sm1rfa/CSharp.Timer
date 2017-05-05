using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using TimerControlPanel.Connected_Services.TimerService;
using TimerControlPanel.ViewModels;

namespace TimerControlPanel.Views
{
    /// <summary>
    /// Interaction logic for UpdateView.xaml
    /// </summary>
    public partial class EditView : UserControl
    {
        /// <summary>
        /// Gets or sets the edit view model.
        /// </summary>
        public EditViewModel EditViewModel { get; set; }

        private int timeId = 0;

        public EditView(int id, string st, string et, DateTime date)
        {
            InitializeComponent();
            this.EditViewModel = new EditViewModel();
            this.timeId = id;
            this.textBox.Text = st;
            this.textBox1.Text = et;
            this.datePick.DisplayDate = date;
        }

        private async void ButtonUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = new TimerServiceClient();
                client.UpdateAsyncTime(new TimeDataMember
                {
                    TimeId = timeId,
                    StartTime = this.textBox.Text,
                    EndTime = this.textBox1.Text,
                    WorkDate = this.datePick.SelectedDate.Value
                });

                Window.GetWindow(this).Close();

                var metroWindow = Application.Current.MainWindow as MetroWindow;
                await metroWindow.ShowMessageAsync("Info", "Your update has been made!");
            }
            catch (Exception)
            {
                var metroWindow = Application.Current.MainWindow as MetroWindow;
                await metroWindow.ShowMessageAsync("Error", "Something went wrong.. you couldn't update!");
            }
        }
    }
}
