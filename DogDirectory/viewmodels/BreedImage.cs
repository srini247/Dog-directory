using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogDirectory.viewmodels
{
    public class BreedImage
    {
        public string status { get; set; }
       
         string _message;
        public string message
        {
            get
            {
                return this._message;
            }
            set
            {
                this._message = System.Web.HttpUtility.HtmlDecode(value);
            }
        }

    
    }
}