using System.Threading.Tasks;
using Skyra.Core;
using Skyra.Core.Structures;
using Skyra.Core.Structures.Attributes;
using Skyra.Core.Structures.Usage;
using Spectacles.NET.Types;

namespace Skyra.Arguments
{
	[Resolver(typeof(int), "integer")]
	public class Int32Resolver : StructureBase
	{
		public Int32Resolver(Client client) : base(client)
		{
		}

		public Task<int> ResolveAsync(Message message, CommandUsageOverloadArgument argument, string content)
		{
			var resolved = int.Parse(content);
			return Task.FromResult(resolved);
		}
	}
}
