using System;
using System.ComponentModel.DataAnnotations;

namespace Shin.Megami.Tensei.Data.Model
{
    /// <summary>
    /// This class represents a base for all other entities.
    /// </summary>
    public class BaseEntity
    {

        [Key]
        public int Id { get; set; }

    }

}
