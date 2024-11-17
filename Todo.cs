using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_list
{
    public class Todo : INotifyPropertyChanged
    {
        private int id;
        public int ids
        {
            get => id;
            set
            {
                id = value;
                NotifyPropertyChanged();
            }

        }
        private string title;
        public string titles
        {
            get => title;
            set
            {
                title = value;
                NotifyPropertyChanged();
            }
        }
        private string description;
        public string descriptions
        {
            get => description;
            set
            {
                description = value;
                NotifyPropertyChanged();
            }
        }



        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
