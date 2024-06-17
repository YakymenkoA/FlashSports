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

            context.Categories.AddOrUpdate(new Category() { Id = 1, Title = "Golf" });
            context.Categories.AddOrUpdate(new Category() { Id = 2, Title = "Cricket" });
            context.Categories.AddOrUpdate(new Category() { Id = 3, Title = "Soccer" });
            context.Categories.AddOrUpdate(new Category() { Id = 4, Title = "IllyaSportType" });

            context.News.AddOrUpdate(new News() {
                Id = 1,
                Title = "Hamburg police shoot man with axe ahead of Euros match",
                Content = "A major operation has taken place in central Hamburg after a man with an axe threatened police officers, officials in the German city say." +
                "\r\nPolice say they shot and seriously injured the man, who is receiving medical attention." +
                "\r\nMedia reports say the incident took place near a fanzone for supporters of the Dutch football team." +
                "\r\nThe Netherlands faced Poland in the city in the Euro 2024 tournament on Sunday." +
                "\r\nAn initial police statement said that a man threatened police officers with a pickaxe and an \"incendiary device\"." +
                "\r\nLater, a Hamburg police spokesperson told the BBC the suspect was armed with a pickaxe and had tried to ignite a petrol bomb – but that officers responded with pepper spray and then shot him." +
                "\r\nThe incident is understood to have taken place at around 12:30 local time (10:30 GMT)." +
                "\r\nVideo footage posted online, shows a man wielding an axe in front of police officers before a series of suspected gunshot sounds can be heard." +
                "\r\nThe man has not been identified by the police and the authorities have not commented on what motivations they believe were behind the incident.",
                Picture = "somepicture.png"
            });
            context.News.AddOrUpdate(new News()
            {
                Id = 2,
                Title = "Ashes pain forgiven? England rescued by old foe",
                Content = "Alex Carey, David Warner, Steve Smith and all of that Ashes pain - England fans forgive you." +
                "\r\nFor Scotland, this was T20 World Cup heartache - with Chris Sole's dropped catch in the final over only adding to 36 hours of cruel sporting misery." +
                "\r\nFor England, Australia’s gripping victory against Scotland - which knocked out the Scots and sent Jos Buttler’s side through to the Super 8s - offered pure relief, served up by their oldest cricketing rivals." +
                "\r\nLast summer Travis Head was pounding England bowlers in an attempt to win back the Ashes urn." +
                "\r\nHe was in the middle on that final day at The Oval with Smith, the pair threatening to take Australia home before Stuart Broad’s grand finale." +
                "\r\nEighteen months earlier, during England’s most recent venture down under, Head flogged Ben Stokes et al around Brisbane in a blistering century." +
                "\r\nIt was only the second day of the series, but England would never recover from it.",
                Picture = "somepicture.png"
            });

            context.Comments.AddOrUpdate(new Comment() { Id = 1, NewsId = 1, UserId = 1, Content = "ok!" });
            context.Comments.AddOrUpdate(new Comment() { Id = 2, NewsId = 1, UserId = 2, Content = "wow bad news!" });
            context.Comments.AddOrUpdate(new Comment() { Id = 3, NewsId = 1, UserId = 3, Content = "wow amazing news!" });
            context.Comments.AddOrUpdate(new Comment() { Id = 4, NewsId = 1, UserId = 4, Content = "wow cool news!" });

            context.Comments.AddOrUpdate(new Comment() { Id = 5, NewsId = 2, UserId = 1, Content = "my comment!" });
            context.Comments.AddOrUpdate(new Comment() { Id = 6, NewsId = 2, UserId = 2, Content = "his comment!" });
            context.Comments.AddOrUpdate(new Comment() { Id = 7, NewsId = 2, UserId = 3, Content = "something!" });
            context.Comments.AddOrUpdate(new Comment() { Id = 8, NewsId = 2, UserId = 4, Content = "no!" });

            var apiManager = new ApiManager();
            // foreach... use AddOrUpdate();
            foreach (var soccer in apiManager.SoccerGetInfo())
            {
                context.SportEvents.AddOrUpdate(soccer);
            }

            foreach (var cricket in apiManager.CricketGetInfo().Result)
            {
                context.SportEvents.AddOrUpdate(cricket);
            }

            foreach (var golf in apiManager.GolfGetInfoAsync().Result)
            {
                context.SportEvents.AddOrUpdate(golf);
            }
        }
    }
}
