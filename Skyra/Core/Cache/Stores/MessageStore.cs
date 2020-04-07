using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Skyra.Core.Cache.Models;
using Skyra.Core.Cache.Stores.Base;

namespace Skyra.Core.Cache.Stores
{
	public sealed class MessageStore : SetCacheStoreBase<CoreMessage>
	{
		internal MessageStore(CacheClient context) : base(context, "messages")
		{
		}

		public override async Task SetAsync(CoreMessage entry, string? parent = null)
		{
			var id = FormatKeyName(parent, GetKey(entry));
			await Database.StringSetAsync(id, SerializeValue(entry));
			await Database.KeyExpireAsync(id, TimeSpan.FromMinutes(20));
		}

		[NotNull]
		protected override string GetKey([NotNull] CoreMessage value)
		{
			return value.Id.ToString();
		}
	}
}
