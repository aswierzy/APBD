namespace APBD;

public class Smartwatch : Device,IPowerNotifier
{
    private int _batteryLevel;
    public int BatteryLevel
    {
        get => _batteryLevel;
        
        set
        {
            if (value < 0 | value > 100)
            {
                Console.WriteLine("Battery % ranges from 0 - 100");
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
    
    public  void Notify()
    {
        Console.WriteLine("Battery is less than 20%");
    }

    public void TurnOn()
    {
        if (BatteryLevel < 11)
        {
            throw new EmptyBatteryException();
        }

        base.TurnOn();
        BatteryLevel -= 10;
        Console.WriteLine("Current battery level: " + BatteryLevel + "%");
    }

    public override string ToString()
    {
        return $"ID: {Id} /n Name: {Name} /n Running: {IsDeviceTurnedOn} /n Battery Level: {_batteryLevel}";
    }
    public override string SavingFormat()
    {
        return $"SW-{Id},{Name},{IsDeviceTurnedOn},{_batteryLevel}%";
    }
}
