using ArinWhois.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class whois
    {
        public static async Task<string> getdatawhois(string ip)
        {
            var arinclient = new ArinClient();
            var ipresponse = await arinclient.QueryIpAsync(IPAddress.Parse(ip));
            var responce = ipresponse.Network.Name + Environment.NewLine;
            return responce;
        }
    }
}
