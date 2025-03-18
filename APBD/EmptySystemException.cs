namespace APBD;

public class EmptySystemException : Exception
{
    public EmptySystemException() : base("No operating system installed") { }
}