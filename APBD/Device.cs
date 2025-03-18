public abstract class Device
{
   public int Id { get; set; }
   public string Name { get; set; }
   public bool IsDeviceTurnedOn { get; set; }

   public void TurnOn()
   {
      IsDeviceTurnedOn = true;
      Console.WriteLine("Device is on");
   }
   public void TurnOff()
   {
      IsDeviceTurnedOn = false;
      Console.WriteLine("Device is off");
   }
}