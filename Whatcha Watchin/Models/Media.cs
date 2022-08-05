using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Whatcha_Watchin.Models
{
    // All public properties of Movie are converted into table columns
    public class API_Results
    {
        public Media[] results { get; set; }
        public int total_pages { get; set; }
    }

    public class Media : IEntityTypeConfiguration<Media>
    {
        // Public property that uses "Id" is the primary key
        [Key]
        public string imdbID { get; set; }
        public string title { get; set; }
        public int imdbRating { get; set; }
        public string overview { get; set; }
        public int year { get; set; }
        public int runtime { get; set; }
        public Poster posterURLs {get; set;}

        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(x => x.imdbID);
            builder.OwnsOne(x => x.posterURLs);
        }
    }

    [Owned]
    public class Poster : ValueObject
    {
        [JsonProperty(PropertyName = "92")]
        public string Size92 { get; set; }

        [JsonProperty(PropertyName = "154")]
        public string Size154 { get; set; }

        [JsonProperty(PropertyName = "185")]
        public string Size185 { get; set; }

        [JsonProperty(PropertyName = "342")]
        public string Size342 { get; set; }

        [JsonProperty(PropertyName = "500")]
        public string Size500 { get; set; }

        [JsonProperty(PropertyName = "780")]
        public string Size780 { get; set; }

        [Key]
        public string original { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Size92;
            yield return Size154;
            yield return Size185;
            yield return Size342;
            yield return Size500;
            yield return Size780;
            yield return original;

        }
    }

    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            ValueObject other = (ValueObject)obj;
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
             .Select(x => x != null ? x.GetHashCode() : 0)
             .Aggregate((x, y) => x ^ y);
        }
        // Other utility methods
    }
}
