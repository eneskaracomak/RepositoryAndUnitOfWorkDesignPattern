using System.Collections.Generic;

namespace RepveUOW.Data.Model
{
    public class Category : ModelBase
    {
        public Category()
        {
            this.Articles = new List<Article>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        // Relations
        public virtual ICollection<Article> Articles { get; set; }
    }
}