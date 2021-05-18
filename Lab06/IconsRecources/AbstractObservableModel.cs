using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IconsRecources
{
    public abstract class AbstractObservableModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class LangItemViewModel : AbstractObservableModel
    {
        public LangItemViewModel(string langCode, ICommand command) : this(false, langCode, command) { }

        public LangItemViewModel(bool active, string langCode, ICommand commad)
        {
            Active = active;
            Culture = new CultureInfo(langCode);
            Command = commad;
        }

        private bool active;
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                if (active != value)
                {
                    active = value;
                    OnPropertyChanged();
                }
            }
        }

        private CultureInfo culture;

        public CultureInfo Culture
        {
            get
            {
                return culture;
            }
            set
            {
                if (value != null && !value.Equals(culture))
                {
                    culture = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICommand command;

        public ICommand Command
        {
            get
            {
                return command;
            }

            set
            {
                command = value;
                OnPropertyChanged();
            }
        }
    }
}
