﻿using Gremlin.Net.CosmosDb.Structure;
using Gremlin.Net.Process.Remote;
using Gremlin.Net.Process.Traversal;

namespace Gremlin.Net.CosmosDb
{
	/// <summary>
	/// A graph traversal source (g)
	/// </summary>
	/// <seealso cref="Gremlin.Net.CosmosDb.IGraphTraversalSource"/>
	public class GraphTraversalSource : IGraphTraversalSource
	{
		private readonly Process.Traversal.GraphTraversalSource _graphTraversalSource;

		public virtual Process.Traversal.GraphTraversalSource G()
		{
			return _graphTraversalSource;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GraphTraversalSource"/> class.
		/// </summary>
		public GraphTraversalSource(IRemoteConnection remote = null)
		{
			_graphTraversalSource = AnonymousTraversalSource.Traversal();

			_graphTraversalSource.Bytecode.AddSource("g");

			if (remote != null)
				_graphTraversalSource = _graphTraversalSource.WithRemote(remote);
		}

		/// <summary>
		/// Spawns a <see cref="GraphTraversal{SType, EType}"/> off this graph traversal source and adds the addV step to
		/// that traversal.
		/// </summary>
		/// <returns>Returns the traversal</returns>
		public GraphTraversal<Gremlin.Net.Structure.Vertex, Gremlin.Net.Structure.Vertex> AddV()
		{
			return _graphTraversalSource.AddV();
		}

		/// <summary>
		/// Spawns a <see cref="GraphTraversal{SType, EType}"/> off this graph traversal source and adds the addV step to
		/// that traversal.
		/// </summary>
		/// <param name="label">The vertex label</param>
		/// <returns>Returns the traversal</returns>
		public GraphTraversal<Gremlin.Net.Structure.Vertex, Gremlin.Net.Structure.Vertex> AddV(string label)
		{
			return _graphTraversalSource.AddV(label);
		}

		/// <summary>
		/// Spawns a <see cref="GraphTraversal{SType, EType}"/> off this graph traversal source and adds the addV step to
		/// that traversal.
		/// </summary>
		/// <param name="vertexLabelTraversal">The vertex label traversal</param>
		/// <returns>Returns the traversal</returns>
		public GraphTraversal<Gremlin.Net.Structure.Vertex, Gremlin.Net.Structure.Vertex> AddV(ITraversal vertexLabelTraversal)
		{
			return _graphTraversalSource.AddV(vertexLabelTraversal);
		}

		/// <summary>
		/// Spawns a <see cref="GraphTraversal{SType, EType}"/> off this graph traversal source and adds the E step to
		/// that traversal.
		/// </summary>
		/// <param name="edgesIds">Unique Identifiers of edges to start the traversal with</param>
		/// <returns>Returns the traversal</returns>
		public GraphTraversal<Gremlin.Net.Structure.Edge, Gremlin.Net.Structure.Edge> E(params object[] edgesIds)
		{
			return _graphTraversalSource.E(edgesIds);
		}

		/// <summary>
		/// Spawns a <see cref="GraphTraversal{SType, EType}"/> off this graph traversal source and adds the V step to
		/// that traversal.
		/// </summary>
		/// <returns></returns>
		public GraphTraversal<Gremlin.Net.Structure.Vertex, Gremlin.Net.Structure.Vertex> V()
		{
			return _graphTraversalSource.V();
		}

		/// <summary>
		/// Spawns a <see cref="GraphTraversal{SType, EType}"/> off this graph traversal source and adds the V step to
		/// that traversal.
		/// </summary>
		/// <param name="vertexIds">Unique Identifiers of vertices to start the traversal with</param>
		/// <returns></returns>
		public GraphTraversal<Gremlin.Net.Structure.Vertex, Gremlin.Net.Structure.Vertex> V(params object[] vertexIds)
		{
			return _graphTraversalSource.V(vertexIds);
		}

		/// <summary>
		/// Spawns a <see cref="GraphTraversal{SType, EType}"/> off this graph traversal source and adds the V step to
		/// that traversal.
		/// </summary>
		/// <param name="pairs">Unique Identifiers of vertices to start the traversal with</param>
		/// <returns></returns>
		public GraphTraversal<Gremlin.Net.Structure.Vertex, Gremlin.Net.Structure.Vertex> V(params PartitionKeyIdPair[] pairs)
		{
			return _graphTraversalSource.V(pairs);
		}
	}
}