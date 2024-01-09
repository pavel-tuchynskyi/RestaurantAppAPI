using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Application.Account.Events;
using RestaurantApp.Application.Common.Behaviors;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Helpers;
using RestaurantApp.Application.Common.Interfaces;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.DrinkMenu.Commands.CreateDrinkItem;
using RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItems;
using RestaurantApp.Application.Ingridients.Command.CreateIngridient;
using RestaurantApp.Application.ItalianFoodMenu.Commands.CreateItalianFood;
using RestaurantApp.Application.ItalianFoodMenu.Queries.GetFoodItem;
using RestaurantApp.Application.ItalianFoodMenu.Queries.GetItalianFood;
using RestaurantApp.Application.JapaneesFoodMenu.Commands.CreateJapaneesFood;
using RestaurantApp.Application.JapaneesFoodMenu.Queries.GetJapaneesFood;
using RestaurantApp.Application.JapaneesFoodMenu.Queries.GetJapaneesFoodItem;
using RestaurantApp.Domain.MenuItems.Drink;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.Food.Italian;
using RestaurantApp.Domain.MenuItems.Food.Japanees;
using RestaurantApp.Domain.Users.Events;
using System.Reflection;

namespace RestaurantApp.Application.Configuration
{
    public static class DIConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.ConfigureMediatr();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(FoodCreatorResolver<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

        private static IServiceCollection ConfigureMediatr(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddTransient<IRequestHandler<CreateIngridientCommand<ItalianFoodIngridient>, Unit>, 
                CreateIngridientCommandHandler<ItalianFoodIngridient>>();
            services.AddTransient<IRequestHandler<CreateIngridientCommand<JapaneesFoodIngridient>, Unit>,
                CreateIngridientCommandHandler<JapaneesFoodIngridient>>();

            services.AddTransient<IRequestHandler<CreateItalianFoodCommand<Pizza>, Unit>,
                CreateItalianFoodCommandHandler<Pizza>>();

            services.AddTransient<IRequestHandler<CreateJapaneesFoodCommand<Susi>, Unit>,
                CreateJapaneesFoodCommandHandler<Susi>>();
            services.AddTransient<IRequestHandler<CreateJapaneesFoodCommand<Rolls>, Unit>,
                CreateJapaneesFoodCommandHandler<Rolls>>();
            services.AddTransient<IRequestHandler<CreateJapaneesFoodCommand<Set>, Unit>,
                CreateJapaneesFoodCommandHandler<Set>>();

            services.AddTransient<IRequestHandler<GetItalianFoodItemQuery<Pizza>, FoodItemDto>,
                GetItalianFoodItemQueryHandler<Pizza>>();

            services.AddTransient<IRequestHandler<GetItalianFoodQuery<Pizza>, PagedList<FoodItemDto>>,
                GetItalianFoodQueryHandler<Pizza>>();

            services.AddTransient<IRequestHandler<GetJapaneesFoodItemQuery<Susi>, FoodItemDto>,
                GetJapaneesFoodItemQueryHandler<Susi>>();
            services.AddTransient<IRequestHandler<GetJapaneesFoodItemQuery<Rolls>, FoodItemDto>,
                GetJapaneesFoodItemQueryHandler<Rolls>>();
            services.AddTransient<IRequestHandler<GetJapaneesFoodItemQuery<Set>, FoodItemDto>,
                GetJapaneesFoodItemQueryHandler<Set>>();

            services.AddTransient<IRequestHandler<GetJapaneesFoodQuery<Susi>, PagedList<FoodItemDto>>,
                GetJapaneesFoodQueryHandler<Susi>>();
            services.AddTransient<IRequestHandler<GetJapaneesFoodQuery<Rolls>, PagedList<FoodItemDto>>,
                GetJapaneesFoodQueryHandler<Rolls>>();
            services.AddTransient<IRequestHandler<GetJapaneesFoodQuery<Set>, PagedList<FoodItemDto>>,
                GetJapaneesFoodQueryHandler<Set>>();

            services.AddTransient<IRequestHandler<CreateDrinkItemCommand<Beer>, Unit>,
                CreateDrinkItemCommandHandler<Beer>>();
            services.AddTransient<IRequestHandler<CreateDrinkItemCommand<Wine>, Unit>,
                CreateDrinkItemCommandHandler<Wine>>();
            services.AddTransient<IRequestHandler<CreateDrinkItemCommand<NonAlcoholDrink>, Unit>,
                CreateDrinkItemCommandHandler<NonAlcoholDrink>>();

            services.AddTransient<IRequestHandler<GetDrinkItemsQuery<Wine>, PagedList<DrinkItemDto>>,
                GetDrinkItemsQueryHandler<Wine>>();
            services.AddTransient<IRequestHandler<GetDrinkItemsQuery<Beer>, PagedList<DrinkItemDto>>,
                GetDrinkItemsQueryHandler<Beer>>();
            services.AddTransient<IRequestHandler<GetDrinkItemsQuery<NonAlcoholDrink>, PagedList<DrinkItemDto>>,
                GetDrinkItemsQueryHandler<NonAlcoholDrink>>();

            return services;
        }
    }
}
