using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysisApplication.MVVM.Models
{
    public class UserModel
    {
        public string User { get; set; }
        public int AverageSteps { get; set; }
        public int BestResult { get; set; }
        public int WorseResult { get; set; }
        public List<int> Steps { get; set; }

        public UserModel(string user, int averageSteps, int bestResult, int worseResult)
        {
            User = user;
            AverageSteps = averageSteps;
            BestResult = bestResult;
            WorseResult = worseResult;
        }

        public UserModel(string user, List<int> steps)
        {
            User = user;
            AverageSteps = (int)steps.Average();
            BestResult = steps.Max();
            WorseResult = steps.Min();
            Steps = steps;
        }

        public UserModel(string user, Dictionary<int, int> steps)
        {
            User = user;
            AverageSteps = (int)steps.Values.Average();
            BestResult = steps.Values.Max();
            WorseResult = steps.Values.Min();
            Steps = steps.Values.ToList();
        }
    }
}
