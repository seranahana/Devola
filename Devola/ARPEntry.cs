using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaine
{
    class ARPEntry
    {
        public ARPEntry(IPAddress ipAddress, PhysicalAddress macAddress) 
        {
            MACAddress = macAddress;
            IPAddress = ipAddress;
        }
        public PhysicalAddress MACAddress { get; set; }
        public IPAddress IPAddress { get; set; }
    }
}
