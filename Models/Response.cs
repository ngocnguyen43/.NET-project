using Newtonsoft.Json;
using WebAPI.Models.Message;

namespace WebAPI.Models
{

    public class Response
    {
        [JsonProperty]
        private Meta meta;
        [JsonProperty]
        private Body? body;
        [JsonProperty]
        private Pagination? pagination;
        public Meta GetMeta() { return meta; }
        public class Builder
        {
            private Meta meta;
            private Body? body;
            private Pagination? pagination;
            public Builder(Meta meta)
            {
                this.meta = meta;
            }
            public Builder WithBody(Body? body)
            {
                this.body = body;
                return this;
            }
            public Builder WithPagination(Pagination? pagination)
            {
                this.pagination = pagination;
                return this;
            }
            public Response Build()
            {
                Response response = new Response();
                response.meta = meta;
                response.pagination = pagination;
                response.body = body;
                return response;
            }
        }
    }
}
