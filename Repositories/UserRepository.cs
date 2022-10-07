using DataAnalysisApplication.MVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Serialization;

namespace DataAnalysisApplication.Repositories
{
    class SreializebleUser
    {

    }
    public class UserRepository
    {
        public static void SerializeUser(UserModel user, string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserModel));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, user);
            }
        }
        public static List<UserModel> GetUsers(List<List<UserRaceModel>> races, int days) // метод преобразования множества забегов в список людей/пользователей
        {
            Dictionary<string,List<UserRaceModel>> UserStats = new Dictionary<string, List<UserRaceModel>>();
            for (int i = 0; i < days; i++)
            {
                for (int j = 0; j < races[i].Count; j++)
                {
                    if (!UserStats.Keys.Contains(races[i][j].User))
                    {
                        UserStats.Add(races[i][j].User, new List<UserRaceModel>());
                    }
                    UserStats[races[i][j].User].Add(races[i][j]);
                }
            }

            List<UserModel> users = new List<UserModel>();

            foreach (var userStat in UserStats)
            {
                users.Add(new UserModel(userStat.Key, userStat.Value, days));
            }
            return users;
        }

        private static UserRaceModel[] GetRacesPerDay(string filename,int day) // метод чтения json файла по имени
        {
            string text = File.ReadAllText(filename);
            UserRaceModel[] userRace = Newtonsoft.Json.JsonConvert.DeserializeObject<UserRaceModel[]>(text);
            for (int i = 0; i < userRace.Length; i++)
            {
                userRace[i].Day = day;
            }
            return userRace;
        }

        public static List<List<UserRaceModel>> GetRaces(int daysAmount) // метод получения всех забегов
        {
            List<List<UserRaceModel>> Races=new List<List<UserRaceModel>>();
            for (int i = 1; i <= daysAmount; i++)
            {
                Races.Add(GetRacesPerDay($"RacesData\\day{i}.json",i).ToList());
            }
            return Races;
        }
    }
}
