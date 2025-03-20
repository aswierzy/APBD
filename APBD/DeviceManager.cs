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
            if (parts[0].Contains("SW") | parts[0].Contains("P") | parts[0].Contains("ED"))
            {
                Device device = parts[0] switch
                {
                    string sw when sw.StartsWith("SW-") => new Smartwatch(
                        ExtractId(parts[0]), 
                        parts[1], 
                        Boolean.Parse(parts[2]), 
                        int.Parse(parts[3].Replace("%", ""))
                    )
                   ,
                    
                    string p when p.StartsWith("P-") => new PersonalComputer(
                        ExtractId(parts[0]), 
                        parts[1], 
                        Boolean.Parse(parts[2]), 
                        parts.Length >= 4 ? parts[3] : null)
                    ,
                    
                    string ed when ed.StartsWith("ED-") => new EmbeddedDevice(
                        ExtractId(parts[0]), 
                        parts[1], 
                        parts[2], 
                        parts[3])
                };
                
                _devices.Add(device);
            }


        }

       
    }
    private int ExtractId(string s)
    {
        string[] extractId = s.Split("-");
        return int.Parse(extractId[1]);
    }

    public Device? GetDevice(Device device)
    {
        return _devices.FirstOrDefault(d => d.Equals(device));
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

    public void RemoveDevice(Device device)
    {
        _devices.Remove(device);
        Console.WriteLine($"{device.Name} was removed");
    }

    public void EditDevice(Device device, string propertyName, object value)
    {
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
    public void TurnOnDevice(Device device)
    {
        try
        {
            device.TurnOn();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error turning on device: {ex.Message}");
        }
    }

    public void TurnOffDevice(Device device)
    {
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