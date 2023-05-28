using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace iLaComicViewer
{
    public partial class ImageLoadViewModel: ObservableObject
    {

        public ObservableCollection<string> ImagePaths { get; set; }

        public ICommand DropCommand { get; private set; }

        public ImageLoadViewModel()
        {
            ImagePaths = new ObservableCollection<string>();
            DropCommand = new RelayCommand<DragEventArgs>(e => OnDrop(e));
        }

        private void OnDrop(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] folderPaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string folderPath in folderPaths)
                {
                    string[] imageFiles = Directory.GetFiles(folderPath, "*.jpg");
                    foreach (string imagePath in imageFiles)
                    {
                        ImagePaths.Add(imagePath);
                    }
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //string[] folderPaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                //foreach (string folderPath in folderPaths)
                //{
                //    string[] imageFiles = Directory.GetFiles(folderPath, "*.jpg");
                //    foreach (string imagePath in imageFiles)
                //    {
                //        ImagePaths.Add(imagePath);
                //    }
                //}
            }
        }
    }
}
