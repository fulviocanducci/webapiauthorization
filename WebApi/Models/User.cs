using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApi.Models
{
    public class User
    {
        
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        #region Constructors
        public User()
        {
                
        }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public User(Guid id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }
        #endregion Constructors

        #region Fabric
        public static User Create()
        {
            return new User();
        }

        public static User Create(Guid id, string userName, string password)
        {
            return new User(id, userName, password);
        }

        public static User Create(string userName, string password)
        {
            return new User(userName, password);
        }
        #endregion Fabric
    }

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");

            HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.UserName)
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.Password)
                .HasMaxLength(50)
                .IsRequired();
        }

        public static UserConfiguration Create()
        {
            return new UserConfiguration();
        }
    }
}