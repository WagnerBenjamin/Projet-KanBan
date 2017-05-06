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
    public class TaskModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TaskModel()
        {
            
        }

        public TaskModel(string name, DateTime? deadLine, string description, ObservableCollection<SubTaskModel> subTasksList)
        {
            _name = name;
            _deadLine = deadLine;
            _description = description;
            _subTasksCollection = subTasksList;
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

        private DateTime? _deadLine;
        public DateTime? DeadLine
        {
            get { return _deadLine; }
            set
            {
                _deadLine = value; 
                OnPropertyChanged(nameof(DeadLine));
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value; 
                OnPropertyChanged(nameof(Description));
            }
        }

        private ObservableCollection<SubTaskModel> _subTasksCollection;
        public ObservableCollection<SubTaskModel> SubTasksCollection
        {
            get { return _subTasksCollection; }
            set
            {
                _subTasksCollection = value; 
                OnPropertyChanged(nameof(SubTasksCollection));
            }
        }

        private int _taskWeight;
        public int TaskWeight
        {
            get { return _taskWeight; }
            set
            {
                _taskWeight = value; 
                OnPropertyChanged(nameof(TaskWeight));
            }
        }

        private char _taskPriority;
        public char TaskPriority
        {
            get { return _taskPriority; }
            set
            {
                _taskPriority = value; 
                OnPropertyChanged(nameof(TaskPriority));
            }
        }

    }

    public class SubTaskModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SubTaskModel(string name, string description)
        {
            _name = name;
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

        private bool _isDone;
        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                _isDone = value; 
                OnPropertyChanged(nameof(IsDone));
            }
        }

    }
}
