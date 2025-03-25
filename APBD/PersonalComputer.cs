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
    
    public void InstallOs(string operatingSystemName)
    {   
        OperatingSystem = operatingSystemName;
    }

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
    
    public override string ToString()
    {
        return $"ID: {Id} | Name: {Name} | Running: {IsDeviceTurnedOn} | OS: {OperatingSystem}";
    }
    public override string SavingFormat()
    {
        return $"{Id},{Name},{IsDeviceTurnedOn},{OperatingSystem}";
    }
}