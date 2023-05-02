using System.Text;

namespace DesignPatterns.SOLID;

/// <summary>
/// Persistence responsible for Saving Journal
/// handles the responsibility of persisting objects
/// </summary>
public class Persistence
{
    public void SaveToFile(Journal journal, string filename, bool overwrite = false)
    {
        if (overwrite || File.Exists(filename))
        {
            File.WriteAllText(filename, journal.ToString(), Encoding.UTF8);
        }
    }
}