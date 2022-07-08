namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Problem 02. All Albums Produced by Given Producer
            //var producerId = int.Parse(Console.ReadLine());
            //Console.WriteLine(ExportAlbumsInfo(context,producerId));

            //Problem 03. Songs Above Given Duration
            var durationInSecconds = int.Parse(Console.ReadLine());
            Console.WriteLine(ExportSongsAboveDuration(context,durationInSecconds));
        }

        //Problem 02. All Albums Produced by Given Producer
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var albumsInfo = context.Albums
                .Where(a => a.ProducerId.Value == producerId)
                .Include(a=>a.Producer)
                .Include(a=>a.Songs)
                .ThenInclude(s=>s.Writer)
                .ToArray()
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price,
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer),
                    AlbumPrice = a.Songs.Sum(p => p.Price)
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToArray();

            foreach (var album in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                var i = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{i++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.Writer}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }

            return sb.ToString().Trim();

        }

        //Problem 03. Songs Above Given Duration
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songsByDuration = context.Songs
                .Include(s=>s.SongPerformers)
                .ThenInclude(sp=>sp.Performer)
                .Include(s=>s.Writer)
                .Include(s=>s.Album)
                .ThenInclude(s=>s.Producer)
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    SongPerformer = s.SongPerformers
                    .ToArray()
                    .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                    .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s=>s.SongName)
                .ThenBy(s=>s.WriterName)
                .ThenBy(s=>s.SongPerformer)
                .ToArray();
            
            var i = 1;
            foreach (var song in songsByDuration)
            {
                sb.AppendLine($"-Song #{i++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.SongPerformer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().Trim();
        }
    }
}
