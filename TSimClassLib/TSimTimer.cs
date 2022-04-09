// Simulink3
// TSimClassLib
// Class2.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 1:59 09 04 2022

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;

namespace TSimClassLib
{
    public class TSimTimer : TDescription, IEquatable<TSimTimer>, IComparable<TSimTimer>, IComparable
    {
        [Category("SimTime"), Description("Start"), DefaultValue("0")]
        [DisplayName("Старт")]
        [NotifyParentProperty(true)]
        public double Start { get; set; } = 0.0;

        [Category("SimTime"), Description("End"), DefaultValue("100")]
        [DisplayName("Финал")]
        [NotifyParentProperty(true)]
        public double End { get; set; } = 100.0;

        [Category("SimTime"), Description("Step"), DefaultValue("0.01")]
        [DisplayName("Шаг")]
        [NotifyParentProperty(true)]
        public double Step { get; set;} = 0.01;

        [Category("SimTime"), Description("Num"), DefaultValue("0")]
        [DisplayName("Номер шага")]
        [NotifyParentProperty(true)]
        public int Num { get; set; } = 0;

        [Category("SimTime"), Description("Current time"), DefaultValue("0")]
        [DisplayName("Текущее время")]
        [NotifyParentProperty(true)]
        public double CurrentTime { get=> Start+(double)Num*Step;
            set
            {
                if (value < Start ) value = Start;
                if (value > End) value = End;
                double h = value - Start;
                Num = (int)(h / Step);
                if (Num<0) Num = 0;
            }
        }

        public TSimTimer(int value = 0, string shortDescr = null, string longDescr = null, 
            double start = default, 
            double end = 100, 
            double step = 0.01, 
            int num = default) : 
            base(value, shortDescr, longDescr)
        {
            Start = start;
            End = end;
            Step = step;
            Num = num;

            ShortDescr = $"Timer Id={Id}";
            LongDescr = $"From/To/Step: {Start}/{End}/{Step}";
        }

        public double Inc(int step = 1)
        {
            Num += step;
            if (Num < 0) Num = 0;
            if (CurrentTime > End) Num = (int)((End-Start) / Step);
            return CurrentTime;
        }

        public void Reset()
        {
            Num = 0;
        }


        public bool ItsEndTime => CurrentTime > End-Step;

        #region Equality members

        public bool Equals(TSimTimer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CurrentTime.Equals(other.CurrentTime) && Start.Equals(other.Start);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TSimTimer)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Start.GetHashCode();
            }
        }

        public static bool operator ==(TSimTimer left, TSimTimer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TSimTimer left, TSimTimer right)
        {
            return !Equals(left, right);
        }

        #region Relational members

        public int CompareTo(TSimTimer other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return CurrentTime.CompareTo(other.CurrentTime);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is TSimTimer other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(TSimTimer)}");
        }

        public static bool operator <(TSimTimer left, TSimTimer right)
        {
            return Comparer<TSimTimer>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(TSimTimer left, TSimTimer right)
        {
            return Comparer<TSimTimer>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(TSimTimer left, TSimTimer right)
        {
            return Comparer<TSimTimer>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(TSimTimer left, TSimTimer right)
        {
            return Comparer<TSimTimer>.Default.Compare(left, right) >= 0;
        }

        #endregion

        #endregion

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Start)}: {Start}, {nameof(End)}: {End}, {nameof(CurrentTime)}: {CurrentTime}, {nameof(Step)}: {Step}, {nameof(Num)}: {Num}";
        }
    }
}