using System;
using System.Collections.Generic;
using System.Text;

namespace Awesomecorp.Integration.Datasource.Models
{
    public class GetSubscriberResponse
    {

        public IEnumerable<Subscriber> List { get; set; }
    }
}
