using DataAnalysisApplication.MVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DataAnalysisApplication.Repositories
{
    public class UserRepository
    {
        public static List<UserModel> GetUsers(List<List<UserRaceModel>> races, int days)
        {
            Dictionary<string,Dictionary<int,int>> UserStats = new Dictionary<string, Dictionary<int, int>>();
            for (int i = 0; i < days; i++)
            {
                for (int j = 0; j < races[i].Count; j++)
                {
                    if (!UserStats.Keys.Contains(races[i][j].User))
                    {
                        UserStats.Add(races[i][j].User, new Dictionary<int, int>());
                    }
                    UserStats[races[i][j].User].Add(i, races[i][j].Steps);
                }
            }

            List<UserModel> users = new List<UserModel>();

            foreach (var userStat in UserStats)
            {
                users.Add(new UserModel(userStat.Key, userStat.Value));
            }
            return users;
        }

        private static UserRaceModel[] GetRacesPerDay(string filename)
        {
            string text = File.ReadAllText(filename);
            UserRaceModel[] userRace = Newtonsoft.Json.JsonConvert.DeserializeObject<UserRaceModel[]>(text);
            return userRace;
        }

        public static List<List<UserRaceModel>> GetRaces(int daysAmount)
        {
            List<List<UserRaceModel>> Races=new List<List<UserRaceModel>>();
            for (int i = 1; i <= daysAmount; i++)
            {
                Races.Add(GetRacesPerDay($"RacesData\\day{i}.json").ToList());
            }
            return Races;
        }
    }
}
