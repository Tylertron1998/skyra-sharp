using Skyra.Core.Cache.Models;
using Skyra.Core.Cache.Stores.Base;

namespace Skyra.Core.Cache.Stores
{
	public sealed class UserStore : SetCacheStoreBase<CoreUser>
	{
		internal UserStore(CacheClient context) : base(context, "users")
		{
		}

		protected override string GetKey(CoreUser value)
		{
			return value.Id.ToString();
		}
	}
}
