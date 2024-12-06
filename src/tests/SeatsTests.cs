using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using lugares_oficina.src;
using lugares_oficina.src.customExceptions;
using Microsoft.VisualBasic;
using Xunit;

namespace lugares_oficina
{
    public class SeatsTests : IDisposable
    {
        SeatsList seats = new SeatsList();
        Person person1 = new Person("Juan", "Ramirez", 558156687);
        DateTime today = DateTime.Today;
        DateTime tomorrow = DateTime.Today.AddDays(1);


        public void Dispose()
        {
            // Se ejecuta después de cada prueba
            seats = new SeatsList();
        }
        [Fact]
        public void AddDate()
        {
            seats.AddDate(today);
            Assert.NotEmpty(seats.SeatsSchedule);
        }

        [Fact]
        public void SearchDate()
        {
            var dateToday = seats.SearchPersonsByDate(today);
            Assert.Equal(dateToday, []);
        }

        [Fact]
        public void AddPerson()
        {
            seats.AddPerson(today, person1);
            Assert.Equal(seats.SearchPersonsByDate(today), [person1]);
        }

        [Fact]
        public void TestMaxPersons()
        {
            Assert.Throws<BusinessException>(() => seats.AddPerson(today, [person1, person1, person1, person1, person1, person1, person1, person1, person1, person1, person1]));
        }

        [Fact]
        public void TestSearchPerson()
        {
            seats.AddPerson(today, person1);
            Assert.Equal([today], seats.SearchByPerson(person1));

            seats.AddPerson(tomorrow, person1);
            Assert.Equal([today, tomorrow], seats.SearchByPerson(person1));
        }

    }
}