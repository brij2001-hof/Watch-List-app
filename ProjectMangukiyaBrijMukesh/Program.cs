using Microsoft.EntityFrameworkCore;
using ProjectMangukiyaBrijMukesh;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProjectMangukiyaBrijMukesh.Bmangukiya1Context>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("BrijConnection")));

var apiKey = "ae96b298ceaf1bbd95a9593a8ea046e7";
//var apiKey = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJhZTk2YjI5OGNlYWYxYmJkOTVhOTU5M2E4ZWEwNDZlNyIsInN1YiI6IjY1NmJjZWQzZmNhZGI0MDExZjg4YmNhNyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.vftQf52Hah2Rej8CtN7g49BKAvmAp_k7bhoO-_q_aSQ";
ApiAccess.ApiKey = apiKey;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
