using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Tree_view.ViewModel
{
    class Task:TreeItem
    {
        private string _Name;
        Root root;
        String path = "/";
        public Task(Root root,String [] arguments,String path)
        {
            _Icon = new BitmapImage(new Uri("pack://aplication:,,/Resources/Icons/task.png"));
            _Name = arguments[2];
            if(arguments[0].Equals("+"))
            {
                base.IsExpanded = false;
            }
            if (arguments[0].Equals("-"))
            {
                base.IsExpanded = true;
            }
            this.path = path + "/" + arguments[1];
            
            this.root = root;
        }
        ReadOnlyCollection<TreeItem> children = null;
        protected override ReadOnlyCollection<TreeItem> getChildren()
        {
            if(children==null)
            {
                children = root.getChildrens(path);
            }
            return children;
        }

        protected override string getText()
        {
            return _Name;
        }
    }
}
