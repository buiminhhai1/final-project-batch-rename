using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1
{
    public class StringArgs
    {
    }

    

    public abstract class StringOperation
    {
        public StringArgs Args { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;

        public abstract string Operate(string origin);

        public abstract string Name { get; }
        public abstract string Type { get; }
        public abstract string Description { get; }

        public abstract StringOperation Clone();

        public abstract void Config();
    }

}
