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
            CheckSeatsCapacity(date);
            if (!DateExists(date))
                seatsSchedule.Add(date, []);
        }

        public void CheckSeatsCapacity(DateTime date)
        {
            if (SearchPersonsByDate(date).Count() == MAX_X_DAY)
                throw new BusinessException("Máximo capacidad de lugares alcanzada para este día");
        }

        private bool DateExists(DateTime date)
        {
            return seatsSchedule.ContainsKey(date);
        }

        public List<Person> SearchPersonsByDate(DateTime date)
        {
            try
            {
                return seatsSchedule[date];
            }
            catch (KeyNotFoundException ex)
            {
                return [];
            }

        }

        public void AddPerson(DateTime date, Person person)
        {
            AddDate(date);
            SearchPersonsByDate(date).Add(person);
        }

        public void AddPerson(DateTime date, List<Person> persons)
        {
            persons.ForEach(person => AddPerson(date, person));
        }

        public List<DateTime> SearchByPerson(Person person)
        {
            return seatsSchedule.Where(item => item.Value.Contains(person)).Select(item => item.Key).ToList();
        }

    
        

    }
}

