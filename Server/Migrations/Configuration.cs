namespace Server.Migrations
{
    using FlashSportsLib.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FlashSportsLib.Services;


    internal sealed class Configuration : DbMigrationsConfiguration<Server.EF_ORM.FlashSportsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Server.EF_ORM.FlashSportsDB context)
        {
            context.Supports.AddOrUpdate(new Support() { Id = 1, SupportName = "AlexSup", Login = "alexsup@gmail.com", Password = "4d20a76cd11fb7c83e620c13ff66cf27" });
            context.Supports.AddOrUpdate(new Support() { Id = 2, SupportName = "MaxSup", Login = "maxsup@gmail.com", Password = "f5c9df0273cab7a70ba043ebebe371f3" });
            context.Supports.AddOrUpdate(new Support() { Id = 3, SupportName = "LeshaSup", Login = "leshasup@gmail.com", Password = "c171ceb2102a2387704f8634148fa85d" });
            context.Supports.AddOrUpdate(new Support() { Id = 4, SupportName = "IllyaSup", Login = "illyasup@gmail.com", Password = "9cab51e24894af2e174b4c8f9dd563f8" });
            context.Supports.AddOrUpdate(new Support() { Id = 5, SupportName = "TestSup", Login = "testsup@gmail.com", Password = "291bd3621fe9beb63c75f76ee59fa7db" });

            context.Users.AddOrUpdate(new User() { Id = 1, UserName = "Alex", Email = "alex@gmail.com", Password = "a08372b70196c21a9229cf04db6b7ceb", Photo = "alex.jpg" });
            context.Users.AddOrUpdate(new User() { Id = 2, UserName = "Max", Email = "max@gmail.com", Password = "6a061313d22e51e0f25b7cd4dc065233", Photo = "max.jpg" });
            context.Users.AddOrUpdate(new User() { Id = 3, UserName = "Lesha", Email = "lesha@gmail.com", Password = "0af897fb9074160975a15d4c28e4b217", Photo = "lesha.jpg" });
            context.Users.AddOrUpdate(new User() { Id = 4, UserName = "Illya", Email = "illya@gmail.com", Password = "c4d72a80afcbda95f978310375393e66", Photo = "illya.jpg" });
            context.Users.AddOrUpdate(new User() { Id = 5, UserName = "Test", Email = "test@gmail.com", Password = "0cbc6611f5540bd0809a388dc95a615b", Photo = "test.jpg" });

            context.Candies.AddOrUpdate(new Candy() { Id = 1, CandyAmount = 0, UserId = 1 });
            context.Candies.AddOrUpdate(new Candy() { Id = 2, CandyAmount = 0, UserId = 2 });
            context.Candies.AddOrUpdate(new Candy() { Id = 3, CandyAmount = 0, UserId = 3 });
            context.Candies.AddOrUpdate(new Candy() { Id = 4, CandyAmount = 0, UserId = 4 });
            context.Candies.AddOrUpdate(new Candy() { Id = 5, CandyAmount = 0, UserId = 5 });

            context.Categories.AddOrUpdate(new Category() { Id = 1, Title = "AlexSportType" });
            context.Categories.AddOrUpdate(new Category() { Id = 2, Title = "MaxSportType" });
            context.Categories.AddOrUpdate(new Category() { Id = 3, Title = "LeshaSportType" });
            context.Categories.AddOrUpdate(new Category() { Id = 4, Title = "IllyaSportType" });

            var apiManager = new ApiManager();
            // foreach...
        }
    }
}
