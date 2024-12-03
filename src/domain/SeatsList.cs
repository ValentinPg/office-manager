using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lugares_oficina.src
{
    public class SeatsList
    {
        const int MAX_X_DAY = 10;
        Dictionary<DateTime, List<string>> seatsSchedule = new Dictionary<DateTime, List<string>>();

        public Dictionary<DateTime, List<string>> SeatsSchedule{
            get{return seatsSchedule;}
        }
        public void AddDate(DateTime date)
        {
            seatsSchedule.Add(date, []);
        }

        public List<string> SearchByDate(DateTime date)
        {
            return seatsSchedule[date];

        }

        public void AddPerson(DateTime date,string person){
            SearchByDate(date).Add(person);
        }

    }
}