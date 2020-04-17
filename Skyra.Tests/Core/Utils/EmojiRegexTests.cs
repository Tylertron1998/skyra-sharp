using JetBrains.Annotations;
using NUnit.Framework;
using Skyra.Core.Utils;

namespace Skyra.Tests.Core.Utils
{
	public class EmojiRegexTests
	{
		[Test]
		public void EmojiRegex_Match([Values(
				"😀", "😃", "😄", "😁", "😆", "😅", "🤣", "😂", "🙂", "🙃", "😉", "😊", "😇", "🥰", "😍", "🤩", "😘",
				"😗", "😚", "😙", "😋", "😛", "😜", "🤪", "😝", "🤑", "🤗", "🤭", "🤫", "🤔", "🤐", "🤨", "😐", "😑",
				"😶", "😏", "😒", "🙄", "😬", "🤥", "😌", "😔", "😪", "🤤", "😴", "😷", "🤒", "🤕", "🤢", "🤮", "🤧",
				"🥵", "🥶", "🥴", "😵", "🤯", "🤠", "🥳", "😎", "🤓", "🧐", "😕", "😟", "🙁", "😮", "😯", "😲", "😳",
				"🥺", "😦", "😧", "😨", "😰", "😥", "😢", "😭", "😱", "😖", "😣", "😞", "😓", "😩", "😫", "🥱", "😤",
				"😡", "😠", "🤬", "😈", "👿", "💀", "💩", "🤡", "👹", "👺", "👻", "👽", "👾", "🤖", "😺", "😸", "😹",
				"😻", "😼", "😽", "🙀", "😿", "😾", "🙈", "🙉", "🙊"
			)]
			[NotNull]
			string emoji
		)
		{
			Assert.IsTrue(EmojiRegex.Regex.IsMatch(emoji));
		}

		[Test]
		public void EmojiRegex_NotMatch([Values(
				"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t",
				"u", "v", "w", "x", "y", "z", "ア"
			)]
			[NotNull]
			string emoji
		)
		{
			Assert.IsFalse(EmojiRegex.Regex.IsMatch(emoji));
		}
	}
}
