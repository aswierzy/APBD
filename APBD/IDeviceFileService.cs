namespace APBD;

public interface IDeviceFileService
{
    /// <summary>
    /// Checks if a file exists.
    /// </summary>
    bool FileExists(string filePath);

    /// <summary>
    /// Reads all lines from a file.
    /// </summary>
    IEnumerable<string> ReadAllLines(string filePath);

    /// <summary>
    /// Writes lines to a file.
    /// </summary>
    void WriteAllLines(string filePath, IEnumerable<string> lines);
}