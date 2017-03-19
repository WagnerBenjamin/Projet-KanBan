using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        public ProjectModel(string name)
        {
            this._name = name;
            _columnCollection.Add(new ColumnModel("dsq"));
            _columnCollection.Add(new ColumnModel("dsq"));
            _columnCollection.Add(new ColumnModel("dsq"));
            _columnCollection.Add(new ColumnModel("dsq"));
        }

        #region XamlVariable
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


        #endregion

    }
}
