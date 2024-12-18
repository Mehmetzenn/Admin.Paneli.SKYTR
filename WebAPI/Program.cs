using adm�ndeneme;
using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger/OpenAPI yap�land�rmas�
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB ba�lant� dizesini ve di�er yap�land�rma ayarlar�n� appsettings.json'dan al�yoruz
string connectionString = builder.Configuration.GetValue<string>("MongoDb:ConnectionString");
string databaseName = builder.Configuration.GetValue<string>("MongoDb:DatabaseName");

// Parametrelerin null olup olmad���n� kontrol et
if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
{
    throw new ArgumentNullException("MongoDB ba�lant� parametreleri bo� olamaz.");
}

// CustomerDal'� DI konteynerine ekliyoruz ve gerekli parametreleri sa�l�yoruz
builder.Services.AddScoped<ICustomerDal>(provider =>
    new CustomerDal(connectionString, databaseName)); // Parametre do�ru iletildi

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
