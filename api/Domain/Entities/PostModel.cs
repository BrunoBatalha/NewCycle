using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Entities
{
    public class PostModel
    {
        [Column(TypeName = "varchar(50)")]
        public Guid Id { get; set; }
        [Column(TypeName = "text")]
        public string Content { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
        public int ReactionsQuantity { get; set; }
        public int CommentsQuantity { get; set; }
    }
}