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
        
       public Step (Root root,String [] arguments):base(root,arguments)
        {
            
            //_Icon = new BitmapImage(new Uri("pack://aplication:,,/Resources/Icons/step.png"));
          foreach (String nume in arguments.Skip(2))
            {
                owners.Add(nume);
            }
        }
       

        protected override string getText()

        {
            if (owners.Count() != 1)
            {
                return base.getText() + " - " + String.Join(" & ", owners.Take(owners.Count - 1)) + owners.Last();
            }
            return base.getText() + " - anonymus";
        }
    }
}
