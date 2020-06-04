using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowInstitute.DomainObjects
{
    public class MoscowInstitute : DomainObject
    {
        public string ShortName { get; set; }

        public string WebSite { get; set; }

        public string LegalAddress { get; set; }

        public string ChiefName { get; set; }

    }
}
