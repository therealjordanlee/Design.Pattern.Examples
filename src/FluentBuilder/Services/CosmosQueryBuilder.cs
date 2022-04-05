namespace FluentBuilder.Services
{
    public class CosmosQueryBuilder
    {
        private string _query;

        public CosmosQueryBuilder()
        {
            _query = "SELECT * FROM c";
        }

        public CosmosQueryBuilder Where()
        {
            _query = $"{_query} WHERE";
            return this;
        }

        public CosmosQueryBuilder And()
        {
            _query = $"{_query} AND";
            return this;
        }

        public CosmosQueryBuilder TitleContains(string title)
        {
            _query = $"{_query} contains(lower(c.title), lower('{title}'))";
            return this;
        }

        public CosmosQueryBuilder TitleEquals(string title)
        {
            _query = $"{_query} c.title = '{title}'";
            return this;
        }

        public CosmosQueryBuilder ContentContains(string content)
        {
            _query = $"{_query} contains(lower(c.content), lower('{content}'))";
            return this;
        }

        public string Build()
        {
            return _query;
        }
    }
}