using System.Globalization;

namespace Library.Exceptions.CustomExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(String message) : base(message) { }
    }
}