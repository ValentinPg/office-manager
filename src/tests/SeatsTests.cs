using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using lugares_oficina.src;
using Xunit;

namespace lugares_oficina
{
    public class SeatsTests
    {
        [Fact]
        public void AddDate()
        {
            SeatsList seats = new SeatsList();
            seats.AddDate(DateTime.Today);
            Assert.NotEmpty(seats.SeatsSchedule);
        }

        [Fact]
        public void SearchDate()
        {
            var seats = new SeatsList();
            seats.AddDate(DateTime.Today);
            var dateToday = seats.SearchPersonsByDate(DateTime.Today);
            Assert.Equal(dateToday, []);
        }

        [Fact]
        public void AddPerson()
        {
            var seats = new SeatsList();
            var today = DateTime.Today;
            seats.AddDate(today);
            seats.AddPerson(today, "yo");
            Assert.Equal(seats.SearchPersonsByDate(today), ["yo"]);
        }
    }
}