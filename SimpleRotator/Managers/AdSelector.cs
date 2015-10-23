using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SimpleRotator.Models;
using SimpleRotator.Tools;

namespace SimpleRotator.Managers
{
    public class AdSelector
    {
        private static Random r = new Random(System.DateTime.UtcNow.Millisecond * 1999993);

        public static IAd GetAd(AdRepo repo, iDateTime dateTime, string zoneName)
        {
            // Get the given zone
            var zone = repo.Zones.FirstOrDefault(z => z.Name.ToLower() == zoneName.ToLower());

            if (zone == null)
            {
                throw new Exception("Zone not found");
            }

            // Get all ads that have a time span covering now
            var now = dateTime.Now();
            var ads = zone.Ads.Where(a => a.StartDate < now && a.EndDate > now).ToList();

            //if (ads.Count == 0)
            //{
            //    // return Error ad, or blank ad
            //    return new DummyAd(
            //}

            // Get the sum of all rotation values
            var sum = ads.Sum(a => a.Rotation);

            // Select one at random, weighted by rotation
            var randomSelector = r.Next(0, sum);
            var counter = 0;

            while (randomSelector > -1)
            {
                if (ads[counter].Rotation > randomSelector)
                {
                    return ads[counter];
                }
                randomSelector -= ads[counter].Rotation;
                counter++;
            }

            throw new Exception("this should never happen, probably an off by 1 error. r = " + randomSelector);
        }

        public static string GetAdAsScript(AdRepo repo, iDateTime dateTime, string zoneName)
        {
            var output = GetAd(repo, dateTime, zoneName).Html;
            output = output.Replace("'", "\\'").Replace("\r\n", "").Replace("\n", "").Replace("\r", "");

            return "document.write('" + output + "');";
        }
    }
}