﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication1.Models;

namespace DeadLiner.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserStatus { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<TaskToUser> TaskToUsers { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public virtual DbSet<TasksModel> TasksModels { get; set; }
        public virtual DbSet<TaskToUser> TaskToUsers { get; set; }
        public virtual DbSet<ReplyToTask> ReplyToTasks { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }        
    }
}