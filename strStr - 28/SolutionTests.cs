using Xunit;

namespace strStr___28;

public class SolutionTests
{
    private Solution _solution;
    
    public SolutionTests()
    {
        _solution = new();
    }
    
    [Fact]
    public void HandleEmptyString()
    {
        DoTest("", "", 0);
    }

    [Theory]
    [InlineData("abc","a",0)]
    [InlineData("abc","b",1)]
    [InlineData("abc","c",2)]
    [InlineData("abc","d",-1)]
    public void NeedleIs_OneCharacter(string haystack, string needle, int expected)
    {
        DoTest(haystack, needle, expected);
    }

    [Theory]
    [InlineData("abcde","ab",0)]
    [InlineData("abcde","bc",1)]
    [InlineData("abcde","cd",2)]
    [InlineData("abcde","de",3)]
    public void NeedleIs_TwoCharacters(string haystack, string needle, int expected)
    {
        DoTest(haystack, needle, expected);
    }
    
    [Theory]
    [InlineData("hello","ll",2)]
    [InlineData("aaaaa","bc",-1)]
    [InlineData("mississippi","issip",4)]
    [InlineData("mississippi","pi",9)]
    [InlineData("aabaaabaaac","aabaaac",4)]
    public void LeetCodeTests(string haystack, string needle, int expected)
    {
        DoTest(haystack, needle, expected);
    }
    
    [Fact]
    public void HaystackShorterThanNeedle()
    {
        DoTest("abc", "qwerty", -1);
    }

    private void DoTest(string haystack, string needle, int expected)
    {
        int ret = _solution.StrStr(haystack, needle);
        Assert.Equal(expected, ret);
    }
}