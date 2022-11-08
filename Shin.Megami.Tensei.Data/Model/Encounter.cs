using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shin.Megami.Tensei.Data.Model
{
    public class Encounter : BaseEntity
    {
        public new int Id { get; set; }

        public int ProductId { get; set; }

        public string Notes { get; set; }

        public string VisitCode { get; set; }

        public string Provider { get; set; }

        public string BillingCode { get; set; }

        public string ICD10 { get; set; }

        public decimal TotalCost { get; set; }

        public decimal Copay { get; set; }

        public string ChiefComplaint { get; set; }

        public decimal Pulse { get; set; }

        public decimal Systolic { get; set; }

        public decimal Diastolic { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static IEqualityComparer<Encounter> ProductComparer { get; } = new ProductEqualityComparer();

        private sealed class ProductEqualityComparer : IEqualityComparer<Encounter>
        {
            public bool Equals(Encounter x, Encounter y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id
                    && x.ProductId == y.ProductId
                    && x.Notes == y.Notes
                    && x.VisitCode == y.VisitCode
                    && x.Provider == y.Provider
                    && x.BillingCode == y.BillingCode
                    && x.ICD10 == y.ICD10
                    && x.TotalCost == y.TotalCost
                    && x.Copay == y.Copay
                    && x.ChiefComplaint == y.ChiefComplaint
                    && x.Pulse == y.Pulse
                    && x.Systolic == y.Systolic
                    && x.Diastolic == y.Diastolic
                    && x.Date == y.Date;
            }

            public int GetHashCode(Encounter obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.Id);
                hashCode.Add(obj.ProductId);
                hashCode.Add(obj.Notes);
                hashCode.Add(obj.VisitCode);
                hashCode.Add(obj.Provider);
                hashCode.Add(obj.BillingCode);
                hashCode.Add(obj.ICD10);
                hashCode.Add(obj.TotalCost);
                hashCode.Add(obj.Copay);
                hashCode.Add(obj.ChiefComplaint);
                hashCode.Add(obj.Pulse);
                hashCode.Add(obj.Systolic);
                hashCode.Add(obj.Diastolic);
                hashCode.Add(obj.Date);

                return hashCode.ToHashCode();
            }
        }

    }
}
