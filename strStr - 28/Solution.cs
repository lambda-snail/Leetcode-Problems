using System;

public class Solution {
    public int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrWhiteSpace(needle)) return 0;

        int index = -1;
        ReadOnlySpan<char> haystackSpan = haystack.AsSpan();
        ReadOnlySpan<char> needleSpan = needle.AsSpan();
        char firstChar = needleSpan[0];
        for (int i = 0; i <= (haystack.Length - needle.Length); ++i)
        {
            if (haystackSpan[i] == firstChar)
            {
                bool found = CheckForNeedle(haystackSpan, needleSpan, i);
                if (!found)
                {
                    //i += 1; //needle.Length; Check could return how many steps have been searched!
                }
                else
                {
                    index = i;
                    break;
                }
            }
        }

        return index;
    }

    private bool CheckForNeedle(ReadOnlySpan<char> haystackSpan, ReadOnlySpan<char> needleSpan, int index)
    {
        bool found = true;
        for (int i = 1; i < needleSpan.Length; ++i)
        {
            found &= haystackSpan[index + i] == needleSpan[i];
            if (!found) break;
        }

        return found;
    }
}