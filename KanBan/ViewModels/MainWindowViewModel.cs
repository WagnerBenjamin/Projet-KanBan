using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using KanBan.Annotations;
using KanBan.Models;
using KanBan.Utils;

namespace KanBan.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            for (int l = 0; l < 4; l++)
            {
                ObservableCollection<ColumnModel> columntemp = new ObservableCollection<ColumnModel>();
                for (int i = 0; i < 5; i++)
                {  
                    ObservableCollection<TaskModel> tasktemp = new ObservableCollection<TaskModel>();
                    for (int j = 0; j < 5; j++)
                    {
                        ObservableCollection<SubTask> subtasktemp = new ObservableCollection<SubTask>();
                        for (int k = 0; k < 3; k++)
                        {
                            subtasktemp.Add(new SubTask("SubTask" + l+j+i+k, "hfis"));
                        }
                        tasktemp.Add(new TaskModel("Task" + l+j+i, null, "yoylo " + l + j + i, subtasktemp));
                    }
                    columntemp.Add(new ColumnModel("Column" + l+i, tasktemp));
                }
                _projectCollection.Add(new ProjectModel("Project" + l, columntemp));
            }
            SelectedItem = ProjectCollection[0];
        }

        private ObservableCollection<ProjectModel> _projectCollection = new ObservableCollection<ProjectModel>();
        public ObservableCollection<ProjectModel> ProjectCollection
        {
            get { return _projectCollection; }
            set
            {
                _projectCollection = value; 
                OnPropertyChanged(nameof(ProjectCollection));
            }
        }

        private ProjectModel _selectedItem;
        public ProjectModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value; 
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        //private ICommand _newColumnCommand;
        //public ICommand NewColumnCommand
        //{
        //    get
        //    {
        //        this._newColumnCommand = new RelayCommand((SelectedItem as ProjectModel).AddColumn);
        //        return _newColumnCommand;
        //    }
        //    set { _newColumnCommand = value; }
        //}


    }
}
