using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KanBan.Annotations;

namespace KanBan.Models
{
    public class ColumnModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ColumnModel(string name, ObservableCollection<TaskModel> tasksCollection)
        {
            _name = name;
            _tasksCollection = tasksCollection;
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

        private ObservableCollection<TaskModel> _tasksCollection;
        public ObservableCollection<TaskModel> TasksCollection
        {
            get { return _tasksCollection; }
            set
            {
                _tasksCollection = value; 
                OnPropertyChanged(nameof(TasksCollection));
            }
        }


    }
}
