﻿namespace DesignPatterns.SOLID;

/// <summary>
/// Journal responsible for keeping entries and only for keeping entries
/// </summary>
public class Journal
{
    private readonly List<string> entries = new List<string>();

    private static int count = 0;

    public int AddEntry(string text)
    {
        entries.Add($"{++count}: {text}");
        return count; // memento pattern!
    }

    public void RemoveEntry(int index)
    {
        entries.RemoveAt(index);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, entries);
    }

    // breaks single responsibility principle
    public void Save(string filename, bool overwrite = false)
    {
        File.WriteAllText(filename, ToString());
    }
    
    // breaks single responsibility principle
    public void Load(string filename)
    {
      
    }
    
    // breaks single responsibility principle
    public void Load(Uri uri)
    {
      
    }
}
