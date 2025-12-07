using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Request;
using System.Net;

namespace API.Endpoints
{
    public static class UserEndpoints
    {
        private readonly static List<User> _users = new List<User>();

        public static async Task<IResult> CreateUser([FromBody] CreateUserRequest user, [FromServices] IValidator<CreateUserRequest> validator)
        { 
            var result = await validator.ValidateAsync(user);
            if (!result.IsValid)
                return Results.BadRequest(result.Errors);

            user.CreateDatetime = DateTime.Now;
            _users.Add(user);
            return Results.Json(user, statusCode: (int?)HttpStatusCode.OK);
        }

        public static async Task<IResult> GetUser(int Id)
        {
            return Results.Json(_users.First(f => f.Id == Id), statusCode: (int?)HttpStatusCode.OK);
        }
    }
}
