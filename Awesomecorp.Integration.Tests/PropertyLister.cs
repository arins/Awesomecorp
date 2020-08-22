using NUnit.Framework;
using System;
using System.Collections.Generic;
using Awesomecorp.Integration.Datasource.Models;
using System.Linq;
using System.Text;

namespace Awesomecorp.Integration.Tests
{
    public class PropertyListerTests
    {
        [Test]
        public void ListPropertiesTest()
        {
            var propertLister = new PropertyLister<Subscriber>();
            propertLister.Load();
            var list = propertLister.Properties.Select(p => p.Name).ToList();
            Assert.Contains("Id", list);
            Assert.Contains("Firstname", list);
            Assert.Contains("Lastname", list);
            Assert.Contains("Email", list);
            Assert.Contains("Mobile", list);
            

        }
    }
}
