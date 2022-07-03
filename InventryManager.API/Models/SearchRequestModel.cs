namespace InventryManager.API.Models
{
    public class SearchRequestModel : RequestModel
    {
        public string SearchText { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderBy { get; set; }
    }
}
