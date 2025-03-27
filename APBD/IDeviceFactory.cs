namespace APBD;

public interface IDeviceFactory
{
    /// <summary>
    /// Creates a device from a line of text.
    /// </summary>
    Device? CreateDevice(string line);
}