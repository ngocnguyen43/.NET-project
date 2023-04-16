using Newtonsoft.Json;

namespace WebAPI.Models.Message
{
    public class Body
    {
        public Body() { }
        [JsonProperty]
        public string? accessToken { get; set; }
        [JsonProperty]
        public string? refreshToken { get; set; }
        [JsonProperty]
        public Object? data { get; set; }

        public class Builder
        {
            private string? accessToken;
            private string? refreshToken;
            private Object? data;
            public Builder(string? accessToken)
            {
                this.accessToken = accessToken;

            }
            public Builder WithRefreshToken(string? refreshToken)
            {
                this.refreshToken = refreshToken;
                return this;
            }
            public Builder WithData(Object? data)
            {
                this.data = data;
                return this;
            }
            public Body Build()
            {
                Body body = new Body();
                body.accessToken = accessToken;
                body.refreshToken = refreshToken;
                body.data = data;
                return body;
            }
        }
    }
}
