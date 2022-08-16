using Prism.Commands;
using Prism.Mvvm;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFProgramEffect.Service;

namespace WPFProgramEffect
{
    /// <summary>
    /// prism 绑定会根据文件夹寻找
    /// WpfApp1.Views.MainWindow => WpfApp1.ViewModels.MainWindowViewModel
    /// WpfApp1.Views.OtherView => WpfApp1.ViewModels.OtherViewModel
    /// </summary>
    public class MainWindowViewModel:BindableBase
    {
        private ILogger _logger;
        private ICourseService _courseService;

        public MainWindowViewModel(ILogger logger, ICourseService courseService)
        {
            title = "有效使用WPF编程";

            _logger = logger;
            _courseService = courseService;
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        /// <summary>
        /// 通过绑定事件触发器
        /// xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
        /// i:Interaction.Triggers 来实现，
        /// </summary>
        private DelegateCommand loaded;
        public DelegateCommand OnLoaded =>
            loaded ?? (loaded = new DelegateCommand(ExecuteOnLoaded));
        void ExecuteOnLoaded()
        {
            _logger.Information("Onloaded");
        }
        
    }
}
