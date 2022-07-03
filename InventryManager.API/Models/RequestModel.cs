namespace InventryManager.API.Models
{
    public class RequestModel
    {
        public Guid RequestId { get; } = Guid.NewGuid();
    }
}
