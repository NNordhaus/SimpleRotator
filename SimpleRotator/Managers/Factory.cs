using SimpleRotator.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleRotator.Managers
{
    public static class Factory
    {
        private static AdRepo repo;
        private static FileIO io;
        private static Tools.iDateTime dateTime;

        public static AdRepo GetRepo()
        {
            if (repo == null)
            {
                repo = new AdRepo(GetIO(), HttpContext.Current.Server.MapPath("~/App_Data/"));
            }

            return repo;
        }

        public static FileIO GetIO()
        {
            if (io == null)
            {
                io = new DiskIO();
            }

            return io;
        }

        public static Tools.iDateTime GetDateTime()
        {
            if (dateTime == null)
            {
                dateTime = new Tools.DateTime();
            }

            return dateTime;
        }
    }
}