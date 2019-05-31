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
            
            var test = _validatorService.DateBetweenDays(from, DateTime.Now);
            Assert.Equal(0, test);

        }
    }
}
