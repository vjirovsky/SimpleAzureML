namespace SimpleAzureML.Exception
{
    /// <summary>
    /// This exception is throwned,
    /// </summary>
    class RRSRequestFailedException : System.Exception
    {
        public RRSRequestFailedException()
        {
        }

        public RRSRequestFailedException(string message)
            : base(message)
        {
        }

        public RRSRequestFailedException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
