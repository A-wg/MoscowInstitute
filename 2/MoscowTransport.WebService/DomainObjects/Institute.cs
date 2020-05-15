using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowInstitute.DomainObjects
{
    public class Institute : DomainObject
    {
        public string NameInstitute { get; set; }

        public string Site { get; set; }

        public string Address { get; set; }
    
        public string Program { get; set; }

    }
}
