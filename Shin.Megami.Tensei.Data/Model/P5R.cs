using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shin.Megami.Tensei.Data.Model
{
    /// <summary>
    /// This class is a representation of a Persona5Royal Persona.
    /// </summary>
    public class Persona5Royal : BaseEntity
    {
        public string Name { get; set; }

        public string Arcana { get; set;}

        public string Affinity { get; set; }

        public string StrongestSkill { get; set; }

        public string Weakness { get; set; }

        public int Level { get; set; }

        public string Origin { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static IEqualityComparer<Persona5Royal> Persona5RoyalComparer { get; } = new Persona5RoyalEqualityComparer();

        private sealed class Persona5RoyalEqualityComparer : IEqualityComparer<Persona5Royal>
        {
            public bool Equals(Persona5Royal x, Persona5Royal y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Name == y.Name
                    && x.Arcana == y.Arcana
                    && x.Affinity == y.Affinity
                    && x.StrongestSkill == y.StrongestSkill
                    && x.Weakness == y.Weakness
                    && x.Level == y.Level
                    && x.Origin == y.Origin;
            }

            public int GetHashCode(Persona5Royal obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.Name);
                hashCode.Add(obj.Affinity);
                hashCode.Add(obj.StrongestSkill);
                hashCode.Add(obj.Weakness);
                hashCode.Add(obj.Level);
                hashCode.Add(obj.Origin);

                return hashCode.ToHashCode();
            }
        }
    }

}
