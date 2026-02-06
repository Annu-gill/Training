using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStreamingService
{
    // ===================== Song Class =====================
    public class Song
    {
        public string SongId { get; private set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Album { get; set; }
        public TimeSpan Duration { get; set; }
        public int PlayCount { get; set; }

        public Song(string id, string title, string artist, string genre,
                    string album, TimeSpan duration)
        {
            SongId = id;
            Title = title;
            Artist = artist;
            Genre = genre;
            Album = album;
            Duration = duration;
            PlayCount = 0;
        }
    }

    // ===================== Playlist Class =====================
    public class Playlist
    {
        public string PlaylistId { get; private set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public List<Song> Songs { get; set; }

        public Playlist(string id, string name, string createdBy)
        {
            PlaylistId = id;
            Name = name;
            CreatedBy = createdBy;
            Songs = new List<Song>();
        }
    }

    // ===================== User Class =====================
    public class User
    {
        public string UserId { get; private set; }
        public string UserName { get; set; }
        public List<string> FavoriteGenres { get; set; }
        public List<Playlist> UserPlaylists { get; set; }

        public User(string id, string userName)
        {
            UserId = id;
            UserName = userName;
            FavoriteGenres = new List<string>();
            UserPlaylists = new List<Playlist>();
        }
    }

    // ===================== Music Manager =====================
    public class MusicManager
    {
        private readonly List<Song> songs = new List<Song>();
        private readonly List<User> users = new List<User>();
        private int songCounter = 1;
        private int playlistCounter = 1;
        private int userCounter = 1;

        // Add Song
        public void AddSong(string title, string artist, string genre,
                            string album, TimeSpan duration)
        {
            string songId = "S" + songCounter++;
            songs.Add(new Song(songId, title, artist, genre, album, duration));
        }

        // Create User
        public void AddUser(string userName)
        {
            string userId = "U" + userCounter++;
            users.Add(new User(userId, userName));
        }

        // Create Playlist
        public void CreatePlaylist(string userId, string playlistName)
        {
            User user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
                throw new Exception("User not found.");

            string playlistId = "P" + playlistCounter++;
            user.UserPlaylists.Add(new Playlist(playlistId, playlistName, user.UserName));
        }

        // Add Song to Playlist
        public bool AddSongToPlaylist(string playlistId, string songId)
        {
            Playlist playlist = users
                .SelectMany(u => u.UserPlaylists)
                .FirstOrDefault(p => p.PlaylistId == playlistId);

            Song song = songs.FirstOrDefault(s => s.SongId == songId);

            if (playlist == null || song == null)
                return false;

            if (playlist.Songs.Any(s => s.SongId == songId))
                return false;

            playlist.Songs.Add(song);
            return true;
        }

        // Group Songs by Genre
        public Dictionary<string, List<Song>> GroupSongsByGenre()
        {
            return songs
                .GroupBy(s => s.Genre)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get Top Played Songs
        public List<Song> GetTopPlayedSongs(int count)
        {
            return songs
                .OrderByDescending(s => s.PlayCount)
                .Take(count)
                .ToList();
        }

        // Simulate Song Play
        public void PlaySong(string songId)
        {
            Song song = songs.FirstOrDefault(s => s.SongId == songId);
            if (song != null)
                song.PlayCount++;
        }

        public List<Song> GetAllSongs() => songs;
        public List<User> GetAllUsers() => users;
    }

    // ===================== Program Class =====================
    class Program
    {
        public static void Main()
        {
            MusicManager manager = new MusicManager();

            while (true)
            {
                Console.WriteLine("\n===== Music Streaming Service =====");
                Console.WriteLine("1. Add Song");
                Console.WriteLine("2. Add User");
                Console.WriteLine("3. Create Playlist");
                Console.WriteLine("4. Add Song to Playlist");
                Console.WriteLine("5. Group Songs by Genre");
                Console.WriteLine("6. Play Song");
                Console.WriteLine("7. Top Played Songs");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Title: ");
                            string title = Console.ReadLine();

                            Console.Write("Artist: ");
                            string artist = Console.ReadLine();

                            Console.Write("Genre: ");
                            string genre = Console.ReadLine();

                            Console.Write("Album: ");
                            string album = Console.ReadLine();

                            Console.Write("Duration (mm:ss): ");
                            TimeSpan duration = TimeSpan.Parse("00:" + Console.ReadLine());

                            manager.AddSong(title, artist, genre, album, duration);
                            Console.WriteLine("Song added successfully.");
                            break;

                        case 2:
                            Console.Write("User Name: ");
                            string userName = Console.ReadLine();

                            manager.AddUser(userName);
                            Console.WriteLine("User added successfully.");
                            break;

                        case 3:
                            Console.Write("User ID: ");
                            string userId = Console.ReadLine();

                            Console.Write("Playlist Name: ");
                            string playlistName = Console.ReadLine();

                            manager.CreatePlaylist(userId, playlistName);
                            Console.WriteLine("Playlist created.");
                            break;

                        case 4:
                            Console.Write("Playlist ID: ");
                            string playlistId = Console.ReadLine();

                            Console.Write("Song ID: ");
                            string songId = Console.ReadLine();

                            bool added = manager.AddSongToPlaylist(playlistId, songId);
                            Console.WriteLine(added
                                ? "Song added to playlist."
                                : "Failed to add song.");
                            break;

                        case 5:
                            var grouped = manager.GroupSongsByGenre();
                            foreach (var group in grouped)
                            {
                                Console.WriteLine($"\nGenre: {group.Key}");
                                foreach (var s in group.Value)
                                    Console.WriteLine($"{s.SongId} - {s.Title} by {s.Artist}");
                            }
                            break;

                        case 6:
                            Console.Write("Song ID: ");
                            string playId = Console.ReadLine();

                            manager.PlaySong(playId);
                            Console.WriteLine("Song played.");
                            break;

                        case 7:
                            Console.Write("Top N: ");
                            int n = int.Parse(Console.ReadLine());

                            var topSongs = manager.GetTopPlayedSongs(n);
                            foreach (var s in topSongs)
                                Console.WriteLine($"{s.Title} | Plays: {s.PlayCount}");
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
