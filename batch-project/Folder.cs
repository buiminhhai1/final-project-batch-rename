using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using Microsoft.Win32;

namespace p1
{
    public class Folder : INotifyPropertyChanged
    {
        private string _folder;
        private string _newfolder;
        private string _path;
        private string _status;

        public string Foldername
        {
            get => _folder; set
            {
                _folder = value;
                onPropertyChange("Folder");
            }
        }

        public string Newfoldername
        {
            get => _newfolder;
            set
            {
                _newfolder = value;
                onPropertyChange("Newfoldername");
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
        
        public Folder Clone()
        {
            return new Folder()
            {
                Foldername = this._folder,
                Newfoldername = this._newfolder,
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
