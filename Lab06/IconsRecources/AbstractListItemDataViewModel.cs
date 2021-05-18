using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconsRecources
{
    public abstract class AbstractListItemDataViewModel<T> : AbstractObservableModel
    {
        private string label;
        public string Label
        {
            get
            {
                return label;
            }
            set
            {
                label = value;
                OnPropertyChanged();
            }
        }

        private T data;
        public T Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }
    }
}
