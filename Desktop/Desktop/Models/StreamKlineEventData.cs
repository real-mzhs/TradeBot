using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    internal class StreamKlineEventData
    {
        public string e { get; set; }
        public long E { get; set; }
        public string s { get; set; }
        public StreamKlineData k { get; set; }
    }
}
