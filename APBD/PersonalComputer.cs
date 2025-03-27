namespace APBD;

public class PersonalComputer : Device
{
    public string? OperatingSystem { get; set; }

    
    public PersonalComputer(string id, string name, bool isTurnedOn, string operatingSystem)
    {
        Id = id;
        Name = name;
        IsDeviceTurnedOn = isTurnedOn;
        OperatingSystem = operatingSystem;
    }
    
    /// <summary>
    /// Installs an operating system.
    /// </summary>
    public void InstallOs(string operatingSystemName)
    {   
        OperatingSystem = operatingSystemName;
    }

    /// <summary>
    /// Turns the device on. Throws an exception if no OS is installed.
    /// </summary>
    public override void TurnOn()
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
    
    /// <summary>
    /// Returns a string representation of the personal computer.
    /// </summary>
    public override string ToString()
    {
        return $"ID: {Id} | Name: {Name} | Running: {IsDeviceTurnedOn} | OS: {OperatingSystem}";
    }
    
    /// <summary>
    /// Returns the saving format of the personal computer.
    /// </summary>
    public override string SavingFormat()
    {
        return $"{Id},{Name},{IsDeviceTurnedOn},{OperatingSystem}";
    }
}