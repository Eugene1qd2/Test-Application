using DataAnalysisApplication.MVVM.Models;
using System.Collections.Generic;
using System.Linq;
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

        private ChartValues<ObservableValue> _sineGraphValues;

        private UserModel _selectedItem;

        private Brush BestResultBrush { get; set; }
        private Brush DefaultResultBrush { get; set; }

        private CartesianMapper<ObservableValue> _mapper;
        public CartesianMapper<ObservableValue> Mapper
        {
            get
            {
                return _mapper;
            }
            set
            {
                _mapper = value;
                OnPropertyChanged();
            }
        }
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

                ChangeSineGraphValues(); // когда выбранный элемент меняется я обновляю диаграмму
            }
        }

        public ChartValues<ObservableValue> SineGraphValues
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

        public ICommand SelectedUserExportCommand { get; }

        public DataAnalysisWindowViewModel()
        {
            Days = 30; // период за который будет выводиться информация в диаграмме

            races = UserRepository.GetRaces(Days); // выгружаю забеги

            Users = UserRepository.GetUsers(races, Days); // получаю список ользователей и их личными результатами за каждый день
            SelectedItem = Users[0]; // устанавливаю выбранного пользователя в первого по умолчанию
            ChangeSineGraphValues(); // обновляю диаграмму

            SelectedUserExportCommand = new ViewModelCommand(ExecuteSelectedUserExportCommand);

            BestResultBrush = new SolidColorBrush(Color.FromRgb(238, 83, 80));
            DefaultResultBrush = new SolidColorBrush(Color.FromRgb(20, 20, 80));
        }

        private void ExecuteSelectedUserExportCommand(object obj)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog(); //создаю диалоговое окно и спрашиваю куда сохранить
            dialog.Filter = $"XML File | .xml";
            if (dialog.ShowDialog() == true)
            {
                string filename = dialog.FileName;

                UserModel SelectedUser = Users.Where(x => x.User == SelectedItem.User).First();

                UserRepository.SerializeUser(SelectedUser, filename); //сериализую пользователя
            }
        }

        private void ChangeSineGraphValues()
        {
            UserModel SelectedUser = Users.Where(x => x.User == SelectedItem.User).First(); //получаю полный объект пользователя, поскольку тот,
                                                                                            //что передается в таблицу имеет незаполненное поле
                                                                                            //Steps, которое мне необходимо в этом методе
            MaxSteps = SelectedUser.BestResult + 10000;

            var chart = new ChartValues<ObservableValue>(); // создаю и заполняю точки для отображения диаграммы. Использовал Nuget пакет LiveCharts.WPF
            for (int x = 1; x <=Days; x++)
            {
                var point = new ObservableValue()
                {
                    Value = SelectedUser.UserRaces.Count(item=>item.Day==x)>0 ? SelectedUser.UserRaces.Where(item=>item.Day==x).First().Steps : 0 // проверка был ли в этот день забег у пользователя или нет
                };
                chart.Add(point);
            }
            SineGraphValues = chart; // применяю измененные точки
            Mapper = Mappers.Xy<ObservableValue>()
                .X((item, index) => index)
                .Y(item => item.Value)
                .Fill(item => item.Value == SelectedUser.UserRaces.Max(x => x.Steps) ? BestResultBrush : DefaultResultBrush)
                .Stroke(item => item.Value == SelectedUser.UserRaces.Max(x => x.Steps) ? BestResultBrush : DefaultResultBrush);
        }

    }
}
