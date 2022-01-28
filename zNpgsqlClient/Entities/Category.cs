
namespace zNpgsqlClient.Entities
{
    public  class Category
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
