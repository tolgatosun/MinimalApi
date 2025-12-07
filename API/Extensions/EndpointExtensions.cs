using API.Endpoints;
using API.Filter;
using FluentValidation;
using Model.Request;

namespace API.Extensions
{
    public static class EndpointExtensions
    {

        public static void MapEndpoints(this WebApplication app)
        {
            app.MapPost("/users", UserEndpoints.CreateUser)
               .AddEndpointFilter<GlobalExceptionFilter>();
             
            app.MapGet("/users/{id}", UserEndpoints.GetUser);
        }
    }
}
