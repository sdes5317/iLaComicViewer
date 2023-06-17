using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace iLaComicViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewer = FindName(nameof(MainScroller)) as ScrollViewer;
            ViewModel = new ImageLoadViewModel();
            DataContext = this;
        }

        public ImageLoadViewModel ViewModel { get; }
        public ICommand OpenCommand => new ActionCommand(Open);

        private void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var selectedFilePaths = openFileDialog.FileNames;

                ViewModel.ImagePaths.Clear();
                ViewModel.AddImagesAsync(selectedFilePaths);
            }
            else
            {
                // Do nothing.
            }
        }

        private void ScrollViewer_FileDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
                e.Handled = true;

                ViewModel.ImagePaths.Clear();
                var a = e.Data.GetFormats();
                var paths = (string[])e.Data.GetData("FileDrop", true);
                paths = PathHelpers.ResolveFolderOrFilePaths(paths);

                ViewModel.AddImagesAsync(paths);
            }
        }
    }
}
