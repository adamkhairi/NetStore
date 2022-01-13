using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetStore.Shared.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string CommentBody { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Product Project { get; set; }
        public string ProjectId { get; set; }
        public DateTime Created { get; set; }
    }
}
