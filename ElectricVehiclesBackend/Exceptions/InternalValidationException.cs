namespace Exceptions
{
    public class InternalValidationException : Exception
    {
        public List<string> Errors { get; }

        public InternalValidationException(List<string> errors)
        {
            Errors = errors;
        }

        public InternalValidationException(string error)
        {
            Errors = new List<string> { error };
        }  
    }
}
