namespace APBD;

public class EmptyBatteryException : Exception
{
    /// <summary>
    /// Exception thrown when battery is too low.
    /// </summary>
    public EmptyBatteryException() : base("Battery is too low.") { }
    
}