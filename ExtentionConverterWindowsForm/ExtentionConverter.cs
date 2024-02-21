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

namespace ExtentionConverterWindowsForm
{
    public partial class ExtentionConverter : Form
    {
        string defaultPath = "C:\\Users\\sadra\\Downloads";
        string defaultExtention = "png";

        public ExtentionConverter()
        {
            InitializeComponent();
            pathTextBox.Text = defaultPath;
            extentionTextBox.Text = defaultExtention;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string directoryPath = pathTextBox.Text;
            string newExtension = extentionTextBox.Text;

            if (string.IsNullOrEmpty(directoryPath))
            {
                MessageBox.Show("Please enter a directory path.");
                return;
            }

            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show("Directory not found.");
                return;
            }

            try
            {
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    string filename = Path.GetFileNameWithoutExtension(file);
                    string newFilePath = Path.Combine(directoryPath, filename + "." + newExtension);
                    File.Move(file, newFilePath);
                }
                Console.WriteLine("File extensions changed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

  
    }
}
