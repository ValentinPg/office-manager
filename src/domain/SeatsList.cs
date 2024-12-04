using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lugares_oficina.src.customExceptions;

namespace lugares_oficina.src
{
    public class SeatsList
    {
        const int MAX_X_DAY = 10;
        private Dictionary<DateTime, List<Person>> seatsSchedule = new Dictionary<DateTime, List<Person>>();

        public Dictionary<DateTime, List<Person>> SeatsSchedule
        {
            get { return seatsSchedule; }
        }

        public void AddDate(DateTime date)
        {
            CheckSeatsCapacity();
            if (!DateExists(date))
                seatsSchedule.Add(date, []);
        }

        private void CheckSeatsCapacity()
        {
            if (seatsSchedule.Count() == MAX_X_DAY)
                throw new BusinessException("Máximo capacidad de lugares alcanzada para este día");
        }

        private bool DateExists(DateTime date)
        {
            return seatsSchedule.ContainsKey(date);
        }

        public List<Person> SearchPersonsByDate(DateTime date)
        {
            return seatsSchedule[date];
        }

        public void AddPerson(DateTime date, Person person)
        {
            SearchPersonsByDate(date).Add(person);
        }

    }
}