[System.Serializable]
public class IllegalPageStateException : System.Exception
{
    public IllegalPageStateException() { }
    public IllegalPageStateException(string message) : base(message) { }
    public IllegalPageStateException(string message, System.Exception inner) : base(message, inner) { }
    protected IllegalPageStateException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}