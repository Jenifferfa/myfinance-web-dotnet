using System.ComponentModel.DataAnnotations;

namespace myfinance_web_netcore.Domain
{
    public class EntityBase
    {
        [Key]
        public int? Id {get; set; }
    }
}