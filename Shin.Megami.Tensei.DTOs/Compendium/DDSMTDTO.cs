using System;
using System.ComponentModel.DataAnnotations;

namespace Shin.Megami.Tensei.DTOs.DDStoryMegaTens
{
    /// <summary>
    /// Describes a data transfer object for a MegaTen Demon.
    /// </summary>
    public class DDStoryMegaTenDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Race { get; set; }

        public string Affinity { get; set; }

        public string StrongestSkill { get; set; }

        public int Level { get; set; }

        public string Origin { get; set; }


    }
}
