using System;
using System.Runtime.Serialization;

namespace DogNet.Immo.Core.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException(string type, int id) : base ($"L'entité {{{type} : {id}}} n'a pas été trouvée"){ }
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
