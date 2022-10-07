using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysisApplication.MVVM.Models
{
    public class UserRaceModel //модель забега
    {
        public int Rank { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public int Steps { get; set; }
        public int Day { get; set; }

        public UserRaceModel(int day,string user, int rank, string status, int steps)
        {
            User = user;
            Rank = rank;
            Status = status;
            Steps = steps;
            Day = day;
        }

        public UserRaceModel()
        {
        }
    }
}
