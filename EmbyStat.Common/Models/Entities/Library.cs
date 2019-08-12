﻿using LiteDB;

namespace EmbyStat.Common.Models.Entities
{
    public class Library
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string PrimaryImage { get; set; }
        public LibraryType Type { get; set; }
    }

    public enum LibraryType
    {
        Other = 0,
        Movies = 1,
        TvShow = 2,
        Music = 3,
        MusicVideos = 4,
        Trailers = 5,
        HomeVideos = 6,
        Books = 8,
        Photos = 9,
        Games = 10,
        LiveTv = 11,
        Playlists = 12,
        Folders = 13,
        BoxSets = 14
    }
}
