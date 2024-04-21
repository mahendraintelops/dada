namespace Application.Exceptions
{
    public class FsfssNotFoundException : ApplicationException
    {
        public FsfssNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
        {

        }
    }
}
