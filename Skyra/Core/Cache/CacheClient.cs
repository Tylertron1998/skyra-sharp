﻿using System.Linq;
using System.Threading.Tasks;
using Skyra.Core.Cache.Stores;
using Spectacles.NET.Rest.Redis;
using StackExchange.Redis;

namespace Skyra.Core.Cache
{
	public sealed class CacheClient
	{
		internal CacheClient(IClient client, string prefix)
		{
			Prefix = prefix;
			Client = client;
			Channels = new ChannelStore(this);
			GuildChannels = new GuildChannelStore(this);
			EditableMessages = new EditableMessagesStore(this);
			GuildEmojis = new GuildEmojiStore(this);
			Guilds = new GuildStore(this);
			GuildMembers = new GuildMemberStore(this);
			Messages = new MessageStore(this);
			GuildRoles = new GuildRoleStore(this);
			Users = new UserStore(this);
			VoiceStates = new VoiceStateStore(this);
		}

		internal string Prefix { get; }
		internal IClient Client { get; }
		public ConnectionPool Pool { get; } = new ConnectionPool();

		internal ConnectionMultiplexer BestConnection => Pool.BestConnection;

		internal IDatabase Database => BestConnection.GetDatabase();

		public IServer Redis => BestConnection.GetEndPoints().Select(endPoint => BestConnection.GetServer(endPoint))
			.FirstOrDefault(server => !server.IsSlave);

		public ChannelStore Channels { get; }

		public GuildChannelStore GuildChannels { get; }

		public EditableMessagesStore EditableMessages { get; }

		public GuildEmojiStore GuildEmojis { get; }

		public GuildStore Guilds { get; }

		public GuildMemberStore GuildMembers { get; }

		public MessageStore Messages { get; }

		public GuildRoleStore GuildRoles { get; }

		public UserStore Users { get; }

		public VoiceStateStore VoiceStates { get; }

		public async Task ConnectAsync(string url)
		{
			var options = ConfigurationOptions.Parse(url);
			await Pool.ConnectAsync(options);
		}

		public async Task SetClientUserAsync(string id)
		{
			await Database.StringSetAsync($"{Prefix}:CLIENT_ID", id);
		}

		public async Task<ulong?> GetClientUserAsync()
		{
			var result = await Database.StringGetAsync($"{Prefix}:CLIENT_ID");
			return string.IsNullOrEmpty(result) ? (ulong?) null : ulong.Parse(result);
		}
	}
}
