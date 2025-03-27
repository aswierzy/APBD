namespace APBD;

public class DeviceFactory : IDeviceFactory
{
    /// <summary>
    /// Creates a device from a line of text.
    /// </summary>
    public Device? CreateDevice(string line)
    {
        string[] parts = line.Split(",");
        if (parts.Length == 0) return null;
        try
        {
            return parts[0] switch
            {
                string sw when sw.StartsWith("SW-") => new Smartwatch(
                    parts[0],
                    parts[1],
                    Boolean.Parse(parts[2]),
                    int.Parse(parts[3].Replace("%", ""))
                ),
                string p when p.StartsWith("P-") => new PersonalComputer(
                    parts[0],
                    parts[1],
                    Boolean.Parse(parts[2]),
                    parts.Length >= 4 ? parts[3] : null
                ),
                string ed when ed.StartsWith("ED-") => new EmbeddedDevice(
                    parts[0],
                    parts[1],
                    parts[2],
                    parts[3]
                ),
                _ => null
            };
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Skipping device due to error: {ex.Message}");
            return null;
        }
        
    }
    
    /// <summary>
    /// Safely creates an EmbeddedDevice instance. Catches invalid IP address errors.
    /// </summary>
    private EmbeddedDevice? CreateEmbeddedDeviceSafely(string id, string name, string ip, string network)
    {
        try
        {
            return new EmbeddedDevice(id, name, ip, network);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Skipping device due to invalid IP: {ex.Message}");
            return null;
        }
    }
}