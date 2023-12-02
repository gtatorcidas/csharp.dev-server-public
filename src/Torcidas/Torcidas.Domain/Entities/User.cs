using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torcidas.Domain.Entities
{

    [Table("users")]
    public class User : BaseEntity
    {
        #region Properties

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("username")]
        [Required]
        public string UserName { get; set; }

        #endregion

    }
}
