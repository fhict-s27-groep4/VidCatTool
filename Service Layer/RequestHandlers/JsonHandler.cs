using System;
using Data_Layer;
using System.Collections.Generic;
using System.Text;
using Model_Layer.Models;
using Data_Layer.Interface;

namespace Service_Layer.RequestHandlers
{
    public class JsonHandler
    {
        private readonly IJsonAddRepository jsonrepo;
        public JsonHandler(IEnumerable<AddJson> ids, IJsonAddRepository jsonrepo)
        {
            this.jsonrepo = jsonrepo ?? throw new NullReferenceException();
        }
        public void AddJsonFile(IEnumerable<AddJson> jsons)
        {
            jsonrepo.AddJsonVideos(jsons);
        }
    }
}
