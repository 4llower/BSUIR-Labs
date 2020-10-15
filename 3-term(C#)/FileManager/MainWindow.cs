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
using System.Windows.Forms.VisualStyles;

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

                string lastValue = _leftPath;
                try
                {
                    _leftPath = value;
                    DirectoriesWorker.UpdateDirectoriesListByPath(LeftDirectoryView, _leftPath, LeftFilesHiddenCheck);
                }
                catch (Exception)
                {
                    _leftPath = lastValue;
                    MessageBox.Show(Exceptions.AccessError);
                }
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
                string lastValue = _rightPath;
                try
                {
                    _rightPath = value;
                    DirectoriesWorker.UpdateDirectoriesListByPath(RightDirectoryView, _rightPath, LeftFilesHiddenCheck);
                }
                catch (Exception)
                {
                    _rightPath = lastValue;
                    MessageBox.Show(Exceptions.AccessError);
                }
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
                if (selectedItem[0] == '/')
                {
                    LeftPath += selectedItem;
                } else
                {
                    try
                    {
                        var currentWindow = new EditWindow(LeftPath + "/" + selectedItem);
                        currentWindow.Show();
                    } 
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
                if (selectedItem[0] == '/')
                {
                    RightPath += selectedItem;
                } else
                {
                    var currentWindow = new EditWindow(LeftPath + "/" + selectedItem);
                    currentWindow.Show();
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

        private void MoveButton_Click(object sender, EventArgs e)
        {
            int selected = LeftDirectoryView.SelectedIndex;

            if (selected <= 0)
            {
                MessageBox.Show(Exceptions.NotSelectedError);
                return;
            }

            string nameSelected = (string)LeftDirectoryView.Items[selected];

            try
            {

                DirectoriesWorker.MoveFromPathToPath(LeftPath + (nameSelected[0] == '/' ? "" : "/") + nameSelected,
                                                     RightPath + (nameSelected[0] == '/' ? "" : "/") + nameSelected);
                MessageBox.Show("Удачно перемещено");
            } 
            catch (Exception)
            {
                MessageBox.Show(Exceptions.NotInOneDiskError);
            }

            LeftPath = LeftPath;
            RightPath = RightPath;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int selected = LeftDirectoryView.SelectedIndex;

            if (selected <= 0)
            {
                MessageBox.Show(Exceptions.NotSelectedError);
                return;
            }

            string nameSelected = (string)LeftDirectoryView.Items[selected];

            DirectoriesWorker.Delete(LeftPath + (nameSelected[0] == '/' ? "" : "/") + nameSelected);
            MessageBox.Show("Удачно удалено");


            LeftPath = LeftPath;
            RightPath = RightPath;
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            int selected = LeftDirectoryView.SelectedIndex;

            if (selected <= 0)
            {
                MessageBox.Show(Exceptions.NotSelectedError);
                return;
            }

            string nameSelected = (string)LeftDirectoryView.Items[selected];

            try
            {
                DirectoriesWorker.Copy(LeftPath + (nameSelected[0] == '/' ? "" : "/") + nameSelected,
                                                     RightPath + (nameSelected[0] == '/' ? "" : "/") + nameSelected);
                MessageBox.Show("Удачно скопировано");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LeftPath = LeftPath;
            RightPath = RightPath;
        }

        private void SwapButton_Click(object sender, EventArgs e)
        {
            string temp = LeftPath;
            LeftPath = RightPath;
            RightPath = temp;
        }

        private void CompressButton_Click(object sender, EventArgs e)
        {
            int selected = LeftDirectoryView.SelectedIndex;

            if (selected <= 0)
            {
                MessageBox.Show(Exceptions.NotSelectedError);
                return;
            }

            string nameSelected = (string)LeftDirectoryView.Items[selected];

            try
            {
                DirectoriesWorker.Zip(LeftPath + (nameSelected[0] == '/' ? "" : "/") + nameSelected, LeftPath + "/" + nameSelected + ".gzip");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            LeftPath = LeftPath;
            RightPath = RightPath;
        }

        private void DecompressButton_Click(object sender, EventArgs e)
        {
            int selected = LeftDirectoryView.SelectedIndex;

            if (selected <= 0)
            {
                MessageBox.Show(Exceptions.NotSelectedError);
                return;
            }

            string nameSelected = (string)LeftDirectoryView.Items[selected];

            try
            {
                DirectoriesWorker.UnZip(LeftPath + (nameSelected[0] == '/' ? "" : "/") + nameSelected, 
                                        LeftPath + "/" + nameSelected.Substring(0, nameSelected.Length - 4));
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LeftPath = LeftPath;
            RightPath = RightPath;
        }
    }
}
