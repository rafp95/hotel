using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.DAO.Infrastucture
{
    public class DateTimeAttribute : ValidationAttribute
    {
        public DateTimeAttribute()
        {
            ErrorMessage = "Data musi być równa bądź późniejsza";
        }

        public override bool IsValid(object value)
        {
            DateTime date = Convert.ToDateTime(value);
            DateTime now = DateTime.Now;
            return new DateTime(date.Year, date.Month, date.Day) >= new DateTime(now.Year,now.Month,now.Day);
        }
    }
}
