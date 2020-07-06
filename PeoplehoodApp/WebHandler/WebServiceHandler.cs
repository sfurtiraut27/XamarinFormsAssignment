using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using PeoplehoodApp.Models;

using Newtonsoft.Json;

namespace PeoplehoodApp.WebHandler
{
    class WebServiceHandler
    {
        #region Fields 

        System.Net.Http.HttpClient client;

        #endregion

        #region Properties 

        public string WebAPIUrl
        {
            get; private set;
        }

        #endregion

        #region Constructor
        public WebServiceHandler()
        {
            client = new System.Net.Http.HttpClient();
        }

        #endregion

        #region Methods
       
        /// <summary>
        /// Used to get people data from API with provided ID
        /// </summary>
        /// <param name="IDNumber"></param>
        /// <returns>People object</returns>
        public async System.Threading.Tasks.Task<People> GetPeopleDataWithID(string IDNumber)
        {
            WebAPIUrl = "https://swapi.dev/api/people/" + IDNumber + "/"; // Set your REST API url here
            
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    People people = JsonConvert.DeserializeObject<People>(content);
                    return people;
                } 
               
            }
            catch (Exception)
            {
            }
            return null;
        }

        #endregion
    }

}
