using Microsoft.EntityFrameworkCore;

namespace Postmizan
{
    public class JsonContext : DbContext
    {
        public JsonContext(DbContextOptions<JsonContext> options) : base(options)
        {

        }
        public DbSet<JsonData> JsonDatas { get; set; }
    }
    public class JsonData
    {
        //Todo: Think about how you need to format your model
        public int Id { get; set; }
        public string PostJson { get; set; } = String.Empty;
        public string PutJson { get; set; } = String.Empty;

        public string GetJson { get; set; } = String.Empty;

        public string DeleteJson { get; set; } = String.Empty;

    }
}
