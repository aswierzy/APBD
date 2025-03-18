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
        throw new NotImplementedException();
    }
}