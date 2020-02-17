using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel vm;

        ScrollToPosition scrP;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm = new MainPageViewModel(Navigation);
            vm.MyCarouselViewVM = MyCarouselView;
        }


        private void MyCarouselView_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            //App.Current.MainPage.DisplayAlert("","Site changed","ok");
        }

    }
}
