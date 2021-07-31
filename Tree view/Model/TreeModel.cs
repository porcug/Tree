using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree_view.ViewModel;

namespace Tree_view.Model
{
    class TreeModel
    {
        
        public TreeModel(String ServerIpAddress)
        {
            _Task_tree = new Root(ServerIpAddress).getChildrens();

        }
        private ReadOnlyCollection<TreeItem> _Task_tree;    
        public ReadOnlyCollection<TreeItem> Task_tree {  get { return _Task_tree; } }


    }
}
