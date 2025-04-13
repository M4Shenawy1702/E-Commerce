namespace Domain.Models
{
    public class ProductType : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}
