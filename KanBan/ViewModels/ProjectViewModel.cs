using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KanBan.Annotations;
using KanBan.Models;

namespace KanBan.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProjectViewModel()
        {
            loadedProject = new ProjectModel("yo");
        }

        private ProjectModel loadedProject;
        public ProjectModel LoadedProject
        {
            get { return loadedProject; }
            set
            {
                loadedProject = value; 
                OnPropertyChanged(nameof(LoadedProject));
            }
        }

    }
}
