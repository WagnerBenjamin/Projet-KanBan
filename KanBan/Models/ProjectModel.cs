using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using KanBan.Annotations;
using Utiles = KanBan.Utils.Util;

namespace KanBan.Models
{
    public class ProjectModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProjectModel()
        {

        }

        public ProjectModel(string projectName, ObservableCollection<ColumnModel> columnModels)
        {
            _projectName = projectName;
            _columnCollection = columnModels;
        }

        public ProjectModel(string projectName, DateTime deadLine, ObservableCollection<ColumnModel> columnCollection, string projectDescription, ObservableCollection<Utiles.User> usersOnProjectCollection)
        {
            _projectName = projectName;
            _deadLine = deadLine;
            _columnCollection = columnCollection;
            _projectDescription = projectDescription;
            _usersOnProjectCollection = usersOnProjectCollection;
        }

        #region XamlVariable
        private string _projectName;
        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                _projectName = value; 
                OnPropertyChanged(nameof(ProjectName));
            }
        }
        
        private DateTime _deadLine;
        public DateTime DeadLine
        {
            get { return _deadLine; }
            set
            {
                _deadLine = value; 
                OnPropertyChanged(nameof(DeadLine));
            }
        }


        private ObservableCollection<ColumnModel> _columnCollection = new ObservableCollection<ColumnModel>();
        public ObservableCollection<ColumnModel> ColumnCollection
        {
            get { return _columnCollection; }
            set
            {
                _columnCollection = value; 
                OnPropertyChanged(nameof(ColumnCollection));
            }
        }
        
        private ColumnModel _selectedColumnModel;
        public ColumnModel SelectedColumnModel
        {
            get { return _selectedColumnModel; }
            set
            {
                _selectedColumnModel = value; 
                OnPropertyChanged(nameof(SelectedColumnModel));
            }
        }
       
        private string _projectDescription;
        public string ProjectDescription
        {
            get { return _projectDescription; }
            set
            {
                _projectDescription = value;
                OnPropertyChanged(nameof(ProjectDescription));
            }
        }

        private ObservableCollection<Utiles.User> _usersOnProjectCollection;
        public ObservableCollection<Utiles.User> UsersOnProjectCollection
        {
            get { return _usersOnProjectCollection; }
            set
            {
                _usersOnProjectCollection = value; 
                OnPropertyChanged(nameof(UsersOnProjectCollection));
            }
        }

        private int _projectSprintDuration;
        public int ProjectSprintDuration
        {
            get { return _projectSprintDuration; }
            set
            {
                _projectSprintDuration = value; 
                OnPropertyChanged(nameof(ProjectSprintDuration));
            }
        }
        #endregion

        public void AddColumn()
        {
            ColumnCollection.Add(new ColumnModel("Nouvelle colonne", new ObservableCollection<TaskModel>()));
        }
    }
}
