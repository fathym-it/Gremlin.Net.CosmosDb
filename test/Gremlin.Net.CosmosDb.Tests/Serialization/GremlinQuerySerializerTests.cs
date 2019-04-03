using FluentAssertions;
using Gremlin.Net.Driver;
using Gremlin.Net.Driver.Remote;
using Gremlin.Net.Process.Traversal;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using Xunit;

namespace Gremlin.Net.CosmosDb.Serialization
{
	public class GremlinQuerySerializerTests
	{
		[Fact]
		private void gVFix()
		{
			var client = new Mock<IGremlinClient>();

			var g = new GraphTraversalSource(new DriverRemoteConnection(client.Object));

			var entQuery = g.V().HasLabel("Enterprise")
				.Has("Registry", "xxx")
				.Has("PrimaryAPIKey", "XXX");

			var appQuery = g.V(("aaa", "AAA"))
				.HasLabel("Application")
				.Has("Registry", "xxx2");

			var query = g.V(entQuery).AddE("Owns").To(appQuery).ToGremlinQuery();

			query.Should().Be("g.V(g.V().hasLabel(\"Enterprise\").has(\"Registry\",\"xxx\").has(\"PrimaryAPIKey\",\"XXX\")).addE(\"Owns\").to(g.V([\"aaa\", \"AAA\"]).hasLabel(\"Application\").has(\"Registry\",\"xxx2\"))");
		}

		[Fact]
		private void gV__Fix()
		{
			var client = new Mock<IGremlinClient>();

			var g = new GraphTraversalSource(new DriverRemoteConnection(client.Object));

			var entQuery = g.V()
				.BothE().Where(__.InV().HasId("1234"));

			var query = entQuery.ToGremlinQuery();

			query.Should().Be("g.V().bothE().where(__.inV().hasId(\"1234\"))");
		}
	}
}