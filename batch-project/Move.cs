using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.IO.Path;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
namespace p1
{

    class MoveArgs : StringArgs
    {
        public int Option { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;
    }

    class Move : StringOperation
    {
        public override string Operate(string origin)
        {
            
            string name = origin;
            
            Regex regex = new Regex(@"^[\d-]+$");
            var args = Args as MoveArgs;
            var option = args.Option;
            string result = name;
            if (option == 0)
            {
                string isbn = name.Substring(0, 13);
                if (regex.IsMatch(isbn))
                {
                    result = name.Substring(14) + " " + isbn;
                }
            }else if (option == 1)
            {
                string extension = Path.GetExtension(name);
                
                string isbn = name.Substring(name.Length-13-extension.Length,13);
                if (regex.IsMatch(isbn))
                {
                    result = isbn + " " + name.Substring(0,name.Length - isbn.Length - extension.Length -1) +extension;
                }
            }

            

            return result;
        }

        public override StringOperation Clone()
        {
            var oldArgs = Args as MoveArgs;
            return new Move()
            {
                Args = new MoveArgs()
                {
                    Option = oldArgs.Option
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

        public override string Name => "Move";
        public override string Type => "Move";
        public override string Description
        {
            get
            {
                var args = Args as ReplaceArgs;
                return $"New case with option";
            }
        }
    }
}

    
