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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFProgramEffect
{
    /// <summary>
    /// TeacherView.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherView : UserControl
    {
        public TeacherView()
        {
            //需要在同一命名空间下
            //xmlns: prism = "http://prismlibrary.com/"
            //prism:ViewModelLocator.AutoWireViewModel = "True"

            InitializeComponent();
        }
    }
}
