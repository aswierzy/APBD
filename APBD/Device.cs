public abstract class Device
{
   public int Id { get; set; }
   public string Name { get; set; }
   public bool IsDeviceTurnedOn { get; set; }

   public void TurnOn()
   {
      IsDeviceTurnedOn = true;
      Console.WriteLine($"{Name} is on");
   }
   public void TurnOff()
   {
      IsDeviceTurnedOn = false;
      Console.WriteLine($"{Name} is off");
   }

   
   public override bool Equals(object? obj)
   {
      if (obj is Device other)
      {
         return this.Id == other.Id && this.GetType() == other.GetType();
      }
      return false;
   }

   public override int GetHashCode()
   {
      return HashCode.Combine(Id, GetType());
   }
   
   
   public abstract string ToString();
   public abstract string SavingFormat();

}