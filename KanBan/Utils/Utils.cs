using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KanBan.Annotations;

namespace KanBan.Utils
{
    public static class Utils
    {
        public struct User : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            private string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value; 
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public static ObservableCollection<User> UsersCollection = new ObservableCollection<User>();
    }
}
