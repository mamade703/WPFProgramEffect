using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Serilog;

namespace WPFProgramEffect.ViewModels
{
    public class PrismWindowViewModel:BindableBase
    {
        
        ILogger _logger;
        public PrismWindowViewModel(IRegionManager regionManager, ILogger logger)
        {
            _logger = logger;
            MyRegionManager = regionManager;
        }

        

        //C# 7.0
        private IRegionManager myRegionManager;
        public IRegionManager MyRegionManager { get=> myRegionManager; set => myRegionManager = value; }

        private DelegateCommand<string> normalNavigateCommand;
        public DelegateCommand<string> NormalNavigateCommand =>
            normalNavigateCommand ?? (normalNavigateCommand = new DelegateCommand<string>(ExecuteNormalNavigateCommand));

        void ExecuteNormalNavigateCommand(string parameter)
        {
            //Xaml中名字设置
            //1.直接使用
            //2.资源里定义，<sys:Sring x:Key="content" value=""/>, 绑定{StaticResource content}
            //3.代码 {x:Static app:AppModule.PrismWindowRegionLeft}
            //4.可以在ViewModel中定义，

            MyRegionManager.RequestNavigate(AppModule.PrismWindowRegionLeft, parameter, p =>
            {
                _logger.Debug("{@p}", p);
            });

            //MyRegionManager.RequestNavigate("LeftContent", parameter);
        }


        private DelegateCommand<string> addNavigateCommand;
        public DelegateCommand<string> AddNavigateCommand =>
            addNavigateCommand ?? (addNavigateCommand = new DelegateCommand<string>(ExecuteAddNavigateCommand));

        void ExecuteAddNavigateCommand(string parameter)
        {
            NavigationParameters items = new NavigationParameters();
            items.Add("Title", parameter);
            MyRegionManager.RequestNavigate(AppModule.PrismWindowRegionRight, parameter, items);
        }
    }
}
