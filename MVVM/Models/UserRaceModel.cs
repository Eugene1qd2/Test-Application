using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysisApplication.MVVM.Models
{
    public class UserRaceModel
    {
        public int Rank { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public int Steps { get; set; }

        public UserRaceModel(string user, int rank, string status, int steps)
        {
            User = user;
            Rank = rank;
            Status = status;
            Steps = steps;
        }

        public UserRaceModel()
        {
        }
    }
}
