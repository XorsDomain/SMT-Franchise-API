using System;
using System.ComponentModel.DataAnnotations;

namespace Shin.Megami.Tensei.DTOs.Persona5Royals
{
    /// <summary>
    /// Describes a data transfer object for a P5R Persona.
    /// </summary>
    public class Persona5RoyalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Arcana { get; set; }

        public string Affinity { get; set; }

        public string StrongestSkill { get; set; }

        public string Weakness { get; set; }

        public int Level { get; set; }

        public string Origin { get; set; }


    }
}
