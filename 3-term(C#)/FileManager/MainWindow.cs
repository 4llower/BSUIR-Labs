using FileManager.Types;
using FileManager.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class MainWindow : Form
    {
        private string _leftPath;
        private string _rightPath;
        private bool _leftFilesHidden;
        private bool _rightFilesHidden;
        
        public bool LeftFilesHiddenCheck
        {
            get
            {
                return _leftFilesHidden;
            }
            set
            {
                if (_leftFilesHidden != value) DirectoriesWorker.UpdateDirectoriesListByPath(LeftDirectoryView, LeftPath, value);
                _leftFilesHidden = value;
            }
        }

        public bool RightFilesHiddenCheck
        {
            get
            {
                return _rightFilesHidden;
            }
            set
            {
                if (_rightFilesHidden != value) DirectoriesWorker.UpdateDirectoriesListByPath(RightDirectoryView, RightPath, value);
                _rightFilesHidden = value;
            }
        }

        public string LeftPath
        {
            get 
            {
                return _leftPath;
            } 
            set
            {
                if (value.Length == 0) return;
                if (_leftPath != value) DirectoriesWorker.UpdateDirectoriesListByPath(LeftDirectoryView, value, LeftFilesHiddenCheck);
                _leftPath = value;
            }
        }

        public string RightPath
        {
            get 
            {
                return _rightPath;
            } 
            set
            {
                if (value.Length == 0) return;
                if (_rightPath != value) DirectoriesWorker.UpdateDirectoriesListByPath(RightDirectoryView, value, RightFilesHiddenCheck);
                _rightPath = value;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LeftDirectoryView.DoubleClick += (s, args) =>
            {
                if (LeftDirectoryView.SelectedIndex == 0)
                {
                    LeftPath = DirectoriesWorker.BackDirectory(LeftPath);
                    return;
                }
                string selectedItem = LeftDirectoryView.SelectedItem.ToString();
                if (ValidationSchema.IsDirectory(LeftPath + '/' + selectedItem))
                {
                    LeftPath += "/" + selectedItem;
                }
            };

            RightDirectoryView.DoubleClick += (s, args) =>
            {
                if (RightDirectoryView.SelectedIndex == 0)
                {
                    RightPath = DirectoriesWorker.BackDirectory(RightPath);
                    return;
                }
                string selectedItem = RightDirectoryView.SelectedItem.ToString();
                if (ValidationSchema.IsDirectory(RightPath + '/' + selectedItem))
                {
                    RightPath += "/" + selectedItem;
                }
            };
            LoadDriversToComboBoxes();   
        }

        private void LoadDriversToComboBoxes()
        {
            string[] allDrives = DriveWorker.GetAllDrives();
            foreach (var drive in allDrives)
            {
                LeftSelectDisk.Items.Add(drive);
                RightSelectDisk.Items.Add(drive);
            }
            
            try
            {
                /* If computer hasn't a directories, then throw Exception */
                LeftSelectDisk.SelectedIndex = 0;
                RightSelectDisk.SelectedIndex = 0;
            } 
            catch (Exception)
            {
                MessageBox.Show(Exceptions.CannotFindDrivesError);
            }
        }

        private void LeftSelectDisk_SelectedIndexChanged(object sender, EventArgs e)
        {
            LeftPath = LeftSelectDisk.Items[LeftSelectDisk.SelectedIndex].ToString();
        }

        private void RightSelectDisk_SelectedIndexChanged(object sender, EventArgs e)
        {
            RightPath = RightSelectDisk.Items[RightSelectDisk.SelectedIndex].ToString();
        }

        private void LeftFilesHidden_CheckedChanged(object sender, EventArgs e)
        {
            LeftFilesHiddenCheck = !LeftFilesHiddenCheck;
        }

        private void RightFilesHidden_CheckedChanged(object sender, EventArgs e)
        {
            RightFilesHiddenCheck = !RightFilesHiddenCheck;
        }

        private void LeftDirectoryView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RightDirectoryView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
