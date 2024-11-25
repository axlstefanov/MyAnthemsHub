﻿using MyAnthemsAPI.Models.SongManagement;

namespace MyAnthemsAPI.Models.PlaylistManagement
{
    public class PlaylistSong
    {
        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }

        public string SongId { get; set; }
        public Song Song { get; set; }
    }
}