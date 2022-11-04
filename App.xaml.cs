using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
using Serilog;
using Serilog.Sinks.File;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using WPFProgramEffect.Service;
using WPFProgramEffect.ViewModels;
using WPFProgramEffect.Views;
using WPFProgramEffect.ViewUI;

namespace WPFProgramEffect
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        ILogger _logger;
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Minute)
                .CreateLogger();

            _logger.Debug("app start 1");
            _logger.Information("app start 2");

            int a = 5;
            int b = 3;
            _logger.Debug("a dividing b {a} by {b}", a, b);

            var obj = new { Name = "刘", Role = ".net " };
            var obj2 = new { Name = "王", Role = ".net " };

            _logger.Debug("输出{obj} {Elapsed} ms", obj);
            _logger.Debug("输出{obj1} {Elapsed} ms", obj);

            //{属于占位} 输出顺序按照后边的参数顺序来。
            //使用@ 表明使用Json格式输出
            //{好记住}
            _logger.Debug("输出{@obj2} {{@obj}} {Elapsed} ms", obj, obj2);

            this.ShutdownMode = ShutdownMode.OnMainWindowClose;

        }
        /// <summary>
        /// thread exception
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _logger.Error(e.ExceptionObject as Exception, "currentDomain ");
        }

        /// <summary>
        /// task exception
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            _logger.Error(e.Exception, "TaskScheduler_UnobservedTaskException");
            e.SetObserved();
        }

        /// <summary>
        /// ui excption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            _logger.Error(e.Exception, "App_DispatcherUnhandledException");
            e.Handled = true;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<ILogger>(_logger);

            containerRegistry.Register<ICourseService, CourseService>();
            //containerRegistry.RegisterSingleton<ICourseService, CourseService>();

            containerRegistry.Register<TransparentWindow>();
            containerRegistry.Register<TransparentChromeWindow>();
            containerRegistry.Register<MahAppWindow>();

            containerRegistry.Register<PrismWindow>();

            //View和ViewModel自动关联
            //xmlns: prism = "http://prismlibrary.com/"
            //prism: ViewModelLocator.AutoWireViewModel = "True"
            //1.如果不在有效的命名空间下(相同的或者ViewModel下的)，需要指定ViewModel

            containerRegistry.RegisterForNavigation<TeacherView, TeacherViewModel>();
            containerRegistry.RegisterForNavigation<HelperView>();
            
            //2.或者用下面的语句做关联
            //ViewModelLocationProvider.Register<TeacherView, TeacherViewModel>();
        }

        protected override  Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }


        
    }
}
