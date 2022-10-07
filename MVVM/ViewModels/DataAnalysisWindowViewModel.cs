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

        private int _selectedIndex=1;


        public ChartValues<ObservablePoint> SineGraphValues { get; private set; }

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
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                Console.WriteLine(value);
                OnPropertyChanged();

                ChangeSineGraphValues();
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

        public ICommand DisplayUserDataCommand { get; set; }
        public ICommand ChangePeriodCommand { get; set; }

        public DataAnalysisWindowViewModel()
        {
            Days = 30;
            MaxSteps = 100000;
            races = UserRepository.GetRaces(Days);
            Users = UserRepository.GetUsers(races);

            ChangeSineGraphValues();
            //DisplayUserDataCommand = new ViewModelCommand(ExecuteDisplayUserDataCommand);
            //ChangePeriodCommand = new ViewModelCommand(ExecuteChangePeriodCommand);
        }

        private void ChangeSineGraphValues()
        {
            SineGraphValues = new ChartValues<ObservablePoint>();
            UserModel SelectedUser = Users[SelectedIndex];
            for (int x = 0; x < Days; x++)
            {
                var point = new ObservablePoint()
                {
                    X = x,
                    Y = SelectedUser.Steps[x]
                };

                SineGraphValues.Add(point);
            }
        }
        //private void ExecuteChangePeriodCommand(object obj)
        //{
        //    throw new NotImplementedException();
        //}

        //private void ExecuteDisplayUserDataCommand(object obj)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
