using CourseProvider.Infrastructure.Data.Entities;
using CourseProvider.Infrastructure.Models;

namespace CourseProvider.Infrastructure.Factories
{
    public static class CourseFactory
    {
        public static CourseEntity Create(CourseCreateRequest request)
        {
            return new CourseEntity
            {
                ImageUri = request.ImageUri,
                ImageHeaderUri = request.ImageHeaderUri,
                IsBestSeller = request.IsBestSeller,
                IsDigital = request.IsDigital,
                Categories = request.Categories,
                Title = request.Title,
                Ingress = request.Ingress,
                StarRating = request.StarRating,
                Reviews = request.Reviews,
                LikesInPercentage = request.LikesInPercentage,
                LikesInNumber = request.LikesInNumber,
                Hours = request.Hours,
                Authors = request.Authors?.Select(author => new AuthorEntity
                {
                    Name = author.Name,
                }).ToList(),
                Prices = request.Prices == null ? null : new PricesEntity
                {
                    Price = request.Prices.Price,
                    Currency = request.Prices.Currency,
                    Discount = request.Prices.Discount,
                },
                Content = request.Content == null ? null : new ContentEntity
                {
                    Description = request.Content.Description,
                    Includes = request.Content.Includes,
                    CourseIncludes = request.Content.CourseIncludes,
                    ProgramDetails = request.Content.ProgramDetails?.Select(programDetail => new ProgramDetailItemEntity
                    {
                        Title = programDetail.Title,
                        Description = programDetail.Description,
                    }).ToList(),
                },
            };
        }

        public static CourseEntity Update(CourseUpdateRequest request)
        {
            return new CourseEntity
            {
                Id = request.Id,
                ImageUri = request.ImageUri,
                ImageHeaderUri = request.ImageHeaderUri,
                IsBestSeller = request.IsBestSeller,
                IsDigital = request.IsDigital,
                Categories = request.Categories,
                Title = request.Title,
                Ingress = request.Ingress,
                StarRating = request.StarRating,
                Reviews = request.Reviews,
                LikesInPercentage = request.LikesInPercentage,
                LikesInNumber = request.LikesInNumber,
                Hours = request.Hours,
                Authors = request.Authors?.Select(author => new AuthorEntity
                {
                    Name = author.Name,
                }).ToList(),
                Prices = request.Prices == null ? null : new PricesEntity
                {
                    Price = request.Prices.Price,
                    Currency = request.Prices.Currency,
                    Discount = request.Prices.Discount,
                },
                Content = request.Content == null ? null : new ContentEntity
                {
                    Description = request.Content.Description,
                    Includes = request.Content.Includes,
                    CourseIncludes = request.Content.CourseIncludes,
                    ProgramDetails = request.Content.ProgramDetails?.Select(programDetail => new ProgramDetailItemEntity
                    {
                        Title = programDetail.Title,
                        Description = programDetail.Description,
                    }).ToList(),
                },
            };
        }

        public static Course Create(CourseEntity entity)
        {
            return new Course
            {
                Id = entity.Id,
                ImageUri = entity.ImageUri,
                ImageHeaderUri = entity.ImageHeaderUri,
                IsBestSeller = entity.IsBestSeller,
                IsDigital = entity.IsDigital,
                Categories = entity.Categories,
                Title = entity.Title,
                Ingress = entity.Ingress,
                StarRating = entity.StarRating,
                Reviews = entity.Reviews,
                LikesInPercentage = entity.LikesInPercentage,
                LikesInNumber = entity.LikesInNumber,
                Hours = entity.Hours,
                Authors = entity.Authors?.Select(author => new Author
                {
                    Name = author.Name,
                }).ToList(),
                Prices = entity.Prices == null ? null : new Prices
                {
                    Price = entity.Prices.Price,
                    Currency = entity.Prices.Currency,
                    Discount = entity.Prices.Discount,
                },
                Content = entity.Content == null ? null : new Content
                {
                    Description = entity.Content.Description,
                    Includes = entity.Content.Includes,
                    CourseIncludes = entity.Content.CourseIncludes,
                    ProgramDetails = entity.Content.ProgramDetails?.Select(programDetail => new ProgramDetailItem
                    {
                        Title = programDetail.Title,
                        Description = programDetail.Description,
                    }).ToList(),
                },
            };
        }
    }
}
