using System;
using System.Windows;
using MahApps.Metro.Controls;
using TimerControlPanel.ViewModels;

namespace TimerControlPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public AdminViewModel AdminViewModel { get; set; }

        public MainWindow()
        {
            this.InitializeComponent();
            if (Environment.UserName == "xxx")
            {
                this.adminTab.Visibility = Visibility.Visible;
                this.AdminViewModel = new AdminViewModel();
            }
        }
    }
}
