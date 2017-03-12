using RestComXamarin.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestComXamarin.ViewModels
{
    public class CarViewModel : INotifyPropertyChanged
    {
        private bool Busy;
        public bool IsBusy
        {
            get
            {
                return Busy;
            }
            set
            {
                Busy = value;
                OnPropertyChanged();
                GetCarsCommand.ChangeCanExecute();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Car> Car { get; set; }
        public Command GetCarsCommand { get; set; }

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]
                                           string propertyName = null) => PropertyChanged?.Invoke(this,
                                           new PropertyChangedEventArgs(propertyName));

        public CarViewModel()
        {
            Car = new ObservableCollection<Models.Car>();
            GetCarsCommand = new Command(async () => await GetCars(), () => !IsBusy);
        }
        async Task GetCars()
        {
            if (!IsBusy)
            {
                Exception error = null;
                try
                {
                    IsBusy = true;
                    var Repositorio = new Repository();
                    var Items = await Repositorio.GetCars();

                    Car.Clear();

                    foreach(var Cars in Items)
                    {
                        Car.Add(Cars);
                    }
                }
                catch(Exception ex)
                {
                    error = ex;
                }
                finally
                {
                    if(error != null)
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", error.Message, "OK");
                    }
                    IsBusy = false;
                }
            }
        }
        
    }
}
