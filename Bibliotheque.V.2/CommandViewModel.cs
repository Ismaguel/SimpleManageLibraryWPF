using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Bibliotheque.V._2
{
    public class CommandViewModel
    {
        public string DisplayName { get; set; }
        public ICommand Command { get; private set; }
        public Geometry IconData { get; private set; }

        public CommandViewModel(string i_DisplayName, ICommand i_Command) : this(i_DisplayName, i_Command, null)
        {

        }
        public CommandViewModel(string i_DisplayName, Geometry i_IconData) : this(i_DisplayName, null, i_IconData)
        {

        }
        public CommandViewModel(string i_DisplayName, ICommand i_Command, Geometry i_IconData)
        {
            if (i_Command == null)
                throw new ArgumentNullException("i_Command");
            this.DisplayName = i_DisplayName;
            this.Command = i_Command;
            this.IconData = i_IconData;
        }
    }
}
