using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace RestSharpDemo
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {

            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}",Method.GET);
            request.AddUrlSegment("postid", 1);

            //var content = client.Execute(request).Content;
            //Dois jeitos para pegar o valor do Json

            var response = client.Execute(request);

            var deseriable = new JsonDeserializer();
            //var output = deseriable.Deserialize<Dictionary<string, string>>(response);
            // var result = output["author"];
            //Assert.That(result, Is.EqualTo("typicode"), "Author is incorret");

            JObject objs = JObject.Parse(response.Content);
            Assert.That(objs["author"].ToString(), Is.EqualTo("typicode"), "Author is incorret");

        }
    }
}
