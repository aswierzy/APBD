namespace APBD;

public class ConnectionException : Exception
{
    public ConnectionException() : base("Unable to connect ") { }
}