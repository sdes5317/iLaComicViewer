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
            DataContext = ViewModel;
        }

        public ImageLoadViewModel ViewModel { get; }

        private void ScrollViewer_FileDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
                e.Handled = true;

                ViewModel.ImagePaths.Clear();
                var a = e.Data.GetFormats();
                var paths = (string[])e.Data.GetData("FileDrop", true);

                var isSingleAndIsDirectory = paths.Length == 1 && (File.GetAttributes(paths.First()) & FileAttributes.Directory) > 0;
                if (isSingleAndIsDirectory)
                {
                    paths = Directory.GetFiles(paths.First());
                }

                ViewModel.AddImagesAsync(paths);
            }
        }
    }
}
