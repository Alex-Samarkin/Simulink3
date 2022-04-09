// Simulink3
// TSimClassLib
// TId.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 2:03 09 04 2022

using System;
using System.ComponentModel;

namespace TSimClassLib
{
    public class TId : IEquatable<TId>
    {
        public TId(int value=0)
        {
            Id = value;
        }

        [Category("Id"), Description("Id"), DefaultValue(0)]
        [DisplayName("Id")]
        [NotifyParentProperty(true)]
        public int Id { get; set; } = 0;

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}";
        }

        #region Equality members

        public bool Equals(TId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TId)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(TId left, TId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TId left, TId right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}