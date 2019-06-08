using Hotel.DAO.HotelService;
using Hotel.DAO.HotelServiceImpl;
using System;
using Xunit;

namespace Hotel.Tests
{
    public class DateTimeTests
    {
        private readonly IValidatorService _validatorService;

        public DateTimeTests()
        {
            _validatorService = new ValidatorServiceImpl();
        }

        [Fact]        
        public void CheckDateBetweenTests()
        {
            DateTime from = new DateTime(2019,06,01);
            DateTime to = new DateTime(2019, 06, 02);

            Assert.Equal(1, _validatorService.DateBetweenDays(from, to));

        }

        [Fact]
        public void CheckCalculateToPay()
        {
            DateTime from = new DateTime(2019, 06, 01);
            DateTime to = new DateTime(2019, 06, 03);
            Assert.Equal(200, CalculatePriceToPay(_validatorService.DateBetweenDays(from,to),100));
        }

        private decimal CalculatePriceToPay(int days, decimal dayCost)
        {
            if (days > 1)
            {
                return days * dayCost;
            }
            return dayCost;
        }

    }
}
