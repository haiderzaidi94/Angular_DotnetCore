using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp.Helpers
{
    public static class Extensions
    {
        public static int GetAge(this DateTime theDateTime) {
            var age = DateTime.Now.Year - theDateTime.Year;
            if(theDateTime.AddYears(age) > DateTime.Today){
                age--;
            }
            return age;
        }
    }
}
