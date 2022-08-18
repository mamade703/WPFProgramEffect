using Prism.DryIoc;
using Prism.Ioc;
using Serilog;
using Serilog.Sinks.File;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFProgramEffect.Service;
using WPFProgramEffect.Views;

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
            _logger.Debug("输出{@obj}",obj);

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
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}
