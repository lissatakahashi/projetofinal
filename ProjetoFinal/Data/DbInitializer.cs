namespace ProjetoFinal.Data {
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context) 
        {
            context.SaveChanges();
        }
    }
}