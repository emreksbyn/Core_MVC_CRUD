using Core_MVC_CRUD.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core_MVC_CRUD.Infrastructure.EntityTypeConfiguration.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        // Asp.Net projelerinde bu Configuration işlemlerini Constructor method içerisinde yapıyorduk. 
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreateDate)
                .HasColumnName("CreateDate")
                .HasColumnType("datetime2")
                .IsRequired(true);

            builder.Property(x => x.UpdateDate)
                .HasColumnName("UpdateDate")
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder.Property(x => x.DeleteDate)
                .HasColumnName("DeleteDate")
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .IsRequired(true);
        }
    }
}
