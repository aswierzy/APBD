namespace APBD;

public class EmptySystemException : Exception
{
    /// <summary>
    /// Exception thrown when no operating system is installed.
    /// </summary>
    public EmptySystemException() : base("No operating system installed") { }
}