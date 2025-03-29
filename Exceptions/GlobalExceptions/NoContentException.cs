using System.Globalization;

namespace Library.Exceptions.CustomExceptions
{
    public class NoContentException : Exception
    {
        public NoContentException(string message) : base(message) { }
    }
}