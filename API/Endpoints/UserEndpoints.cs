using Microsoft.AspNetCore.Mvc;
using Model;
using System.Net;

namespace API.Endpoints
{
    public static class UserEndpoints
    {
        private readonly static List<User> _users = new List<User>();

        public static async Task<IResult> CreateUser([FromBody] User user)
        {
            if (user == null) throw new Exception("error");

            if (user.Id < 0 || string.IsNullOrEmpty(user.UserName))
            {
                return Results.Json(HttpStatusCode.BadRequest);
            }

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
