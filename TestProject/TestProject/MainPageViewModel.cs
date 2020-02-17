using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestProject
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation;

        public Command NavigateTo { get; set; }

        public CarouselView MyCarouselViewVM {get;set;}

        //private ObservableCollection<TestModel> _models;
        //private ObservableCollection<TestModel> models { get; set; } = new ObservableCollection<TestModel>();
        private ObservableCollection<TestModel> models;
        public ObservableCollection<TestModel> Models
        {
            get
            {
                if (models == null)
                {
                    return new ObservableCollection<TestModel>();
                }
                else
                {
                    return models;
                }
            }
            set
            {
                models = value;
                NotifyPropertyChanged(nameof(Models));
            }
        }


        public MainPageViewModel(INavigation myNavigation)
        {
            Models = new ObservableCollection<TestModel>();
            MyCarouselViewVM = new CarouselView();
            NavigateTo = new Command((e) => ShowView((string)e));


            List<Label> myLabels = new List<Label>();

            for(int i = 0; i < 5; i++)
            {
                Label label = new Label();
                label.Text = "View " + i;

                myLabels.Add(label);
            }


            StackLayout stackL = getNewStackLayout(Color.Red);
            stackL.Children.Add(myLabels[0]);
            Models.Add(new TestModel(stackL));
            

            stackL = getNewStackLayout(Color.Blue);
            Button bt1 = new Button();
            bt1.Text = "Navigation";
            INavigation myNav = myNavigation;
            bt1.Clicked += (sender, args) =>
            {
                myNav.PushAsync(new NavPage());
            };
            stackL.Children.Add(bt1);
            stackL.Children.Add(myLabels[1]);
            Models.Add(new TestModel(stackL));

            stackL = getNewStackLayout(Color.Green);
            stackL.Children.Add(myLabels[2]);
            Models.Add(new TestModel(stackL));

            stackL = getNewStackLayout(Color.Yellow);
            stackL.Children.Add(myLabels[3]);
            Models.Add(new TestModel(stackL));

            stackL = getNewStackLayout(Color.Purple);
            stackL.Children.Add(myLabels[4]);
            Models.Add(new TestModel(stackL));
        }

        public StackLayout getNewStackLayout(Color col)
        {
            StackLayout stackL = new StackLayout();
            stackL.Margin = new Thickness(25);
            stackL.BackgroundColor = col;
            return stackL;
        }

        public void ShowView(string viewIndex)
        {
            //MyCarouselViewVM.CurrentItem = 3;
            MyCarouselViewVM.ScrollTo(Convert.ToInt32(viewIndex), -1, ScrollToPosition.Center, false); 
            //MyCarouselViewVM.ScrollTo(3); 
        }


        public virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
