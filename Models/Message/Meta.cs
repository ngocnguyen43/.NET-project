﻿using Newtonsoft.Json;

namespace WebAPI.Models.Message
{
    public class Meta
    {
        private Meta() { }
        [JsonProperty]
        private string message;
        [JsonProperty]
        private int statuscode;
        [JsonProperty]
        private int errorcode;
        public int GetStatusCode()
        {
            return this.statuscode;
        }
        public int GetErrorCode() { return this.errorcode; }
        public class Builder
        {
            private string message;
            private int statuscode;
            private int errorcode;
            public Builder(string message)
            {
                this.message = message;
            }
            public Builder WithStatusCode(int statuscode)
            {
                this.statuscode = statuscode;
                return this;
            }
            public Builder WithErrorCode(int errorcode)
            {
                this.errorcode = errorcode;
                return this;
            }
            public Meta Build()
            {
                Meta meta = new Meta();
                meta.message = message;
                meta.statuscode = statuscode;
                meta.errorcode = errorcode;
                return meta;
            }
        }
    }
}
