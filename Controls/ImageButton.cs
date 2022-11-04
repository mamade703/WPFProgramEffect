using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFProgramEffect.Controls
{
    public class ImageButton:Button
    {
        public string NormalImage
        { 
            get { return (string)GetValue(NormalImageProperty); }
            set { SetValue(NormalImageProperty, value); } 
        }

        public static readonly DependencyProperty NormalImageProperty =
            DependencyProperty.Register("NormalImage", typeof(string), typeof(ImageButton),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsArrange,
                    ImageSourceChanged));

        public string HoverImage
        {
            get { return (string)GetValue(HoverImageProperty); }
            set { SetValue(HoverImageProperty, value); }
        }

        public static readonly DependencyProperty HoverImageProperty =
            DependencyProperty.Register("HoverImage", typeof(string), typeof(ImageButton),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsArrange,
                    ImageSourceChanged));

        public string PressedImage
        {
            get { return (string)GetValue(PressedImageProperty); }
            set { SetValue(PressedImageProperty, value); }
        }

        public static readonly DependencyProperty PressedImageProperty =
            DependencyProperty.Register("PressedImage", typeof(string), typeof(ImageButton),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsArrange,
                    ImageSourceChanged));

        public string DisabledImage
        {
            get { return (string)GetValue(DisabledImageProperty); }
            set { SetValue(DisabledImageProperty, value); }
        }

        public static readonly DependencyProperty DisabledImageProperty =
            DependencyProperty.Register("DisabledImage", typeof(string), typeof(ImageButton),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsArrange,
                    ImageSourceChanged));

        private static void ImageSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Application.GetResourceStream(new Uri("pack://application:,,," + (string)e.NewValue));
        }

    }
}
