using System.Globalization;

namespace Library.Exceptions.CustomExceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base() { }
        public UnauthorizedException(String message) : base(message) { }
    }
}