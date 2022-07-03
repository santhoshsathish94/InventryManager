namespace InventryManager.API.Models
{
    public class UserModel : RequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
