using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Path = System.IO.Path;
namespace p1
{
    
    public class NewCaseArgs : StringArgs
    {
        public int Option { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;
    }

    class NewCase: StringOperation
    {
        public override string Operate(string origin)
        {

            string name = Path.GetFileNameWithoutExtension(origin);
            string extension = Path.GetExtension(origin);
            var args = Args as NewCaseArgs;
            var option = args.Option;
            string result = origin;
            if (option == 0)
            {
                result = name.ToLower();
            }else if (option == 1)
            {
                result = name.ToUpper();
            }else if (option == 2)
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                result = textInfo.ToTitleCase(name);
            }
            return result + extension;
        }

        public override StringOperation Clone()
        {
            var oldArgs = Args as NewCaseArgs;
            return new NewCase()
            {
                Args = new NewCaseArgs()
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

        public override string Name => "New Case";
        public override string Type => "NewCase";
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
