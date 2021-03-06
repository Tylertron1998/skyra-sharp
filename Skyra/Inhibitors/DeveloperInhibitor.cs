using System.Linq;
using System.Threading.Tasks;
using Skyra.Core;
using Skyra.Core.Cache.Models;
using Skyra.Core.Structures;
using Skyra.Core.Structures.Attributes;
using Skyra.Core.Structures.Base;

namespace Skyra.Inhibitors
{
	[Inhibitor]
	public class DeveloperInhibitor : StructureBase, IInhibitor
	{
		public DeveloperInhibitor(IClient client) : base(client)
		{
		}

		public Task<bool> RunAsync(CoreMessage message, CommandInfo command)
		{
			return Task.FromResult(!Client.Owners.Contains(message.AuthorId));
		}
	}
}
