namespace APBD;

public class Smartwatch : Device,IPowerNotifier
{
    private int _battteryLevel;
    public int BatteryLevel
    {
        get
        {
            return _battteryLevel;
        }
        set
        {
            if (value < 0 | value > 100)
            {
                Console.WriteLine("Battery % ranges from 0 - 100");
            }
            
            _battteryLevel = value;
            if (_battteryLevel < 20)
            {
                Notify();
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
        throw new NotImplementedException();
    }
}
