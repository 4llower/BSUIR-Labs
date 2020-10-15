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
    public partial class EditWindow : Form
    {
        public EditWindow(string path)
        {
            if (!ValidationSchema.IsTextFile(path))
            {
                throw new Exception(Exceptions.IsNotTextFileError);
            }
            InitializeComponent();

            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] beforeBytes = new byte[fstream.Length];
                fstream.Read(beforeBytes, 0, beforeBytes.Length);
                TextField.Text = System.Text.Encoding.Default.GetString(beforeBytes);
            }

            TextField.TextChanged += (s, e) =>
            {
                using (FileStream fstream = new FileStream(path, FileMode.Open))
                {
                    byte[] beforeBytes = System.Text.Encoding.Default.GetBytes(TextField.Text);
                    fstream.Write(beforeBytes, 0, beforeBytes.Length);
                }
            };
        }
    }
}
