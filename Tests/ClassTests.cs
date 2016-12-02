using System.Collections.Generic;
using Xunit;
namespace NumbersToWords.Objects
{
	public class NumberWordTest
	{
    [Fact]
    public void GetWords_SingleDigit_One()
    {
      Assert.Equal("One", NumberWord.GetWords(1));
    }
    [Fact]
    public void GetWords_TenDigit_Ten()
    {
      Assert.Equal("Ten", NumberWord.GetWords(10));
    }
    [Fact]
    public void GetWords_OneHundredDigit_OneHundred()
    {
      Assert.Equal("One Hundred", NumberWord.GetWords(100));
    }
		[Fact]
		public void GetWords_OneThousandDigit_OneThousand()
		{
			Assert.Equal("One Thousand", NumberWord.GetWords(1000));
		}
		[Fact]
		public void GetWords_TenThousandDigit_TenThousand()
		{
			Assert.Equal("Twenty Thousand", NumberWord.GetWords(20000));
		}
		[Fact]
		public void GetWords_TenThousandDigit_OneMillion()
		{
			Assert.Equal("One Million", NumberWord.GetWords(1000000));
		}
  }
}
