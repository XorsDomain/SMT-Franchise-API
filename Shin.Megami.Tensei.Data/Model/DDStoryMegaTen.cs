using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shin.Megami.Tensei.Data.Model
{
    /// <summary>
    /// This class is a representation of a DDStoryMegaTen Demon.
    /// </summary>
    public class DDStoryMegaTen : BaseEntity
    {
        public string Name { get; set; }

        public string Race { get; set; }

        public string Affinity { get; set; }

        public string StrongestSkill { get; set; }

        public int Level { get; set; }

        public string Origin { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static IEqualityComparer<DDStoryMegaTen> DDStoryMegaTenComparer { get; } = new DDStoryMegaTenEqualityComparer();

        private sealed class DDStoryMegaTenEqualityComparer : IEqualityComparer<DDStoryMegaTen>
        {
            public bool Equals(DDStoryMegaTen x, DDStoryMegaTen y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Name == y.Name
                    && x.Race == y.Race
                    && x.Affinity == y.Affinity
                    && x.StrongestSkill == y.StrongestSkill
                    && x.Level == y.Level
                    && x.Origin == y.Origin;
            }

            public int GetHashCode(DDStoryMegaTen obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.Name);
                hashCode.Add(obj.Race);
                hashCode.Add(obj.Affinity);
                hashCode.Add(obj.StrongestSkill);
                hashCode.Add(obj.Level);
                hashCode.Add(obj.Origin);

                return hashCode.ToHashCode();
            }
        }
    }

}
