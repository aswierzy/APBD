public abstract class Device
{
   public string Id { get; set; }
   public string Name { get; set; }
   public bool IsDeviceTurnedOn { get; set; }

   /// <summary>
   /// Turns the device on.
   /// </summary>
   public virtual void TurnOn()
   {
      IsDeviceTurnedOn = true;
      Console.WriteLine($"{Name} is on");
   }
   
   
   /// <summary>
   /// Turns the device off.
   /// </summary>
   public virtual void TurnOff()
   {
      IsDeviceTurnedOn = false;
      Console.WriteLine($"{Name} is off");
   }

   
   /// <summary>
   /// Returns a string representation of the device.
   /// </summary>
   public abstract string ToString();
   
   /// <summary>
   /// Returns the string format used for saving the device.
   /// </summary>
   public abstract string SavingFormat();

}