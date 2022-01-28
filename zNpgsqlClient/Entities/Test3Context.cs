namespace zNpgsqlClient.Entities
{
    public class Test3Context: DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public Test3Context(DbContextOptions<Test3Context> options)
           : base(options)
        {
        }

    }
}
