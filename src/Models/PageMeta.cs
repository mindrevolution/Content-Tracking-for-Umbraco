﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mindrevolution.ContentTracking.Models
{
    public class PageMeta
    {
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
        [JsonProperty("funnelstage")]
        public string FunnelStage { get; set; }

        public PageMeta() {}

        public PageMeta(string category, string format, string funnelstage)
        {
            Category = category;
            Format = format;
            FunnelStage = funnelstage;
        }

        public static PageMeta Deserialize(string json)
        {
            if (json == null || !json.StartsWith("{") || !json.EndsWith("}")) return null;

            try
            {
                return JsonConvert.DeserializeObject<PageMeta>(json);
            }
            catch (Exception ex)
            {
                Umbraco.Core.Logging.LogHelper.WarnWithException<PageMeta>(string.Format("Unable to deserialize JSON: {0}{1}{2}", ex.Message, Environment.NewLine, json), ex);
                return null;
            }

            
        }
    }
}
