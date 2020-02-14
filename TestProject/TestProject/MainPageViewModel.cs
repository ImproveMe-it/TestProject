using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TestProject
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation;

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


            Label label1 = new Label();
            label1.Text = "Page 1";
            Label label2 = new Label();
            label2.Text = "Page 2";
            Label label3 = new Label();
            label3.Text = "Page 3";

            StackLayout stackL1 = new StackLayout();
            stackL1.Margin = new Thickness(25);
            stackL1.BackgroundColor = Color.Red;


            StackLayout stackL2 = new StackLayout();
            stackL2.Margin = new Thickness(25);
            stackL2.BackgroundColor = Color.Blue;

            Button bt1 = new Button();
            bt1.Text = "Navigation";
            INavigation myNav = myNavigation;
            bt1.Clicked += (sender, args) =>
            {
                myNav.PushAsync(new NavPage());
            };
            stackL1.Children.Add(label1);
            stackL1.Children.Add(bt1);

            stackL2.Children.Add(label2);

            Models.Add(new TestModel(stackL1));
            Models.Add(new TestModel(stackL2));
            Models.Add(new TestModel(label3));
        }


        public virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
