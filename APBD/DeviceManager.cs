namespace APBD;

public class DeviceManager
{
    private string _filePath;
    private List<Device> _devices = new();
    public List<Device> Devices => _devices; 
    
    public DeviceManager(string filePath)
    {
        _filePath = filePath;

        if (!File.Exists(_filePath))
        {
            Console.WriteLine("File not found ");
        }
        else
        {
            LoadDevices();
        }
    }

    private void LoadDevices()
    {
        string[] lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            if (_devices.Count >= 15)
            {
                Console.WriteLine("Limit of devices is 15");
                break;
            }

            string[] parts = line.Split(",");
            Device device = parts[0] switch
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
                    parts.Length >= 4 ? parts[3] : null),

                string ed when ed.StartsWith("ED-") => CreateEmbeddedDeviceSafely(
                    parts[0],
                    parts[1],
                    parts[2],
                    parts[3])
                ,
                _ => null
            };
                if (device != null)
                {
                    _devices.Add(device);
                }
        }
    }
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
    public Device? GetDevice(string id)
    {
        return _devices.FirstOrDefault(d => d.Id == id);
    }
    
    public void AddDevice(Device device)
    {
        if (_devices.Count >= 15)
        {
            Console.WriteLine("Limit of devices is 15");
            return;
        }
        _devices.Add(device);
        Console.WriteLine($"{device.Name} added");
    }

    public void RemoveDevice(string id)
    {
        var device = _devices.FirstOrDefault(d => d.Id == id);
    
        if (device == null)
        {
            Console.WriteLine($"Device with ID '{id}' not found.");
            return;
        }

        _devices.Remove(device);
        Console.WriteLine($"{device.Name} was removed.");
    }

    public void EditDevice(string id, string propertyName, object value)
    {
        Device device = _devices.FirstOrDefault(d => d.Id == id);
        var propInfo = device.GetType().GetProperty(propertyName);
        
        try
        {
            propInfo.SetValue(device, Convert.ChangeType(value, propInfo.PropertyType));
            Console.WriteLine($"Device '{device.Name}' updated: {propertyName} = {value}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating property: {ex.Message}");
        }
    }
    public void TurnOnDevice(string id)
    {
        Device device = _devices.FirstOrDefault(d => d.Id == id);
        try
        {
            device.TurnOn();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error turning on device: {ex.Message}");
        }
    }

    public void TurnOffDevice(string id)
    {
        Device device = _devices.FirstOrDefault(d => d.Id == id);
        device.TurnOff();
    }
    
    
    public void ShowAllDevices()
    {
        foreach (var device in _devices)
        {
            Console.WriteLine(device.ToString());
            Console.WriteLine("=======");
        }
    }
    
    public void SaveDataToFile()
    {
        var lines = _devices.Select(device => device.SavingFormat());
        File.WriteAllLines(_filePath, lines);
        Console.WriteLine("All devices saved successfully.");
    }
    
}