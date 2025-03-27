namespace APBD;

public class ConnectionException : Exception
{
    /// <summary>
    /// Exception thrown when a connection fails.
    /// </summary>
    public ConnectionException() : base("Unable to connect ") { }
}