namespace DesafioAutomacaoWeb.Utils.Database.Entities
{
    public class CategoriesEntities
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
    }
}