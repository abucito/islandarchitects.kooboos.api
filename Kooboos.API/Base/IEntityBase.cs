using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kooboos.API.Base
{
    public interface IEntityBase
    {
        int Id { get; set; }
    }
}