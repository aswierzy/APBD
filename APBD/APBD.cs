namespace APBD;

public class APBD
{
    public static void Main()
    {
        var manager = new DeviceManager("devices.txt"); 
        manager.ShowAllDevices();
        Smartwatch sw2 = new Smartwatch(2,"Apple Watch SE3",true,50);
        manager.AddDevice(sw2);
        manager.ShowAllDevices();
        
        var pc5 = new PersonalComputer(5, "Gaming PC", false,"Windows 11") ;
        manager.AddDevice(pc5);
        
        var ed7 = new EmbeddedDevice(7, "Raspberry Pi", "Invalid IP", "MD Ltd. WiFi") ;
        manager.AddDevice(ed7);  

        manager.ShowAllDevices();

        manager.EditDevice(sw2, "BatteryPercentage", 75);

        manager.TurnOnDevice(pc5); 

        manager.TurnOffDevice(sw2); 

        manager.RemoveDevice(ed7); 

        manager.ShowAllDevices();
        
        
        // In the tests SaveDataToFile passes so I guess it's working but here I don't know why it won't save devices to the file
        manager.SaveDataToFile();

    }
}