using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.API.Entities
{
    public interface IEntityBase
    {
        int Id { get; set; }
    }
}