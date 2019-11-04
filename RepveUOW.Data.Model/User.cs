using System;
using System.Collections.Generic;

namespace RepveUOW.Data.Model
{
    public class User : ModelBase
    {
        public User()
        {
            this.Articles = new List<Article>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Fluently bir şekilde ilişkileri kullanabilmemiz için tanımlıyoruz.
        public virtual ICollection<Article> Articles { get; set; }
    }
}