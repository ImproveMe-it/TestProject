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
        bool animateCV = false;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm = new MainPageViewModel(Navigation);
            scrP = ScrollToPosition.Center;
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            MyCarouselView.ScrollTo(0, -1, scrP, true);
        }

        private void Button_Clicked2(object sender, EventArgs e)
        {
            //MyCarouselView.ScrollTo(1, position: (ScrollToPosition)2, animate: false);
            scrP = ScrollToPosition.Start;
            MyCarouselView.ScrollTo(1, -1, scrP, false);


        }
        private void Button_Clicked3(object sender, EventArgs e)
        {
            scrP = ScrollToPosition.End;
            MyCarouselView.ScrollTo(2, -1, scrP, false);
        }

        private void MyCarouselView_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            //App.Current.MainPage.DisplayAlert("","Site changed","ok");
        }
    }
}
