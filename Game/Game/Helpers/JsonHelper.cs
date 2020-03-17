using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game.Helpers
{
    /// <summary>
    /// Json Helper for parsing the Service returned datasets
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0034:Simplify 'default' expression", Justification = "<Pending>")]
#pragma warning disable CA1031 // Do not catch general exception types
    public static class JsonHelper
    {
        /// <summary>
        /// Takes a json object, and retrieves a string from it matching the field
        /// </summary>
        /// <param name="json"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GetJsonString(JObject json, string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                return null;
            }

            // Get Field
            try
            {
                var tempJsonObject = json[field].ToString();
                if (string.IsNullOrEmpty(tempJsonObject))
                {
                    return null;
                }

                return tempJsonObject;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Takes a json object, and retrieves a string from it matching the field
        /// </summary>
        /// <param name="json"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static bool GetJsonBool(JObject json, string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                return false;
            }

            // Get Field
            try
            {
                var tempJsonObject = json[field].ToString();
                if (string.IsNullOrEmpty(tempJsonObject))
                {
                    return false;
                }

                if (tempJsonObject == "True")
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
