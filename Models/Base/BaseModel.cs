using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utils.Interfaces;

namespace Models.Base
{
    public class BaseModel : IBaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; }

        public DateTimeOffset UpdatedAt { get; protected set; }

        public void OnCreate(DateTimeOffset now)
        {
            CreatedAt = UpdatedAt = now;
        }

        public void OnUpdate(DateTimeOffset now)
        {
            UpdatedAt = now;
        }

        public bool New()
        {
            return Id == default;
        }
    }
}
