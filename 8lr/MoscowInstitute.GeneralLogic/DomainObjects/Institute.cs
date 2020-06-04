using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowInstitute.DomainObjects
{
    public class Institute : DomainObject 
    {
        public string ShortName { get; set; }

        public string WebSite { get; set; }

        public string ChiefName { get; set; }

        public string LegalAddress { get; set; }
    }
}
