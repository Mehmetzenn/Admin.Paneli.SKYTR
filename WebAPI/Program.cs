using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger/OpenAPI yapýlandýrmasý
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB baðlantý dizesini ve diðer yapýlandýrma ayarlarýný appsettings.json'dan alýyoruz
string connectionString = builder.Configuration.GetValue<string>("MongoDb:ConnectionString");
string databaseName = builder.Configuration.GetValue<string>("MongoDb:DatabaseName");
string collectionName = builder.Configuration.GetValue<string>("MongoDb:CollectionName");

// Parametrelerin null olup olmadýðýný kontrol et
if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName) || string.IsNullOrEmpty(collectionName))
{
    throw new ArgumentNullException("MongoDB baðlantý parametreleri boþ olamaz.");
}

// CustomerDal'ý DI konteynerine ekliyoruz ve gerekli parametreleri saðlýyoruz
builder.Services.AddScoped<ICustomerDal>(provider =>
    new CustomerDal(connectionString, databaseName, collectionName));

builder.Services.AddScoped<ICustomerService, CustomerManager>();

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
