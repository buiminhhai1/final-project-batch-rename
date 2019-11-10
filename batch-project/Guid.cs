using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.IO.Path;
using System.Globalization;

namespace p1
{

    public class GuidArgs : StringArgs
    {
    }


    class Guid : StringOperation
    {
        public override string Operate(string origin)
        {
            string extension = Path.GetExtension(origin);
            string name = System.Guid.NewGuid().ToString() + extension;
            return name;
        }

        public override StringOperation Clone()
        {
            var oldArgs = Args as GuidArgs;
            return new Guid()
            {
                Args = new GuidArgs()
                {
                }
            };
        }

        public override void Config()
        {
            //var screen = new ReplaceConfigDialog(Args);
            //if (screen.ShowDialog() == true)
            //{
            //    PropertyChanged?.Invoke(this,
            //        new PropertyChangedEventArgs("Description"));
            //}
        }

        public override string Name => "Guid";

        public override string Type => "Guid";
        public override string Description
        {
            get
            {
                var args = Args as GuidArgs;
                return $"New case with option";
            }
        }
    }
}
