using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.IO.Path;
using System.Globalization;

namespace p1
{

    public class FullnameNormalizeArgs : StringArgs
    {
    }


    class FullnameNormalize: StringOperation
    {
        public override string Operate(string origin)
        {
            string name = Path.GetFileNameWithoutExtension(origin);
            string extension = Path.GetExtension(origin);
            string result = name;
            result = result.Trim();
            result = System.Text.RegularExpressions.Regex.Replace(result, @"\s+", " ");
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            result = textInfo.ToTitleCase(result);

            return result + extension;
        }

        public override StringOperation Clone()
        {
            var oldArgs = Args as FullnameNormalizeArgs;
            return new FullnameNormalize()
            {
                Args = new FullnameNormalizeArgs()
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

        public override string Name => "Fullname Normalize";

        public override string Type => "FullnameNormalize";
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
