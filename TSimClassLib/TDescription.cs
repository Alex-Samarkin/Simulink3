// Simulink3
// TSimClassLib
// TDescription.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 2:00 09 04 2022

using System;
using System.ComponentModel;

namespace TSimClassLib
{
    public class TDescription : TId, IEquatable<TDescription>
    {
        [Category("Description"), Description("Short Description"), DefaultValue("")]
        [DisplayName("Краткое описание")]
        [NotifyParentProperty(true)]
        public string ShortDescr { get; set; } = "";
        [Category("Description"), Description("Long Description"), DefaultValue("")]
        [DisplayName("Полное описание")]
        [NotifyParentProperty(true)]
        public string LongDescr { get; set; } = "";

        public TDescription(int value = 0, string shortDescr = null, string longDescr = null) : base(value)
        {
            ShortDescr = shortDescr ?? "Short description";
            LongDescr = longDescr ?? "Long description";
        }

        #region Equality members

        public bool Equals(TDescription other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && ShortDescr == other.ShortDescr;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TDescription)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (ShortDescr != null ? ShortDescr.GetHashCode() : 0);
            }
        }

        public static bool operator ==(TDescription left, TDescription right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TDescription left, TDescription right)
        {
            return !Equals(left, right);
        }

        #endregion

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(ShortDescr)}: {ShortDescr}, {nameof(LongDescr)}: {LongDescr}";
        }
    }
}