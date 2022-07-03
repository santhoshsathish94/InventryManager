namespace InventryManager.API.Models
{
    public class ResponseModel
    {
        public int StatusCode { get; }
        public string Message { get; }
    }

    public class ResponseModel<T> : ResponseModel
    {
        public IEnumerable<T> Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
