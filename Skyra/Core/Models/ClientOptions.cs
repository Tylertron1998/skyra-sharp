using System.Linq;

namespace Skyra.Core.Models
{
	internal readonly ref struct ClientOptions
	{
		public string Token { get; }
		public string BrokerName { get; }
		public string BrokerUri { get; }
		public string RedisPrefix { get; }
		public string RedisUri { get; }
		public ulong[] Owners { get; }

		public ClientOptions(string token, string brokerName, string brokerUri, string redisPrefix, string redisUri,
			string? owners)
		{
			Token = token;
			BrokerName = brokerName;
			BrokerUri = brokerUri;
			RedisPrefix = redisPrefix;
			RedisUri = redisUri;
			Owners = string.IsNullOrEmpty(owners) ? new ulong[0] : owners.Split(",").Select(ulong.Parse).ToArray();
		}
	}
}
