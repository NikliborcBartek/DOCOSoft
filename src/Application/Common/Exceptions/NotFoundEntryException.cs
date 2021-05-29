using System;


namespace Application.Common.Exceptions
{
    public class NotFoundEntryException : Exception
    {
        public NotFoundEntryException(string name, object key, string keyName = "Id")
            : base($"Not found {name} by {keyName} = {key}.")
        {
        }
    }
}
