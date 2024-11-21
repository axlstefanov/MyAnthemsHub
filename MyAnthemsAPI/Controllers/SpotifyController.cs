using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAnthemsAPI.Services;

namespace MyAnthemsAPI.Controllers
{
    [Authorize]
    public class SpotifyController(ISpotifyService spotifyService) : GenericController
    {
        [HttpGet]
        public async Task<IResult> SearchTracks([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Results.BadRequest("Query cannot be empty.");

            var songs = await spotifyService.SearchTracksAsync(query);
            if (songs == null || !songs.Any())
                return Results.NotFound("No tracks found for the given query.");

            return Results.Ok(songs);
        }
    }
}