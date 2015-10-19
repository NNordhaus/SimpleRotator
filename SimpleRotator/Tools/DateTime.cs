using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleRotator.Tools
{
    public interface iDateTime
    {
        System.DateTime Now();
    }

    public class DateTime : iDateTime
    {
        public System.DateTime Now()
        {
            return System.DateTime.Now;
        }
    }
}