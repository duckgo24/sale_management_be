

namespace Application.Dtos
{
    public class CategoryDto
    {
        public string category_id { get; set; }
        public string category_name { get; set; }
        public string category_desc { get; set; }
        public string category_image { get; set; }

        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime last_updated { get; set; } = DateTime.Now;
        public string created_by { get; set; }
    }
}