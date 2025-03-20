using System.IO;
using APBD;
using JetBrains.Annotations;
using Xunit;

namespace APBD.Tests;

[TestSubject(typeof(DeviceManager))] 
public class DeviceManagerTest 
{
    private string testFilePath = "test_devices.txt";
    private DeviceManager manager;

    
    public DeviceManagerTest()
    {
        File.WriteAllText(testFilePath, "");
        manager = new DeviceManager(testFilePath);
    }
    
    [Fact]
    public void AddDevice_ShouldAddDevice()
    {
        var watch = new Smartwatch (1, "Apple Watch", false ,67 );
        manager.AddDevice(watch);
        manager.SaveDataToFile();
        
        Assert.Contains("Apple Watch", File.ReadAllText(testFilePath));
        Assert.Single(manager.Devices);
    }

    [Fact]
    public void RemoveDevice_ShouldRemoveDevice()
    {
        var pc = new PersonalComputer(2, "ThinkPad", true ,"Windows 11") ;
        manager.AddDevice(pc);
        manager.RemoveDevice(pc);
        
        Assert.DoesNotContain("ThinkPad", File.ReadAllText(testFilePath));
        Assert.Empty(manager.Devices);
    }

    [Fact]
    public void EditDevice_ShouldUpdateDeviceProperty()
    {
        var watch = new Smartwatch(3, "Galaxy Watch", true,40);
        manager.AddDevice(watch);
        
        manager.EditDevice(watch, "BatteryLevel", 80);
        var updatedWatch = manager.GetDevice(watch) as Smartwatch;
        
        Assert.Equal(80, updatedWatch.BatteryLevel);
    }

    [Fact]
    public void TurnOnDevice_ShouldTurnDeviceOn()
    {
        var pc = new PersonalComputer(4, "Linux PC", false,"Ubuntu");
        manager.AddDevice(pc);
        
        manager.TurnOnDevice(pc);
        var updatedPc = manager.GetDevice(pc);
        
        Assert.True(updatedPc.IsDeviceTurnedOn);
    }

    [Fact]
    public void TurnOffDevice_ShouldTurnDeviceOff()
    {
        var pc = new PersonalComputer(5, "MacBook", true,"macOS");
        manager.AddDevice(pc);
        
        manager.TurnOffDevice(pc);
        var updatedPc = manager.GetDevice(pc);
        
        Assert.False(updatedPc.IsDeviceTurnedOn);
    }

    [Fact]
    public void SaveDataToFile_ShouldSaveAllDevices()
    {
        manager.AddDevice(new Smartwatch  (6,  "MIband",  false,78 ));
        manager.AddDevice(new EmbeddedDevice(7, "testED", "192.168.1.100", "MD Ltd.Wifi-1") );
        
        manager.SaveDataToFile();
        var lines = File.ReadAllLines(testFilePath);
        
        Assert.Equal(2, lines.Length);
        Assert.Contains("MIband", lines[0]);
        Assert.Contains("testED", lines[1]);
    }

    [Fact]
    public void AddDevice_ShouldNotExceedDeviceLimit()
    {
        for (int i = 0; i < 20; i++)
        {
            manager.AddDevice(new Smartwatch(i, $"Watch{i}", true,60) );
        }
        
        Assert.Equal(15, manager.Devices.Count);
    }
}