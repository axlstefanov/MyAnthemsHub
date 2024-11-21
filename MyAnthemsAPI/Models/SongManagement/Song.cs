namespace MyAnthemsAPI.Models.SongManagement
{
    public class Song
    {
        public string Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Spotifylink { get; set; } = string.Empty;

        //public List<PlaylistSong>? PlaylistSongs { get; set; }
        public string Album { get; internal set; }
        public TimeSpan Duration { get; internal set; }
    }
}