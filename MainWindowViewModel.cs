using Prism.Commands;
using Prism.Mvvm;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFProgramEffect.Service;
using Prism.Ioc;
using WPFProgramEffect.Views;
using System.Windows;
using ControlzEx.Theming;
using Prism.Regions;
using WPFProgramEffect.ViewModels;

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
        private IContainerProvider _container;
        private IRegionManager _regionMgr;

        public MainWindowViewModel(ILogger logger, ICourseService courseService, IContainerExtension container,
            IRegionManager regionMgr)
        {
            title = "有效使用WPF编程";

            _logger = logger;
            _courseService = courseService;
            _container = container;

            _regionMgr = regionMgr;
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string themeName;
        public string ThemeName
        {
            get { return themeName; }
            set { SetProperty(ref themeName, value); }
        }

        /// <summary>
        /// 通过绑定事件触发器
        /// xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
        /// i:Interaction.Triggers 来实现，
        /// </summary>
        private DelegateCommand<object> loaded;
        public DelegateCommand<object> OnLoaded =>
            loaded ?? (loaded = new DelegateCommand<object>(ExecuteOnLoaded));
        void ExecuteOnLoaded(object sender)
        {
            _logger.Information($"{(sender as Window)?.Title} Onloaded");
        }

        private DelegateCommand<object> openWindow;
        public DelegateCommand<object> OpenWindow =>
            openWindow ?? (openWindow = new DelegateCommand<object>(ExecuteOpenWindow));

        void ExecuteOpenWindow(object parameter)
        {
            //param button
            //直接创建就可以了
            var window = _container.Resolve<TransparentWindow>();
            window.Show();

        }
        //需要安装Prism Template pack扩展
        //使用cmdg提示
        //使用propp属性提示
        //修改名称，相关自动修改

        private DelegateCommand<object> openChromeWindow;
        public DelegateCommand<object> OpenChromeWindow =>
            openChromeWindow ?? (openChromeWindow = new DelegateCommand<object>(ExecuteOpenChromeWindow));

        void ExecuteOpenChromeWindow(object parameter)
        {
            //parameter window
            var window = _container.Resolve<TransparentChromeWindow>();
            window.Show();
        }

        private DelegateCommand<object> selectedTheme;
        public DelegateCommand<object> SelectedTheme =>
            selectedTheme ?? (selectedTheme = new DelegateCommand<object>(ExecuteSelectedTheme));

        void ExecuteSelectedTheme(object value)
        {
            if (value == null)
            {
                return;
            }
            //"Red", "Green", "Blue", "Purple", "Orange", "Lime", "Emerald",
            //"Teal", "Cyan", "Cobalt", "Indigo", "Violet", "Pink", "Magenta",
            //"Crimson", "Amber", "Yellow", "Brown", "Olive", "Steel", "Mauve", "Taupe", "Sienna"
            try
            {
                //主题帮助文档
                //https://mahapps.com/docs/themes/thememanager
                //切换主题
                //ThemeManager.Current.ChangeTheme(App.Current, $"Dark.{value.ToString()}");
                ThemeManager.Current.ChangeTheme(App.Current, $"Light.{value.ToString()}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex,"");
            }
        }


        private DelegateCommand<object> showMahAppWindow;
        public DelegateCommand<object> ShowMahAppWindow =>
            showMahAppWindow ?? (showMahAppWindow = new DelegateCommand<object>(ExecuteShowMahAppWindow));

        void ExecuteShowMahAppWindow(object parameter)
        {
            var window = _container.Resolve<MahAppWindow>();
            window.Show();
        }

        private DelegateCommand<object> showDragable;
        public DelegateCommand<object> ShowDragable =>
            showDragable ?? (showDragable = new DelegateCommand<object>(ExecuteShowDragable));

        void ExecuteShowDragable(object parameter)
        {
            //怎么直接到容器里去的?
            var window = _container.Resolve<DragableWindow>();
            window.Show();
        }

        private DelegateCommand<object> showPrismCommand;
        public DelegateCommand<object> ShowPrismCommand =>
            showPrismCommand ?? (showPrismCommand = new DelegateCommand<object>(ExecuteShowPrismCommand));

        void ExecuteShowPrismCommand(object parameter)
        {
            var window = _container.Resolve<PrismWindow>();

            //!子窗口需要设置区域管理器
            //是为了防止和程序冲突？
            //https://www.csharpcodi.com/csharp-examples/Prism.Regions.RegionManager.SetRegionManager(System.Windows.DependencyObject,%20Prism.Regions.IRegionManager)/
            var prismWndRegionMgr = _regionMgr.CreateRegionManager();
            RegionManager.SetRegionManager(window, prismWndRegionMgr);
            RegionManager.UpdateRegions();

            //有点别扭，直接用系统中的_regionMgr 
            var prismVM = window.DataContext as PrismWindowViewModel;
            if (prismVM != null)
            {
                prismVM.MyRegionManager = prismWndRegionMgr;
            }

            //直接用这个即可，把区域的名称设置的有规则些
            //RegionManager.SetRegionManager(window, _regionMgr);



            window.Show();
        }

        private DelegateCommand<object> showControlsCommand; 
        public DelegateCommand<object> ShowControlsCommand =>
            showControlsCommand ?? (showControlsCommand = new DelegateCommand<object>(ExecuteshowControlsCommand));

        void ExecuteshowControlsCommand(object parameter)
        {
            //怎么直接到容器里去的?
            var window = _container.Resolve<ControlsWindow>();
            window.Show();
        }
    }
}
