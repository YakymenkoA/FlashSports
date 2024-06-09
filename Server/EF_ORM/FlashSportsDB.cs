using FlashSportsLib.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Server.EF_ORM
{
    public class FlashSportsDB : DbContext
    {
        public FlashSportsDB()
            : base("name=FlashSportsDB")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Support> Supports { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Candy> Candies { get; set; }
        public virtual DbSet<Favourite> Favourites { get; set; }
        public virtual DbSet<SportEvent> SportEvents { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}