using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProgramEffect.ViewUI
{
    /// <summary>
    /// https://www.cnblogs.com/hicolin/p/8742693.html
    /// 
    /// INavigationAware 提供导航时的相关处理，不是必须
    /// IConfirmNavigationRequest,是否允许导航
    /// IRegionMemberLifetime ，导航生命周期，KeepAlive=false，允许上一个导航活着
    /// IRegionNavigationJournal，浏览器的导航，_journal.GoBack();
    /// </summary>
    public class HelperViewModel:BindableBase, INavigationAware
    {
        public HelperViewModel()
        {
            Title = "Helper";
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
            return true;//接受导航定位到原来的Page，否则会创建新的对象。 
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
    }
}
