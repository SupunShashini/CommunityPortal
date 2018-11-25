using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommunityPortal.Models
{
    class Incident
    {
        internal static readonly object incident;

        public int incidentId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public string address { get; set; }

        internal static Task GetStringAsync(string v)
        {
            throw new NotImplementedException();
        }

       
    }
    
}
