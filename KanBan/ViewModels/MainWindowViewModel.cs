using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KanBan.Annotations;
using KanBan.Models;

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
            ProjectCollection.Add(new ProjectModel("lel1"));
            ProjectCollection.Add(new ProjectModel("lel2"));
            ProjectCollection.Add(new ProjectModel("lel3"));
            ProjectCollection.Add(new ProjectModel("lel4"));
            ProjectCollection.Add(new ProjectModel("lel5"));
        }

        private ObservableCollection<ProjectModel> projectCollection = new ObservableCollection<ProjectModel>();
        public ObservableCollection<ProjectModel> ProjectCollection
        {
            get { return projectCollection; }
            set
            {
                projectCollection = value; 
                OnPropertyChanged(nameof(ProjectCollection));
            }
        }

        private ColumnModel selectedItem;
        public ColumnModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value; 
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

    }
}
