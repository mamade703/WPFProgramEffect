using ImageProcessor;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WPFProgramEffect.Views
{
    /// <summary>
    /// ImageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ImageWindow : Window
    {
        public ImageWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var baseDir =  AppDomain.CurrentDomain.BaseDirectory;
            var imageFile = System.IO.Path.Combine(baseDir, $@"image\1.jpg");
            var rotateFile = System.IO.Path.Combine(baseDir, $@"image\1_rotate.jpg");

            CreateImage(imageFile);

            //去掉exif信息
            var newImageFac = new ImageFactory(false);

            //根据exif信息，自动旋转
            var fac1 = newImageFac.Load(imageFile).AutoRotate().Quality(70).Save(rotateFile);

            wrapPannel.Children.Add(CreateImage(imageFile));
            wrapPannel.Children.Add(CreateImage(rotateFile));

        }

        private Image CreateImage(string imageFile)
        {
            var bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(imageFile, UriKind.RelativeOrAbsolute);

            bool isLocal = System.IO.File.Exists(imageFile);
            if (isLocal)
            {
                bi.CacheOption = BitmapCacheOption.OnLoad;//如果不是本地文件，使用缓存将出错
            }
            bi.EndInit();

            var image = new Image();
            image.Source = bi;
            image.Width = 400;
            image.Height = 300;
            return image;
        }
    }
}
