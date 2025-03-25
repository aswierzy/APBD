namespace APBD;

public class APBD
{
    public static void Main()
    {
        var manager = new DeviceManager("devices.txt"); 
        manager.ShowAllDevices();
        Smartwatch sw2 = new Smartwatch("SW-2","Apple Watch SE3",true,50);
        manager.AddDevice(sw2);
        manager.ShowAllDevices();
        
        var pc5 = new PersonalComputer("P-5", "Gaming PC", false,"Windows 11") ;
        manager.AddDevice(pc5);
        
        try
        {
            var ed7 = new EmbeddedDevice("ED-7", "Raspberry Pi", "Invalid IP", "MD Ltd. WiFi");
            manager.AddDevice(ed7);  
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Skipping device due to invalid IP: {ex.Message}");
        }
        
        
        manager.ShowAllDevices();

        manager.EditDevice("SW-2", "BatteryPercentage", 75);

        manager.TurnOnDevice("P-5"); 

        manager.TurnOffDevice("SW-2"); 

        manager.RemoveDevice("ED-7"); 

        manager.ShowAllDevices();

        manager.SaveDataToFile();

    }
}