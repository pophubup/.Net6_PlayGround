namespace zNpgsqlClient.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public Category Category { get; set; }
    }
}