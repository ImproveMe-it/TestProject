using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TestProject
{
    public class TestModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private View _currentContent;
        public View CurrentContent
        {
            get
            {
                return _currentContent;
            }

            set
            {
                _currentContent = value;        
                NotifyPropertyChanged(nameof(CurrentContent));
            }
        }

        public TestModel(View view)
        {
            this.CurrentContent = view;
        }

        public virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
