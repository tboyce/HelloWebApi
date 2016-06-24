﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace HelloWebApi.Console.Greetings.Models
{
    public partial class Greeting
    {
        private int? _id;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private string _message;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Greeting class.
        /// </summary>
        public Greeting()
        {
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type Greeting
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.Id != null)
            {
                outputObject["Id"] = this.Id.Value;
            }
            if (this.Message != null)
            {
                outputObject["Message"] = this.Message;
            }
            return outputObject;
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((int)idValue);
                }
                JToken messageValue = inputObject["Message"];
                if (messageValue != null && messageValue.Type != JTokenType.Null)
                {
                    this.Message = ((string)messageValue);
                }
            }
        }
    }
}