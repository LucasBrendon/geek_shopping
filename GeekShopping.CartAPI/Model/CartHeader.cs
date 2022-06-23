using GeekShopping.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model
{
    [Table("cart_header")]
    public class CartHeader : EntityBase
    {
        [Column("user_id")]
        public string UserId { get; set; }

        [Column("coupun_code")]
        public string CoupunCode { get; set; }
    }
}
