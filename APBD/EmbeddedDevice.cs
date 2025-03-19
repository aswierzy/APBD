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
                throw new ArgumentException($"Invalid IP address format: {value}");
            }
            _ipAddress = value;
        }
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
        throw new NotImplementedException();
    }
}