using Newtonsoft.Json;

namespace WebAPI.Models.Message
{
    public class Pagination
    {
        private Pagination() { }
        [JsonProperty]
        private int? currentPage;
        [JsonProperty]
        private int? totalPages;
        [JsonProperty]
        private int? totalResults;
        public class Builder
        {
            private int? currentPage;
            private int? totalPages;
            private int? totalResults;
            public Builder(int currentPage)
            {
                this.currentPage = currentPage;
            }
            public Builder WithTotalPages(int totalPages)
            {
                this.currentPage = totalPages;
                return this;
            }
            public Builder WithTotalResults(int totalResults)
            {
                this.totalResults = totalResults;
                return this;
            }
            public Pagination Build()
            {
                Pagination pagination = new Pagination();
                pagination.currentPage = currentPage;
                pagination.totalPages = totalPages;
                pagination.totalResults = totalResults;
                return pagination;
            }
        }
    }
}
