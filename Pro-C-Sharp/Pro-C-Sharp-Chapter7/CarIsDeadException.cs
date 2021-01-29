using System;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter7
{
    [Serializable]
    public class CarIsDeadException : ApplicationException
    {
        // Custom members for our exception.
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }
        public CarIsDeadException(string message) : base(message) { }
        public CarIsDeadException(string message,
        System.Exception inner)
        : base(message, inner) { }

        public CarIsDeadException(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        protected CarIsDeadException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
        // Any additional custom properties, constructors and data members...
    }
}
