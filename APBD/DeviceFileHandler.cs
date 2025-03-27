namespace APBD;

public class DeviceFileHandler : IDeviceFileService
{
    /// <summary>
    /// Checks if a file exists.
    /// </summary>
    public bool FileExists(string filePath) => File.Exists(filePath);

    /// <summary>
    /// Reads all lines from a file.
    /// </summary>
    public IEnumerable<string> ReadAllLines(string filePath) => File.ReadAllLines(filePath);

    /// <summary>
    /// Writes lines to a file.
    /// </summary>
    public void WriteAllLines(string filePath, IEnumerable<string> lines) => File.WriteAllLines(filePath, lines);
}   