namespace APBD;

public class DeviceManagerFactory
{
    /// <summary>
    /// Creates an instance of DeviceManager with necessary dependencies.
    /// </summary>
    public static DeviceManager CreateDeviceManager(string filePath)
    {
        IDeviceFileService fileService = new DeviceFileHandler();
        IDeviceFactory deviceFactory = new DeviceFactory();
        return new DeviceManager(filePath, fileService, deviceFactory);
    }
}