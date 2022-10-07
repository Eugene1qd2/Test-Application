using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysisApplication.MVVM.Models
{

    public class UserModel // модель пользователя
    {
        public string User { get; set; }
        public int AverageSteps { get; set; }
        public int BestResult { get; set; }
        public int WorseResult { get; set; }
        public List<UserRaceModel> UserRaces { get; set; }
        public bool IsDiffer { get; set; }
        public UserModel() { }

        public UserModel(string user, int averageSteps, int bestResult, int worseResult)
        {
            User = user;
            AverageSteps = averageSteps;
            BestResult = bestResult;
            WorseResult = worseResult;
        }

        public UserModel(string user, List<UserRaceModel> userRaces, int days)
        {
            User = user;
            AverageSteps = userRaces.Sum(x => x.Steps) / days; //делаю так изза того, что есть дни, не отмеченные в забегах, в которые человек прошёл 0 шагов. Я решил их учитывать.
            BestResult = userRaces.Max(x => x.Steps);

            if (userRaces.Count() < days) //учитываю, что если человек не каждый день делал забег, то в какие то дни у него 0 шагов. Если забеги были не каждый день, то худший результат 0.
            {
                WorseResult = 0;
            }
            else
            {
                WorseResult = userRaces.Min(x => x.Steps);
            }

            IsDiffer = userRaces.Count(x =>
            {
                return x.Steps * 1.2 < AverageSteps || x.Steps * 0.8 > AverageSteps;
            }) > 0; // проверка есть ли у пользователя забеги с количеством шагом больше или меньше среднего на 20%

            UserRaces = userRaces;
        }
    }
}
