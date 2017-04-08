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

        public ProjectModel(string projectName, ObservableCollection<ColumnModel> columnCollection)
        {
            _projectName = projectName;
            _columnCollection = columnCollection;
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

        private ObservableCollection<ColumnModel> _columnCollection;
        public ObservableCollection<ColumnModel> ColumnCollection
        {
            get { return _columnCollection; }
            set
            {
                _columnCollection = value; 
                OnPropertyChanged(nameof(ColumnCollection));
            }
        }
        #endregion

        public void AddColumn()
        {
        
        }
    }
}
