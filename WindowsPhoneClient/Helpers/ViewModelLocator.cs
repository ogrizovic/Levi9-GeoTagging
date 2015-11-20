using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WindowsPhoneClient.ViewModel;

namespace WindowsPhoneClient.Helpers
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<CheckInPageViewModel>();
        }

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }

        public CheckInPageViewModel CheckInPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CheckInPageViewModel>();
            }
        }
    }
}