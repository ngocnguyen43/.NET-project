using Newtonsoft.Json;

namespace WebAPI.Models.Message
{
    public class Body
    {
        private Body() { }
        [JsonProperty]
        private string? accessToken;
        [JsonProperty]
        private string? refreshToken;
        public class Builder
        {
            private string? accessToken;
            private string? refreshToken;
            public Builder(string accessToken)
            {
                this.accessToken = accessToken;

            }
            public Builder WithRefreshToken(string refreshToken)
            {
                this.refreshToken = refreshToken;
                return this;
            }
            public Body Build()
            {
                Body body = new Body();
                body.accessToken = accessToken;
                body.refreshToken = refreshToken;
                return body;
            }
        }
    }
}
