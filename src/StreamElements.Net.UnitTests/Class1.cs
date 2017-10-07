using System;
using System.Threading.Tasks;
using Xunit;

namespace StreamElements.Net.UnitTests
{
    public class Main
    {

        [Fact]
        public async Task Init()
        {
            var client = new StreamElements.Net.RestClient();
            await Assert.ThrowsAsync<ArgumentNullException>(()=>client.GetLoyalty(null));
            var loyalty = await client.GetLoyalty("terrible_dev");
            Assert.True(loyalty.Enabled);
        }
    }
}
