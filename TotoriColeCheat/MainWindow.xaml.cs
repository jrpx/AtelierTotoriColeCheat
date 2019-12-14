using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TotoriColeCheat
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();


            openFileDialog1.Title = "(steam directory)\\UserData\\(your steam id)\\936180\\Remote\\SAVEDATA";
            openFileDialog1.DefaultExt = "";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                if (radiobutton_400k.IsChecked.GetValueOrDefault(false))
                {
                    modifyFile(openFileDialog1.FileName, 0x80, 0x1A, 0x06); 
                }
                else
                {
                    modifyFile(openFileDialog1.FileName, 0xC0, 0x27, 0x09);
                }
            }
        }

        private void modifyFile(string filename, byte first, byte second, byte third)
        {
            FileStream fileStream = new System.IO.FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            fileStream.Seek(0xB3FC, SeekOrigin.Begin);

            fileStream.WriteByte(first);
            fileStream.WriteByte(second);
            fileStream.WriteByte(third);

            fileStream.Close();
            MessageBox.Show("Hopefully save file " + filename + " will be modified with the new value. Have fun!", "Done!", MessageBoxButton.OK);
        }
    }
}
