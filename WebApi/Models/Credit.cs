using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApi.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public string Description { get; set; }

        #region Constructs
        public Credit()
        {
        }

        public Credit(string description)
        {
            Description = description;
        }
        #endregion Constructs

        #region Fabric
        public static Credit Create()
        {
            return new Credit();
        }

        public static Credit Create(string description)
        {
            return new Credit(description);
        }
        #endregion Fabric
    }

    public class CreditConfiguration : EntityTypeConfiguration<Credit>
    {
        public CreditConfiguration()
        {
            ToTable("Credits");

            HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Description)
                .HasMaxLength(50)
                .IsRequired();
        }

        public static CreditConfiguration Create()
        {
            return new CreditConfiguration();
        }
    }
}