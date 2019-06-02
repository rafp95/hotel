using Hotel.DAO.HotelService;
using Hotel.DAO.HotelServiceImpl;
using System;
using Xunit;

namespace Hotel.Tests
{
    public class DateTimeTests
    {
        private IValidatorService _validatorService;

        public DateTimeTests()
        {
            _validatorService = new ValidatorServiceImpl(); 
        }

        [Fact]        
        public void DateBetweenTests()
        {
            DateTime from = new DateTime(2019,05,31);
            DateTime to = new DateTime(2019, 06, 02);

            Assert.Equal(2, _validatorService.DateBetweenDays(from, to));

        }
    }
}
