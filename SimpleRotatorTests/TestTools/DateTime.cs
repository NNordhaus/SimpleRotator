using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRotatorTests.TestTools
{
    public class DateTimeShim : SimpleRotator.Tools.iDateTime
    {
        public DateTimeShim()
        {
            PreloadedDate = System.DateTime.Now;
        }

        public DateTimeShim(System.DateTime dateTime)
        {
            PreloadedDate = dateTime;
        }

        public System.DateTime PreloadedDate { get; set; }

        public System.DateTime Now()
        {
            return PreloadedDate;
        }
    }
}
