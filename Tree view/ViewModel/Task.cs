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
        String path = "0";
        public Task(Root root,String [] arguments)
        {
            //_Icon = new BitmapImage(new Uri("pack://aplication:,,/Icons/task.png"));
            _Name = arguments[1];
           
            this.path =  arguments[0];
            
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
