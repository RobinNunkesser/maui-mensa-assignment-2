using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Mensa
{
    public class SettingsViewModel : INotifyPropertyChanged
    {

        public int Status
        {
            get => Settings.Status;
            set => Settings.Status = value;
        }

        public SettingsViewModel()
        {
            OnPropertyChanged();
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}
