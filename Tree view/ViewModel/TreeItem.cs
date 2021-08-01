using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Tree_view.ViewModel
{
    abstract class TreeItem: INotifyPropertyChanged
    {
        protected BitmapImage _Icon;
        protected TreeItem _parent = null;
        public BitmapImage Icon { get { return _Icon; } }
        protected abstract String getText();
        protected abstract ReadOnlyCollection<TreeItem> getChildren();
        public String Text { get { return getText(); } }
        public ReadOnlyCollection<TreeItem> Childrens { get { return getChildren(); } }
        private bool _isExpanded = false;
        public Boolean IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    OnPropertyChanged("IsExpanded");

                }
                if (_isExpanded && _parent != null)
                    _parent.IsExpanded = true;
            }
        }

         public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
