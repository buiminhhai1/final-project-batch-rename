using System;
using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using System.IO;
using WinForms = System.Windows.Forms;
using Path = System.IO.Path;

namespace p1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
  

        public MainWindow()
        {
            InitializeComponent();
        }



        BindingList<StringOperation> actions = new BindingList<StringOperation>();

        List<StringOperation> prototypes = new List<StringOperation>();
        List<File> listFileErrors = new List<File>();
        List<Folder> listFolderErrors = new List<Folder>();

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            var action = prototypesComboBox.SelectedItem as StringOperation;
            actions.Add(action);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
        
            foreach(File file in filesList.Items)
            {
                string tempName = file.Filename;
                foreach (var action in actions)
                {
                    tempName = action.Operate(tempName);
                }
                file.Newfilename = tempName;
                
            }

        }

        private void changeFileName(List<File> files)
        {
            foreach(File file in files)
            {
                string dir = Path.GetDirectoryName(file.Path);
                try
                {
                    System.IO.File.Move(dir + "\\" + file.Filename, dir + "\\" + file.Newfilename);
                    file.Status = "success";
                }
                catch (Exception)
                {
                    file.Status = "error";
                }
                finally
                {
                    listFileErrors.Add(file);
                }
            }

            if (listFileErrors.Count > 0)
            {
                foreach (File file in listFileErrors)
                {
                    int index = 1;
                    string dir = Path.GetDirectoryName(file.Path);
                    string extension = Path.GetExtension(file.Newfilename);
                    string originName = file.Newfilename.Substring(0, file.Newfilename.Length - extension.Length);
                    while (System.IO.File.Exists(dir + "\\" + originName + index.ToString() + extension))
                    {
                        index++;
                    }
                    file.Newfilename = originName + index.ToString() + extension;

                    try
                    {
                        System.IO.File.Move(dir + "\\" + file.Filename, dir + "\\" + file.Newfilename);
                    }
                    catch (Exception)
                    {
                        //
                    }
                }

            }
            listFileErrors.Clear();
            //foreach (File file in filesList.Items)
            //{

            //}
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            var screen = new Microsoft.Win32.OpenFileDialog();
            screen.Multiselect = true;
            if (screen.ShowDialog() == true)
            {
                foreach (var file in screen.FileNames)
                {
                    foreach (string filename in screen.FileNames)
                    {
                        File _file = new File();
                        _file.Filename = Path.GetFileName(filename);
                        _file.Path = file;
                        filesList.Items.Add(_file);
                    }
                }
            }
        }

        private void AddFolder_Click(object sender, RoutedEventArgs e)
        {
            string directory;
            var screen = new WinForms.FolderBrowserDialog();
            if (screen.ShowDialog() == WinForms.DialogResult.OK)
            {
                directory = screen.SelectedPath;
                string[] subDirectory = Directory.GetDirectories(directory);

                foreach (var dir in subDirectory)
                {
                    foldersList.Items.Add(new Folder()
                    {
                        Foldername = dir.Substring(directory.Length + 1),
                        Path = dir
                    });
                }
            }
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            var index = operationsListBox.SelectedIndex;

            if (index >= 0)
            {
                var temp = actions[index];
                actions.RemoveAt(index);
                actions.Insert(index - 1, temp);
            }
        }

        private void configPrototypes()
        {
            prototypes.Add(new Replace()
            {
                Args = new ReplaceArgs()
                {
                    From = "a",
                    To = "b"
                }
            });
            prototypes.Add(new NewCase()
            {
                Args = new NewCaseArgs()
                {
                    Option = 1
                }
            });
            prototypes.Add(new FullnameNormalize());

            prototypes.Add(new Move()
            {
                Args = new MoveArgs()
                {
                    Option = 1
                }
            });

            prototypes.Add(new Guid());


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            configPrototypes();
           
            operationsListBox.ItemsSource = actions;
            prototypesComboBox.ItemsSource = prototypes;


        }
    }
}
