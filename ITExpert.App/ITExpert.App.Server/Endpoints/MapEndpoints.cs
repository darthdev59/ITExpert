using ITExpert.Application.Values.Commands.CreateValues;
using ITExpert.Application.Values.Queries.GetValues;
using ITExpert.Domain.Shared;
using ITExpert.Persistence;
using MediatR;


namespace ITExpert.App.Server.Endpoints
{
    public static class MapEndpoints
    {
        public static void MapValuesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("values");

            group.MapPost("", async (CreateValueCommand values, ISender sender) =>
            {
                var result = await sender.Send(values);
                return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
            })
            .WithOpenApi()
            .WithName("Create values")
            .WithDescription("Create values");


            group.MapGet("", async (ISender sender) =>
            {
                var result = await sender.Send(new GetValuesQuery());
                return result.IsSuccess ? Results.Ok(result.Data) : Results.BadRequest(result.Error); ;
            })
            .WithOpenApi()
            .WithName("Get values");

            group.MapGet("filter", async (ISender sender) =>
            {

            })
            .WithOpenApi()
            .WithName("Get filtered values");
        }
    }
}
