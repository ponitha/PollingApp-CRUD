using System;

namespace PollingApp.Repositories
{
  [Serializable]
  class UniqueKeyException : Exception
  {
    public UniqueKeyException()
      : base() { }

    public UniqueKeyException(string message)
      : base(message) { }

    public UniqueKeyException(string format, params object[] args)
      : base(string.Format(format, args)) { }

    public UniqueKeyException(string message, Exception innerException)
      : base(message, innerException) { }

    public UniqueKeyException(string format, Exception innerException, params object[] args)
      : base(string.Format(format, args), innerException) { }
  }
}

