namespace Example.Application.Dtos
{
    public class CreateResult<T> : OutputBase
    {
        public T Id { get; set; }
        public bool IsCreated { get; set; }
    }
}
