using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Qooxdoo.WebDriver.Log
{
    /// <summary>
    /// Adds a JSon string to the log.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        /// <param name="json">The json string to add as a log entry.</param>
        public LogEntry(string json)
        {
            try
            {
                JObject jObject = JObject.Parse(json);
                clazz = (string) jObject.GetValue("clazz");
                level = (string) jObject.GetValue("level");
                time = (string) jObject.GetValue("time");
                JArray jArray = (JArray) jObject.GetValue("items");
                using (IEnumerator<object> itr = jArray.GetEnumerator())
                {
                    while (itr.MoveNext())
                    {
                        items.Add(itr.Current.ToString());
                    }
                }
            }
            catch (JsonException e)
            {
                // TODO Auto-generated catch block
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
            }
        }

        private string clazz;
        private string level;
        private IList<string> items = new List<string>();
        private string time;

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            if (ReferenceEquals(clazz, null))
            {
                return time + " " + level + ": " + items;
            }

            return time + " " + level + ": " + clazz + " " + items;
        }
    }
}