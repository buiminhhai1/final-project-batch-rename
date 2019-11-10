using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace p1
{

    public class ReplaceArgs : StringArgs
    {
        public string From { get; set; }
        public string To { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;
    }

    public class UltraReplaceArgs : ReplaceArgs
    {
        public int Index { get; set; } // Chi xoa phan tu xuat hien thu i
    }

    public class Replace : StringOperation
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        public override string Operate(string origin)
        {
            var args = Args as ReplaceArgs;
            var from = args.From;
            var to = args.To;

            return origin.Replace(from, to);
        }

        public override StringOperation Clone()
        {
            var oldArgs = Args as ReplaceArgs;
            return new Replace()
            {
                Args = new ReplaceArgs()
                {
                    From = oldArgs.From,
                    To = oldArgs.To
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

        public override string Name => "Replace";

        public override string Type => "Replace";
        public override string Description
        {
            get
            {
                var args = Args as ReplaceArgs;
                return $"Replace from {args.From} to {args.To}";
            }
        }
    }



    public class UltraReplaceOperation : StringOperation
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public override string Operate(string origin)
        {
            var result = "";

            var args = Args as UltraReplaceArgs;
            var from = args.From;
            var to = args.To;
            var index = args.Index;

            var currentIndex = -1;
            var startPosition = 0; // Tim tu dau chuoi
            var foundPos = -1;

            do
            {
                foundPos = origin.IndexOf(from, startPosition);
                if (foundPos != -1) // Tim thay
                {
                    currentIndex++;


                    if (currentIndex == index)
                    {
                        // Đã tìm thấy chuỗi cần tìm tại vị trí thứ index
                        // Bắt đầu thay thế
                        // :ấy phần đầu
                        result = origin.Substring(0, foundPos);
                        result += to;
                        result += origin.Substring(foundPos + from.Length,
                            origin.Length - (foundPos + from.Length));
                    }
                    else
                    {
                        startPosition = foundPos + from.Length;
                    }
                }
            } while (foundPos != -1);

            return result;
        }

        public override StringOperation Clone()
        {

            var oldArgs = Args as UltraReplaceArgs;
            return new UltraReplaceOperation()
            {
                Args = new UltraReplaceArgs()
                {
                    From = oldArgs.From,
                    To = oldArgs.To,
                    Index = oldArgs.Index
                }
            };
        }

        public override string Name => "Ultra Replace";

        public override string Type => "UltraReplace";

        public override void Config()
        {
            //var screen = new UltraReplaceConfigDialog(Args);
            //if (screen.ShowDialog() == true)
            //{
            //    PropertyChanged?.Invoke(this,
            //        new PropertyChangedEventArgs("Description"));
            //}
        }

        public override string Description
        {
            get
            {
                var args = Args as UltraReplaceArgs;
                return $"Replace from {args.From} to {args.To} using index {args.Index}";
            }
        }
    }
}
