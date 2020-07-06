using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.ComponentModel;
using PeoplehoodApp.WebHandler;
using PeoplehoodApp.Models;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace PeoplehoodApp.ViewModels
{
    public class PeopleViewModel 
    {
        #region Fields

        WebServiceHandler webServiceHandler;

        #endregion

        #region Constructor
        public PeopleViewModel()
        {
            webServiceHandler = new WebServiceHandler();
        }
        #endregion

        #region Methods 
      
        /// <summary>
        /// Used to get people data with provided id number
        /// </summary>
        /// <param name="IDNumber"></param>
        /// <returns>People object </returns>
        public async Task<People> GetPeopleWithID(string IDNumber)
        {
            People people = await webServiceHandler.GetPeopleDataWithID(IDNumber);
            return people;
        }
        
        /// <summary>
        /// Used to validate SA id
        /// </summary>
        /// <param name="IdNumber"></param>
        /// <returns>true if provided id is SA citizen, otherwise false</returns>
        public bool IsValidSAID(string IdNumber)
        {
            Regex regex = new Regex(@"(((\d{2}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)(\d{3})|(\d{7}))");
            if (!(string.IsNullOrWhiteSpace(IdNumber)) &&
                (regex.IsMatch(IdNumber)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       #endregion
    }
}
