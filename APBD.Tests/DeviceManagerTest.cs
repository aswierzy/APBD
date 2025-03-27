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
        manager = DeviceManagerFactory.CreateDeviceManager(testFilePath);
    }
    
    [Fact]
    public void AddDevice_ShouldAddDevice()
    {
        var watch = new Smartwatch ("SW-1", "Apple Watch", false ,67 );
        manager.AddDevice(watch);
        manager.SaveDataToFile();
        
        Assert.Contains("Apple Watch", File.ReadAllText(testFilePath));
        Assert.Single(manager.Devices);
    }

    [Fact]
    public void RemoveDevice_ShouldRemoveDevice()
    {
        var pc = new PersonalComputer("P-2", "ThinkPad", true ,"Windows 11") ;
        manager.AddDevice(pc);
        manager.RemoveDevice("P-2");
        
        Assert.DoesNotContain("ThinkPad", File.ReadAllText(testFilePath));
        Assert.Empty(manager.Devices);
    }

    [Fact]
    public void EditDevice_ShouldUpdateDeviceProperty()
    {
        var watch = new Smartwatch("SW-3", "Galaxy Watch", true,40);
        manager.AddDevice(watch);
        
        manager.EditDevice("SW-3", "BatteryLevel", 80);
        var updatedWatch = manager.GetDevice("SW-3") as Smartwatch;
        
        Assert.Equal(80, updatedWatch.BatteryLevel);
    }

    [Fact]
    public void TurnOnDevice_ShouldTurnDeviceOn()
    {
        var pc = new PersonalComputer("P-4", "Linux PC", false,"Ubuntu");
        manager.AddDevice(pc);
        
        manager.TurnOnDevice("P-4");
        var updatedPc = manager.GetDevice("P-4");
        
        Assert.True(updatedPc.IsDeviceTurnedOn);
    }

    [Fact]
    public void TurnOffDevice_ShouldTurnDeviceOff()
    {
        var pc = new PersonalComputer("P-5", "MacBook", true,"macOS");
        manager.AddDevice(pc);
        
        manager.TurnOffDevice("P-5");
        var updatedPc = manager.GetDevice("P-5");
        
        Assert.False(updatedPc.IsDeviceTurnedOn);
    }

    [Fact]
    public void SaveDataToFile_ShouldSaveAllDevices()
    {
        manager.AddDevice(new Smartwatch  ("SW-6",  "MIband",  false,78 ));
        manager.AddDevice(new EmbeddedDevice("ED-7", "testED", "192.168.1.100", "MD Ltd.Wifi-1") );
        
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
            manager.AddDevice(new Smartwatch($"SW-{i}", $"Watch{i}", true,60) );
        }
        
        Assert.Equal(15, manager.Devices.Count);
    }
}