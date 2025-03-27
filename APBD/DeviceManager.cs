namespace APBD;

public class DeviceManager
{
    private string _filePath;
    private List<Device> _devices = new();
    public List<Device> Devices => _devices; 
    private readonly IDeviceFileService _fileService;
    private readonly IDeviceFactory _deviceFactory;
    
    public DeviceManager(string filePath, IDeviceFileService fileService, IDeviceFactory deviceFactory)
    {
        _filePath = filePath;
        _fileService = fileService;
        _deviceFactory = deviceFactory;
        
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("File not found ");
        }
        else
        {
            LoadDevices();
        }
    }

    
    /// <summary>
    /// Loads devices from the file.
    /// </summary>
    private void LoadDevices()
    {
        string[] lines = _fileService.ReadAllLines(_filePath).ToArray();
        foreach (var line in lines)
        {
            if (_devices.Count >= 15)
            {
                Console.WriteLine("Limit of devices is 15");
                break;
            }
            var device = _deviceFactory.CreateDevice(line);
            if (device != null)
            {
                _devices.Add(device);
            }
        }
    }
    
    /// <summary>
    /// Gets a device by its ID.
    /// </summary>
    public Device? GetDevice(string id)
    {
        return _devices.FirstOrDefault(d => d.Id == id);
    }
    
    /// <summary>
    /// Adds a new device.
    /// </summary>
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

    /// <summary>
    /// Removes a device by its ID.
    /// </summary>
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

    /// <summary>
    /// Edits a property of a device.
    /// </summary>
    public void EditDevice(string id, string propertyName, object value)
    {
        var device = _devices.FirstOrDefault(d => d.Id == id);
        if (device == null)
        {
            Console.WriteLine($"Device with ID '{id}' not found.");
            return;
        }
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
    
    /// <summary>
    /// Edits a property of a device.
    /// </summary>
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

    /// <summary>
    /// Turns off a device by its ID.
    /// </summary>
    public void TurnOffDevice(string id)
    {
        Device device = _devices.FirstOrDefault(d => d.Id == id);
        device.TurnOff();
    }
    
    /// <summary>
    /// Displays all devices.
    /// </summary>
    public void ShowAllDevices()
    {
        foreach (var device in _devices)
        {
            Console.WriteLine(device.ToString());
            Console.WriteLine("=======");
        }
    }
    
    
    /// <summary>
    /// Saves all devices to the file.
    /// </summary>
    public void SaveDataToFile()
    {
        var lines = _devices.Select(device => device.SavingFormat());
        File.WriteAllLines(_filePath, lines);
        Console.WriteLine("All devices saved successfully.");
    }
    
}