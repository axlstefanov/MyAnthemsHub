using MyAnthemsAPI.Models.PlaylistManagement;

namespace MyAnthemsAPI.Models.SongManagement
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Spotifylink { get; set; }

        public List<PlaylistSong> PlaylistSongs { get; set; }
    }
}
