using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft;
using RobertTapping.Mi9CC.Models;
using Newtonsoft.Json.Linq;
using RobertTapping.Mi9CC.Repositories;
using System.Threading.Tasks;


namespace RobertTapping.Mi9CC.Controllers
{
    public class ValuesController : ApiController
    {

        // POST api/values
        public async Task<object> Post()
        {

            string postData = await this.Request.Content.ReadAsStringAsync();
            
            try
            {
                if (String.IsNullOrEmpty(postData))
                {
                    throw new Exception("No Json Post Data Was Found in the request body, please try again.");
                }


                var DataContext = JsonDataRepository.Instance.ProcessJsonDataToModel(postData);
                if (DataContext == null)
                {
                    throw new Exception("The json provided passed, but was not the required json for this request.");
                }
                var response = JsonDataRepository.Instance.GetListOfShowsForResponse();
                return response;

            }
            catch (Exception ex)
            {
               return this.Request.CreateResponse(HttpStatusCode.BadRequest, new { error = String.Format("Could not decode request: {0}", ex.Message) });


            }
        }

    }
}
