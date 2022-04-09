// Simulink3
// TSimClassLib
// TTitle.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 1:45 09 04 2022

using System;
using System.ComponentModel;

namespace TSimClassLib
{
    public class TTitle : TId,IEquatable<TTitle>
    {
        //private readonly TId _id;

        [Category("Title"), Description("Title"), DefaultValue("")]
        [DisplayName("Заголовок")]
        [NotifyParentProperty(true)]
        public string Title { get; set; } = "";

        [Category("Title"), Description("SubTitle"), DefaultValue("")]
        [DisplayName("Подзаголовок")]
        [NotifyParentProperty(true)]
        public string SubTitle { get; set; } = "";

        [Category("Title"), Description("Description"), DefaultValue("")]
        [DisplayName("Описание")]
        [NotifyParentProperty(true)]
        public string Description { get; set; } = "";

        [Category("Title"), Description("Author"), DefaultValue("")]
        [DisplayName("Автор")]
        [NotifyParentProperty(true)]
        public string Author { get; set; } = "";

        [Category("Title"), Description("DateTime"), DefaultValue("")]
        [DisplayName("Дата и время")]
        [NotifyParentProperty(true)]
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public TTitle(int id = 0,string title = null, string subTitle = null, string description = null, string author = null)
        {
            Id = id;
            Title = title ?? "Заголовок";
            SubTitle = subTitle ?? "_";
            Description = description ?? "_";
            Author = author ?? "";
            //_id = new TId();
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(SubTitle)}: {SubTitle}, {nameof(Description)}: {Description}, {nameof(Author)}: {Author}, {nameof(TimeStamp)}: {TimeStamp}";
        }

        #region Equality members

        public bool Equals(TTitle other)
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
            return Equals((TTitle)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(TTitle left, TTitle right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TTitle left, TTitle right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}