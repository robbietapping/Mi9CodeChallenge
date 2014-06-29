using Newtonsoft.Json.Linq;
using RobertTapping.Mi9CC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobertTapping.Mi9CC.Repositories
{
    public class JsonDataRepository
    {
        private static JsonDataRepository _instance;
        public static JsonDataRepository Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    _instance = new JsonDataRepository();
                    return _instance;
                }
            }
        }


        public ShowInformationModel DataContext { get; set; }

        public JsonDataRepository() { }

        public ShowInformationModel ProcessJsonDataToModel(string json)
        {
            try
            {
                dynamic showInformation = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                ShowInformationModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<ShowInformationModel>(json);

                model.shows = new List<Show>();
                var payloadArray = ((JObject)showInformation).GetValue("payload");


                payloadArray.ToList().ForEach(item =>
                {
                    Show castedItem = item.ToObject<Show>();
                    model.shows.Add(castedItem);
                });

                DataContext = model;

                return DataContext;

            }
            catch (Exception ex)
            {
                throw new Exception("Was unable to process the json payload string. ", ex);
            }

        }


        public object GetListOfShowsForResponse()
        {

            var showsResponse = this.DataContext.shows
                                      .Where(shw => shw.drm && shw.episodeCount > 0).ToList();
            var responseItems = new { response = showsResponse
                                                        .Select(show => 
                                                             new { image = show.image != null ? show.image.showImage : null,
                                                                    slug = show.slug,
                                                                    title = show.title }).ToArray() 
            };


            return responseItems;
        }


    }
}