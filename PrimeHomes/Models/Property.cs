using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrimeHomes.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public string Description { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
        public string Features1 { get; set; }
        public string Features2 { get; set; }
        public string Features3 { get; set; }
        public string Features4 { get; set; }

        public string SizeRange { get;set; }
        public string ListingNumber { get; set; }
        public int BedroomsId { get; set; }
        public virtual Bedrooms Bedrooms { get; set; }
        public int BathroomsId { get; set; }
        public virtual Bathrooms Bathrooms { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
        public string VirtualTourUrl { get; set; }
        public string LocationUrl { get; set; }

        public int FeaturesId { get; set; }
        public virtual Features Features { get; set; }
        public string Contact { get; set; }

        public int StockId  { get; set; }
        public virtual Stock Stock { get; set; }
       
        
        public string ImageUrl { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ImageUrl4 { get; set; }

        

    }
}
