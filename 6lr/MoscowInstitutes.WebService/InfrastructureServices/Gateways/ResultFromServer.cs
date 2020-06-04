using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoscowInstitutes.WebService.InfrastructureServices.Gateways
{
    public class Cells
    {
        public string ShortName { get; set; }
        public string WebSite { get; set; }
        public string LegalAddress { get; set; }
        public string ChiefName { get; set; }
    }

    public class ResultFromServer
    {
        public int Number { get; set; }
        public Cells Cells { get; set; }
    }
}
