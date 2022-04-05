using FluentBuilder.Services;
using Xunit;

namespace FluentBuilder.Tests
{
    public class FluentBuilderTests
    {
        [Fact]
        public void Test()
        {
            var queryBuilder = new CosmosQueryBuilder();

            var query = queryBuilder.Where()
                                    .TitleContains("stu")
                                    .And()
                                    .ContentContains("that")
                                    .Build();

            Assert.Equal("SELECT * FROM c WHERE contains(lower(c.title), lower('stu')) AND contains(lower(c.content), lower('that'))", query);
        }
    }
}