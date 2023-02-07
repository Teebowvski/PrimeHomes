using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Linq;

namespace PrimeHomes.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();


            if (!context.TeamMembers.Any())
            {
                context.AddRange(new List<TeamMembers>()
                {
                    new TeamMembers(){ Name="Buba saho", Position="Lead Marketer", ImageUrl="", FacebookUrl="", LinkendenUrl="", TwitterUrl=""}

                });
                context.SaveChanges();
            }
            if (!context.Blogs.Any())
            {
                context.AddRange(new List<Blog>()
                {
                    new Blog(){Title="", Content="", MainContent="",BlogImageUrl="",BlogImageUrl2="", AboutAuthor="", AuthorName="", FacebookUrl="", InstagramUrl="",TwitterUrl="", LinkdelUrl=""}
                   
                });
                context.SaveChanges();
            }

            if (!context.Stocks.Any())
            {
                context.AddRange(new List<Stock>()
                {
                    new Stock(){Name="Available"},
                    new Stock(){Name="Unavailable"}
                });
                context.SaveChanges();
            }

            if (!context.Areas.Any())
            {
                context.AddRange(new List<Area>()
                {
                    new Area(){Name="Pipeline"},
                      new Area(){Name="Senegambia"},
                        new Area(){Name="Bijilo"},

                });
                context.SaveChanges();
            }
            if (!context.Bathrooms.Any())
            {
                context.AddRange(new List<Bathrooms>()
                {
                    new Bathrooms(){Number=1},
                    new Bathrooms(){Number=2},
                    new Bathrooms(){Number=3},
                    new Bathrooms(){Number=4},
                });
                context.SaveChanges();
            }

            if (!context.Bedrooms.Any())
            {
                context.AddRange(new List<Bedrooms>()
                {
                    new Bedrooms(){Number=1},
                    new Bedrooms(){Number=2},
                    new Bedrooms(){Number=3},
                    new Bedrooms(){Number=4},
                });
                context.SaveChanges();
            }

            if (!context.Features.Any())
            {
                context.AddRange(new List<Features>()
                {
                    new Features(){ Name="Security"},
                    new Features(){ Name="Garage"},
                    new Features(){ Name="Electricity"},
                    new Features(){ Name="Double Bed"},
                    new Features(){ Name="Gym"},
                    new Features(){ Name="Pool"},
                    new Features(){ Name="Balcony"},
                    new Features(){ Name="Air Conditioning"},
                    new Features(){ Name="Free Wifi"},
                });
                context.SaveChanges();
            }

            if (!context.Status.Any())
            {
                context.AddRange(new List<Status>()
                {
                    new Status(){Name="Sales"},
                    new Status(){Name="Rentals"},
                    new Status(){Name="Developments"}
                });
                context.SaveChanges();
            }

            if (!context.Types.Any())
            {
                context.AddRange(new List<Models.Type>()
                {
                    new Models.Type(){Name="Residential"},
                    new Models.Type(){Name="Commercial"}

                });
                context.SaveChanges();
            }

            if (!context.Properties.Any())
            {
                context.AddRange(new List<Property>()
                {
                    new Property(){ Name="The Diplomat", AreaId=1,BedroomsId=2,BathroomsId=2,TypeId=1, Description="",Description1="",Description2="",Description3="",Description4="",Features1="",Features2="",Features3="",Features4="",Price=78500,ListingNumber="",Contact="",StatusId=2, FeaturesId=1, ImageUrl="",ImageUrl1="",ImageUrl2="",ImageUrl3="",ImageUrl4="", SizeRange="", StockId= 1, LocationUrl="" }
                });
                context.SaveChanges();
            }

        }
    }
}
