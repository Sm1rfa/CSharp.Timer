// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Timer Project">
//  Timer Project 
// </copyright>
// <summary>
//   Defines the ViewModelBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.CompilerServices;

using SCBDK.Internal.Timer.ControlPanel.Annotations;

namespace SCBDK.Internal.Timer.ControlPanel
{
    /// <summary>
    /// The view model base.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
