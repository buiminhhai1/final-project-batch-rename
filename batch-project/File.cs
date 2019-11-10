using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace p1
{
    class File: INotifyPropertyChanged
    {
        private string _filename;
        private string _newfilename;
        private string _path;
        private string _status;

        public string Filename
        {
            get => _filename;
            set
            {
                _filename = value;
                onPropertyChange("FileName");
            }
        }

        public string Newfilename
        {
            get => _newfilename;
            set
            {
                _newfilename = value;

                onPropertyChange("NewFilename");
            }
        }

        public string Path
        {
            get => _path;
            set
            {
                _path = value;

                onPropertyChange("Path");
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;

                onPropertyChange("Status");
            }
        }


        public File Clone()
        {
            return new File()
            {
                Filename = this._filename,
                Newfilename = this._newfilename,
                Path = this._path,
                Status = this._status
            };
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChange(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
