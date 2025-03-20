namespace APBD;

public class PersonalComputer : Device
{
    public string? OperatingSystem { get; set; }

    public void InstallOs(string operatingSystemName)
    {   
        OperatingSystem = operatingSystemName;
    }

    public void TurnOn()
    {
        if (OperatingSystem == null)
        {
            throw new EmptySystemException();
        }
        else
        {
            base.TurnOn();
        }
    }
    
    
    
    
    public override string ToString()
    {
        return $"ID: {Id} /n Name: {Name} /n Running: {IsDeviceTurnedOn} /n OS: {OperatingSystem}";
    }
    public override string SavingFormat()
    {
        return $"P-{Id},{Name},{IsDeviceTurnedOn},{OperatingSystem}";
    }
}