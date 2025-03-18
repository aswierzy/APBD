namespace APBD;

public class EmptyBatteryException : Exception
{
    public EmptyBatteryException() : base("Battery is too low.") { }
    
}