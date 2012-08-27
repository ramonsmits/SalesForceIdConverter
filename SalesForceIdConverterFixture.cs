using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalesForceUtils.Tests
{
	[TestClass]
	public class SalesForceIdConverterFixture
	{
		[TestMethod]
		public void From()
		{
			Assert.AreEqual(1, SalesForceIdConverter.From("000000000000001"));
			Assert.AreEqual(62, SalesForceIdConverter.From("000000000000010"));
			Assert.AreEqual(3844, SalesForceIdConverter.From("000000000000100"));
			Assert.AreEqual(238328, SalesForceIdConverter.From("000000000001000"));
			Assert.AreEqual(14776336, SalesForceIdConverter.From("000000000010000"));
			Assert.AreEqual(916132832, SalesForceIdConverter.From("000000000100000"));
			Assert.AreEqual(56800235584, SalesForceIdConverter.From("000000001000000"));
			Assert.AreEqual(3521614606208, SalesForceIdConverter.From("000000010000000"));
			Assert.AreEqual(218340105584896, SalesForceIdConverter.From("000000100000000"));
			Assert.AreEqual(13537086546263552, SalesForceIdConverter.From("000001000000000"));
			Assert.AreEqual(839299365868340224, SalesForceIdConverter.From("000010000000000"));
			Assert.AreEqual(52036560683837093888m, SalesForceIdConverter.From("000100000000000"));
			Assert.AreEqual(3226266762397899821056m, SalesForceIdConverter.From("001000000000000"));
			Assert.AreEqual(200028539268669788905472m, SalesForceIdConverter.From("010000000000000"));
			Assert.AreEqual(12401769434657526912139264m, SalesForceIdConverter.From("100000000000000"));
			Assert.AreEqual(756507935514109141640495102m, SalesForceIdConverter.From("yzzzzzzzzzzzzzy"));
			Assert.AreEqual(756507935514109141640495103m, SalesForceIdConverter.From("yzzzzzzzzzzzzzz"));
		}

		[TestMethod]
		public void ToFrom()
		{
			ToFrom("00330000000xEft");//
			ToFrom("yzzzzzzzzzzzzzz");
		}

		public void ToFrom(string i)
		{
			Console.WriteLine(i);
			var o = SalesForceIdConverter.To(SalesForceIdConverter.From(i), false);
			Assert.AreEqual(i, o, "Input is not equal to output.");
		}

		[TestMethod]
		public void FromTo()
		{
			FromTo(0);
			FromTo(1);
			FromTo(1234567890);
			FromTo(756507935514109141640495103m);
		}

		public static void FromTo(decimal i)
		{
			Console.WriteLine(i);
			var o = SalesForceIdConverter.From(SalesForceIdConverter.To(i));
			Assert.AreEqual(i, o, "Input is not equal to output.");
		}

		[TestMethod]
		public void Checksum()
		{
			Checksum("001R000000gWdndIAC");
			Checksum("001R000000hj0SKIAY");
			Checksum("001R000000gYo01IAC");
			Checksum("001R000000isdd3IAA");
			Checksum("003R000000dvDNOIA2");
		}

		public void Checksum(string v)
		{
			Assert.AreEqual(v.Substring(15, 3), SalesForceIdConverter.GenerateChecksum(v.Substring(0, 15)).Substring(15, 3));
		}
	}
}