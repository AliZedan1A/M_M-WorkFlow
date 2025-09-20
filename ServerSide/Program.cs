using ServerSide.db;
using ServerSide.Services.Class;
using ServerSide.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MMDbContext>();
builder.Services.AddScoped<DateTimeService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddScoped<AttachmentService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 52428800;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
