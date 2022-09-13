using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProgramEffect.ViewModels
{
    public class MahAppWindowViewModel:BindableBase
    {
        public MahAppWindowViewModel()
        {

        }

        private DelegateCommand<object> showMessage;
        public DelegateCommand<object> ShowMessage =>
            showMessage ?? (showMessage = new DelegateCommand<object>(ExecuteShowMessage));

        void ExecuteShowMessage(object parameter)
        {
           
        }

    }
}
