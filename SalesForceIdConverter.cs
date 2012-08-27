using System;
using System.Text;

namespace SalesForceUtils
{
	internal static class BaseConverter
	{
		public static string ToBase(decimal input, string baseChars)
		{
			StringBuilder r = new StringBuilder(15);
			int targetBase = baseChars.Length;
			do
			{
				r.Insert(0, baseChars[(int)(input % targetBase)]);
				input /= targetBase;
			} while (input > 0);

			return r.ToString();
		}

		public static decimal FromBase(string input, string baseChars)
		{
			int srcBase = baseChars.Length;
			decimal id = 0;

			var r = input.ToCharArray();
			Array.Reverse(r);

			for (int i = 0; i < r.Length; i++)
			{
				int charIndex = baseChars.IndexOf(r[i]);
				id += charIndex * Pow(srcBase, i);
			}

			return id;
		}

		static decimal Pow(decimal basis, int power)
		{
			decimal res = 1;
			for (int i = 0; i < power; i++, res *= basis) ;
			return res;
		}
	}

	public static class SalesForceIdConverter
	{
		private const string Base62 = "0123456789" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "abcdefghijklmnopqrstuvwxyz";

		public static decimal From(string salesForceId)
		{
			if(string.IsNullOrEmpty(salesForceId)) throw new ArgumentNullException("salesForceId");

			if (salesForceId.Length == 18)
			{
				salesForceId = salesForceId.Substring(0, 15);
			}
			else if (salesForceId.Length != 15)
			{
				throw new ArgumentException("Invalid salesforce key as lenght is not 15 of 18 characters", "salesForceId");
			}

			var r = BaseConverter.FromBase(salesForceId, Base62);
			return r;
		}

		public static string To(decimal id)
		{
			return To(id, true);
		}

		public static string To(decimal id, bool withChecksum)
		{
			if (id < 0) throw new ArgumentException("Negative values are not supported.", "id");
			if (id > 756507935514109141640495103m) throw new ArgumentException("Value is larger then SalesForceID capacity", "id");

			var r = BaseConverter.ToBase(id, Base62);
			r = r.TrimStart('0').PadLeft(15, '0');
			if (withChecksum) r = GenerateChecksum(r);
			return r;
		}

		private static readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ012345";

		public static string GenerateChecksum(string id)
		{
			if (id.Length != 15) throw new ArgumentException("Lenght not equal to 15", "id");

			var output = new StringBuilder(id);

			for (int i = 0; i < 3; i++)
			{
				int flags = 0;
				for (int j = 0; j < 5; j++)
				{
					var c = id[i * 5 + j];
					if (char.IsUpper(c))
					{
						flags += (1 << j);
					}
				}

				output.Append(chars[flags]);
			}

			return output.ToString();
		}
	}
}