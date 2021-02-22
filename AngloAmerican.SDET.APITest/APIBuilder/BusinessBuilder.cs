using RestSharp;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Xml;
using log4net;
using AngloAmerican.SDET.APITest.Helper;

namespace AngloAmerican.SDET.APITest.APIBuilder
{
    public class BusinessBuilder
    {
        private static readonly ILog Logger = ExceptionLogger.GetLogger(typeof(BusinessBuilder));
        public static readonly string baseURL = "http://localhost:54356/";
        public static string ShowRoomServiceEndPointUrl(string type) => $"api/cars/{type}";

        /*Function to get car details for a specified type and coverting the JSON response into an XML Document*/
        public static XmlDocument GetActualCarDetails(string carType)
        {
            //Using RestAPIClient for sending request to the EndPoint
            RestClient restClinet = new RestClient(baseURL);
            RestRequest restRequest = new RestRequest(ShowRoomServiceEndPointUrl(carType), Method.GET);
            IRestResponse restResponse = restClinet.Execute(restRequest);
            HttpStatusCode statusCode = restResponse.StatusCode;

            //Casting the HttpStatusCode into integer the number status code 
            int numericStatusCode = (int)statusCode;

            /*Converting the JSON response into XML document for the successful(i.e. HTTP Status code = 200) response
             else throw HttpResponseException */
            try
            {
                if (numericStatusCode == 200)
                {
                    XmlDocument xMLDoc = JsonConvert.DeserializeXmlNode("{\"car\":" + restResponse.Content + "}", "root");
                    Console.WriteLine("The http status code is: " + numericStatusCode);
                    numericStatusCode.Equals(200);
                    Logger.Info("The Http Response is successful");
                    return xMLDoc;
                }
                else
                {
                    Console.WriteLine("The specified cartype " + "'" + carType + "'" + " does not exists in the showroom");
                    Console.WriteLine("The http status code is: " + numericStatusCode);
                    numericStatusCode.Equals(404);
                    Logger.Error("The Http Response is NOT successful");
                    return null;
                }
            }
            catch (WebException e)
            {
                Logger.Error("The Http Response is NOT successful " + e.Message);
                throw;
            }
        }
    }
}
