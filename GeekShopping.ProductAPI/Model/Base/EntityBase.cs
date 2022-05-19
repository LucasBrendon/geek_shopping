using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Model.Base
{
    public class EntityBase
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
    }
}
