namespace APBD;

public class Smartwatch : Device,IPowerNotifier
{
    private int _batteryLevel;
    /// <summary>
    /// Gets or sets the battery level.
    /// </summary>
    public int BatteryLevel
    {
        get => _batteryLevel;
        
        set
        {
            if (value < 0 | value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(BatteryLevel), "Battery percentage must be between 0 and 100.");
            }
            else
            {
                _batteryLevel = value;
                if (_batteryLevel < 20)
                {
                    Notify();
                }
            }
        }
    }


    public Smartwatch(string id, string name, bool isTurnedOn, int batteryLevel)
    {
        Id = id;
        Name = name;
        IsDeviceTurnedOn = isTurnedOn;
        BatteryLevel = batteryLevel;
    }
    
    /// <summary>
    /// Notifies if battery level is low.
    /// </summary>
    public  void Notify()
    {
        Console.WriteLine("Battery is less than 20%");
    }

    /// <summary>
    /// Turns the device on. Throws an exception if battery is too low.
    /// </summary>
    public override void TurnOn()
    {
        if (BatteryLevel < 11)
        {
            throw new EmptyBatteryException();
        }

        base.TurnOn();
        BatteryLevel -= 10;
        Console.WriteLine("Current battery level: " + BatteryLevel + "%");
    }

    /// <summary>
    /// Returns a string representation of the smartwatch.
    /// </summary>
    public override string ToString()
    {
        return $"ID: {Id} | Name: {Name} | Running: {IsDeviceTurnedOn} | Battery Level: {_batteryLevel}";
    }
    
    /// <summary>
    /// Returns the saving format of the smartwatch.
    /// </summary>
    public override string SavingFormat()
    {
        return $"{Id},{Name},{IsDeviceTurnedOn},{_batteryLevel}%";
    }
}
