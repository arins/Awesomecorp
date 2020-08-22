using Awesomecorp.Integration.Datasource;
using Awesomecorp.Integration.Datasource.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Awesomecorp.ConsoleApp
{
    public class AwesomeCorpDatasourceMock : IAwesomeCorpDatasource
    {
        public Task<GetSubscriberResponse> GetSubscribers()
        {
            return Task.FromResult(new GetSubscriberResponse
            {
                List = new List<Subscriber>
                {
                     new Subscriber
                     {
                         Id ="1",
                         Email  = "test@test.com",
                         Firstname = "first",
                         Lastname  = "las",
                         Mobile = "mob"
                     }
                }
            });
        }
    }
}
