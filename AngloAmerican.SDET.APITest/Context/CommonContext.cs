using System.Net;
using System.Xml;
using TechTalk.SpecFlow;

namespace AngloAmerican.SDET.APITest.Context
{
    public class CommonContext
    {
        public CommonContext(ScenarioContext scenarioContext)
        {
            ScenaroContext = scenarioContext;
        }

        public ScenarioContext ScenaroContext { get; }
        public XmlDocument CarShowRoomGetServiceResponse { get; set; }
        public string CarType { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
