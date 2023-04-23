using Microsoft.AspNetCore.Authentication.JwtBearer;
using MinimalJwt.Models;
using MinimalJwt.Service;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer( options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidateIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthentication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IMovieService, MovieService>();
builder.Services.AddSingleton<IUserService, UserService>();



var app = builder.Build();

app.UseSwagger();
app.UseAuthorization();
app.UseAuthentication();




app.MapGet("/", () => "Hello World!");

app.MapPost("/create",
    (Movie movie, IMovieService service) => Create(movie, service));

app.MapGet("/get",
    (int id, IMovieService service) => Get(id, service));

app.MapGet("/list",
    ( IMovieService service) => GetAll(service));

app.MapPut("/update",
    (Movie newMovie, IMovieService service) => Update(newMovie, service));

app.MapDelete("/delete",
    (int id, IMovieService service) => Delete(id, service));

IResult Create( Movie movie, IMovieService service)
{
     var result = service.Create(movie);
    return Results.Ok(result);
}

IResult Get(int id, IMovieService service)
{
    var movie = service.Get(id);
    if (movie is null) return Results.NotFound("Movie not found");
    return Results.Ok(movie);
}

IResult GetAll(IMovieService service)
{
    var movies = service.GetAll();
    if (movies is null) return Results.NotFound("Movies not found");
    return Results.Ok(movies); ;
}
IResult Update(Movie newMovie, IMovieService service)
{
    var updateMovie = service.Update(newMovie);
    if (updateMovie is null) return Results.NotFound("Movies not found");
    return Results.Ok(updateMovie);
}
IResult Delete(int id, IMovieService service)
{
    var result = service.Delete(id);
   if (!result) return Results.BadRequest("Something went wrong");
    return Results.Ok(result);
}

app.UseSwaggerUI();
app.Run();
