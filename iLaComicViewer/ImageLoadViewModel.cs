using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Xaml.Behaviors.Core;
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

        public ImageLoadViewModel()
        {
            ImagePaths = new ObservableCollection<string>();
        }
        public async Task AddImagesAsync(string[] paths)
        {
            foreach (var file in paths)
            {
                await Task.Delay(10);
                App.Current.Dispatcher.Invoke(() =>
                {
                    ImagePaths.Add(file);
                });
            }
        }
    }
}
