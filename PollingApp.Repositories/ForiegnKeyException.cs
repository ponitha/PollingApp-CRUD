using System;

namespace PollingApp.Repositories
{
  [Serializable]
  public class ForiegnKeyException : Exception
  {
    public ForiegnKeyException()
      : base() { }

    public ForiegnKeyException(string message)
      : base(message) { }

    public ForiegnKeyException(string format, params object[] args)
      : base(string.Format(format, args)) { }

    public ForiegnKeyException(string message, Exception innerException)
      : base(message, innerException) { }

    public ForiegnKeyException(string format, Exception innerException, params object[] args)
      : base(string.Format(format, args), innerException) { }
  }
}
