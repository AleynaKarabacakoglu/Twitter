using Domain.Entities;
using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context
{
    public class TwitterContext:DbContext
    {
        public TwitterContext(DbContextOptions<TwitterContext> options):base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<Contact>();

            modelBuilder.Entity<Contact>().HasKey(c => new { c.FollowingId, c.FollowerId });
            modelBuilder.Entity<Like>().HasKey(c => new { c.PostId, c.UserId });
            modelBuilder.Entity<Retweet>().HasKey(c => new { c.PostId, c.UserId });
           
        }
        public DbSet<User> Users{ get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Retweet> Retweets { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Image> Images { get; set; }
       


    }
}
