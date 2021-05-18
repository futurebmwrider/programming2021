using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Collections.ObjectModel;
using System.Globalization;
using IconsRecources;

namespace SimpleTxtViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public ObservableCollection<LangItemViewModel> SupportedLanguages { get; } = new ObservableCollection<LangItemViewModel>();


        ObservableCollection<ImageData> items = new ObservableCollection<ImageData>();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var cmd = new RelayCommand<string>(ChangeLocale);
            SupportedLanguages.Add(new LangItemViewModel(true, "en-US", cmd));
            SupportedLanguages.Add(new LangItemViewModel("uk-UA", cmd));
            SupportedLanguages.Add(new LangItemViewModel("ru-RU", cmd));
        }

        private void ChangeLocale(String localeCode)
        {
            ResourceDictionary dict = new ResourceDictionary();
            try
            {
                dict.Source = new Uri(String.Format("Lang/lang.{0}.xaml", localeCode), UriKind.Relative);

            }
            catch (Exception ex)
            {
                dict.Source = new Uri("Lang/lang.xaml", UriKind.Relative);
            }

            setupLocaleResources(dict);
        }

        private void setupLocaleResources(ResourceDictionary resource)
        {
            ResourceDictionary currentDict = (
                from d in Application.Current.Resources.MergedDictionaries
                where d.Source != null && d.Source.OriginalString.StartsWith("Lang/lang.")
                select d).First();

            if (currentDict != null)
            {
                int idx = Application.Current.Resources.MergedDictionaries.IndexOf(currentDict);
                Application.Current.Resources.MergedDictionaries.Remove(currentDict);
                Application.Current.Resources.MergedDictionaries.Insert(idx, resource);
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(resource);
            }
        }
        private void loadFile(String fileName)
        {
            try
            {
                Uri fileUri = new Uri(fileName);
                items.Add(new ImageData() {
                    Name = System.IO.Path.GetFileName(fileName),
                    Path = fileName,
                    Time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() });
                HistoryData.ItemsSource = items;
                ImageViewer.Source = new BitmapImage(fileUri);
            }
            catch
            {
                var Exc = MessageBox.Show("Ivalid file type!", "Exception", MessageBoxButton.OK);
                items.Remove(items[items.Count - 1]);
            }
        }
        
        private void openCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var showResult = ofd.ShowDialog();
            if(!showResult.HasValue || !showResult.Value)
            {
                return;
            }
            loadFile(ofd.FileName);
        }

        private void exitCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Closing...", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ImageViewer.Source = null;
        }
        private void HistoryData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int itemIndex = HistoryData.SelectedIndex;
            Uri fileUri = new Uri(items[itemIndex].Path);
            ImageViewer.Source = new BitmapImage(fileUri);
        }
    }
}
