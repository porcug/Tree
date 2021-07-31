using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Tree_view.ViewModel
{
    class Step : Task
    {

        List<String> owners = new List<string>();
        
       public Step (Root root,String [] arguments,String path):base(root,arguments,path)
        {
            
            _Icon = new BitmapImage(new Uri("pack://aplication:,,/Resources/Icons/step.png"));
          foreach (String nume in arguments.Skip(3))
            {
                owners.Add(nume);
            }
        }
       

        protected override string getText()

        {
            
            return base.Text+" - "+ String.Join(" & ", owners);

        }
    }
}
