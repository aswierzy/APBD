using System.Text.RegularExpressions;

namespace APBD;

public class EmbeddedDevice : Device
{
    public string NetworkName { get; set; }
    private Regex _ipRegex = new (@"^(?:\d{1,3}\.){3}\d{1,3}$");
    private string _ipAddress;
    private bool _connected;
    public string IPAddress
    {
        get { return _ipAddress; }
        set
        {
            if (!_ipRegex.IsMatch(value))
            {
                _ipAddress = "Invalid IP Address";
                throw new ArgumentException($"Invalid IP address format: {value}");
            }
            else
            {
                _ipAddress = value;

            }
        }
    }
    public EmbeddedDevice(string id, string name, string ipAddress, string network)
    {
        Id = id;
        Name = name;
        IPAddress = ipAddress;
        NetworkName = network;
    }
    public void Connect()
    {
        if (!NetworkName.Contains("MD Ltd."))
        {
            _connected = false;
            throw new ConnectionException();
        }

        _connected = true;
        Console.WriteLine($"{Name} successfully connected to {NetworkName}.");
        
    }

    public override void TurnOn()
    {
        Connect();
        base.TurnOn();
    }
    
    
    public override string ToString()
    {
        return $"ID: {Id} | Name: {Name} | IP Address: {IPAddress} | Network Name: {NetworkName}";
    }

    public override string SavingFormat()
    {
        return $"{Id},{Name},{IPAddress},{NetworkName}";
    }
}