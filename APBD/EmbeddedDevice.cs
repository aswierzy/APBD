using System.Text.RegularExpressions;

namespace APBD;

public class EmbeddedDevice : Device
{
    public string NetworkName { get; set; }
    private Regex _ipRegex = new (@"^(?:\d{1,3}\.){3}\d{1,3}$");
    private string _ipAddress;
    public string IPAddress
    {
        get { return _ipAddress; }
        set
        {
            if (!_ipRegex.IsMatch(value))
            {
                //throw new ArgumentException($"Invalid IP address format: {value}");
                _ipAddress = "Invalid IP Address";
            }
            else
            {
                _ipAddress = value;

            }
        }
    }
    public EmbeddedDevice(int id, string name, string ipAddress, string network)
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
            throw new ConnectionException();
        }

        Console.WriteLine($"{Name} successfully connected to {NetworkName}.");
        
    }

    public void TurnOn()
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
        return $"ED-{Id},{Name},{IPAddress},{NetworkName}";
    }
}