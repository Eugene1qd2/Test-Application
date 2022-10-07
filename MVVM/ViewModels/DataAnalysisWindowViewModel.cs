using DataAnalysisApplication.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAnalysisApplication.Repositories;
using LiveCharts.Defaults;
using LiveCharts;
using LiveCharts.Configurations;
using System.Windows.Media;

namespace DataAnalysisApplication.MVVM.ViewModels
{
    class DataAnalysisWindowViewModel : ViewModelBase
    {
        private List<List<UserRaceModel>> races;
        private List<UserModel> _users;
        private int _days;
        private int _maxSteps;

        private ChartValues<ObservablePoint> _sineGraphValues;

        private UserModel _selectedItem;

        public UserModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();

                ChangeSineGraphValues();
            }
        }

        public ChartValues<ObservablePoint> SineGraphValues 
        {
            get
            {
                return _sineGraphValues;
            }
            private set 
            {
                _sineGraphValues = value;
                OnPropertyChanged();
            }
        }

        public int Days
        {
            get
            {
                return _days;
            }
            set
            {
                _days = value;
                OnPropertyChanged();
            }
        }

        public int MaxSteps
        {
            get
            {
                return _maxSteps;
            }
            set
            {
                _maxSteps = value;
                OnPropertyChanged();
            }
        }

        public List<UserModel> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public DataAnalysisWindowViewModel()
        {
            Days = 30;
            MaxSteps = 100000;
            races = UserRepository.GetRaces(Days);
            Users = UserRepository.GetUsers(races,Days);
            SelectedItem = Users[0];
            ChangeSineGraphValues();
        }

        private void ChangeSineGraphValues()
        {
            UserModel SelectedUser = Users.Where(x=> x.User == SelectedItem.User).First();
            MaxSteps = SelectedUser.BestResult + 10000;
            var chart= new ChartValues<ObservablePoint>();
            for (int x = 0; x < Days; x++)
            {
                var point = new ObservablePoint()
                {
                    X = x + 1,
                    Y = SelectedUser.Steps.ContainsKey(x) ? SelectedUser.Steps[x] : 0
                };

                chart.Add(point);
            }
            SineGraphValues = chart;

        }

    }
}
