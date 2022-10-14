using CRUDEMOVIESWEBAPI.Context;
using CRUDEMOVIESWEBAPI.Repository;
using CRUDEMOVIESWEBAPI.Repository.Interface;
using CRUDEMOVIESWEBAPI.ShoppingRepository;
using CRUDEMOVIESWEBAPI.ShoppingRepository.InterfaceShoping;
using LoandLoanAproveBankCustomer.Repository.Class;
using LoandLoanAproveBankCustomer.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped < IActorRepository,ActorRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMoviesCastRepository, MoviesCastRepository>();
builder.Services.AddScoped<ImovieDirectionRepository, movieDirectionRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<IhitorfloporBlockbusterRepository, HitFlopOrBlockbusterRepository>();
builder.Services.AddScoped<IReviwerRepository, ReviewerRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IAproveLoansRepository, AproveLoansRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();  
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IShopingRepository, ShopingRepository>();








// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
