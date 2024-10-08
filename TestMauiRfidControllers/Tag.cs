﻿namespace Test.Entities;

public class Tag 
{
    public Tag(string tagId, int number)
    {
		TagId = tagId;
        Number = number;
    }

    public string TagId { get; private set; }
    public int Number { get; }

    public string PrepareToWrite()
    {
        const char EMPTY_CHAR = '0';
        var number = Number.ToString().PadLeft(3, EMPTY_CHAR);
        var position = "abcdef".PadLeft(6, EMPTY_CHAR); // present for legacy compatibility
        return number + position + TagId;
    }

    public override string ToString()
	{
        return $"{"Tag Id"}: {TagId}";
    }
}
