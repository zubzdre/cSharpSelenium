using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.utilities
{
    public class JsonReader
    {
        public JsonReader()
        {

        }
        public string readData(string tokenName)
        {
            String myJsonString = File.ReadAllText("utilities/TestData.txt");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string[] readDataArray(string tokenName)
        {
            String myJsonString = File.ReadAllText("utilities/TestData.txt");
            var jsonObject = JToken.Parse(myJsonString);
            IList<string> productsList= jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return productsList.ToArray();  
        }
    }
}
