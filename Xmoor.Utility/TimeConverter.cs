using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Utility
{
    public class TimeConverter
    {

        public TimeSpan getDifference(DateTime? date1,DateTime? date2)
        { 
            return (DateTime)date1-(DateTime)date2;
        }
    }
}
