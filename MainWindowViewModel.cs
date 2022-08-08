using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProgramEffect
{
    public class MainWindowViewModel:BindableBase
    {
        public MainWindowViewModel()
        {
            title = "有效使用WPF编程";
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

    }
}
