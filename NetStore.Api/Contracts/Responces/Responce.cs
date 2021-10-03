namespace NetStore.Api.Contracts.Responces
{
    public class Responce<T>
    {
        public Responce() { }

        public Responce(T responce)
        {
            Data = responce;
        }

        public T Data { get; set; }

    }
}
