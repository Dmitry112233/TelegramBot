using RestSharp;

namespace TrainingProject.Api
{
    public class RestApiUtils
    {
        public string Token { get; set; }

        public RestApiUtils()
        {
            this.Token = "47da9e3adamshdb867ab925ef7bcp167869jsn2662040e3703";
        }

        public IRestResponse postRequest(string requestUrl)
        {
            var client = new RestClient(requestUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("x-rapidapi-host", "SwapistefanskliarovV1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", this.Token);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}