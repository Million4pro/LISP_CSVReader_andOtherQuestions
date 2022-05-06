using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader
{
    [Serializable]
    public class Enrollee
    {
        public string userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int version { get; set; }
        public string insuranceCompany { get; set; }
    }
}
