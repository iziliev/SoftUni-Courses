// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{

    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void PerformerTest1()
	    {
			var performer = new Performer("Ivaylo", "Iliev", 38);

			Assert.AreEqual("Ivaylo Iliev",performer.FullName);
			Assert.AreEqual(38, performer.Age);
			Assert.AreEqual(0, performer.SongList.Count);
			Assert.AreEqual("Ivaylo Iliev", performer.ToString());
		}

		[Test]
		public void SongTest1()
		{
			var song = new Song("1", new TimeSpan(0,5,38));

			Assert.AreEqual("1", song.Name);
			Assert.AreEqual(new TimeSpan(00,05,38), song.Duration);
			Assert.AreEqual("1 (05:38)", song.ToString());
		}

		[Test]
		public void StageTest1()
		{
			var stage = new Stage();

			Assert.AreEqual(0, stage.Performers.Count);
		}

		[Test]
		public void AddPerformerTest1()
		{
			var stage = new Stage();
			var performer = new Performer("Ivaylo", "Iliev", 38);
			var performer1 = new Performer("Gosho", "Goshov", 88);

			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null), "Can not be null!");
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Ivaylo", "Iliev", 17)), "You can only add performers that are at least 18.");

			stage.AddPerformer(performer);
			Assert.AreEqual(1, stage.Performers.Count);
			Assert.AreEqual(performer.FullName, stage.Performers.FirstOrDefault(x => x.FullName == "Ivaylo Iliev").ToString());

			stage.AddPerformer(performer1);

			Assert.AreEqual(2, stage.Performers.Count);
			Assert.AreEqual(performer1.FullName, stage.Performers.FirstOrDefault(x => x.FullName == "Gosho Goshov").ToString());
		}

		[Test]
		public void AddSongTest1()
		{
			var stage = new Stage();
			var song = new Song("1", new TimeSpan(0, 5, 38));
			var song2 = new Song("2", new TimeSpan(0, 3, 38));
			var song3 = new Song("2", new TimeSpan(0, 0, 38));

			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null), "Can not be null!");
			Assert.Throws<ArgumentException>(() => stage.AddSong(song3), "You can only add songs that are longer than 1 minute.");

			stage.AddSong(song);
		}


		[Test]
		public void AddSongToPerformerTest1()
		{
			var stage = new Stage();

			var performer = new Performer("Ivaylo", "Iliev", 38);
			var performer1 = new Performer("Gosho", "Goshov", 88);

			var song = new Song("1", new TimeSpan(0, 5, 38));
			var song2 = new Song("2", new TimeSpan(0, 3, 38));

			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null,"Ivaylo Iliev"), "Can not be null!");
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("1", null), "Can not be null!");

			stage.AddPerformer(performer);
			stage.AddPerformer(performer1);
			stage.AddSong(song);
			stage.AddSong(song2);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("1","Ivayl Iliev"), "There is no performer with this name.");
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("3", "Ivaylo Iliev"), "There is no song with this name.");

			var message = stage.AddSongToPerformer("1", "Ivaylo Iliev");

			Assert.AreEqual("1 (05:38) will be performed by Ivaylo Iliev",message);
			Assert.AreEqual("2 (03:38) will be performed by Gosho Goshov", stage.AddSongToPerformer("2", "Gosho Goshov"));
		}

		[Test]
		public void PlayTest1()
		{
			var stage = new Stage();

			var performer = new Performer("Ivaylo", "Iliev", 38);
			var performer1 = new Performer("Gosho", "Goshov", 88);

			var song = new Song("1", new TimeSpan(0, 5, 38));
			var song2 = new Song("2", new TimeSpan(0, 3, 38));
			var song3 = new Song("3", new TimeSpan(0, 2, 38));

			stage.AddPerformer(performer);
			stage.AddPerformer(performer1);
			
			stage.AddSong(song);
			stage.AddSong(song2);
			stage.AddSong(song3);

			Assert.AreEqual("1 (05:38) will be performed by Ivaylo Iliev", stage.AddSongToPerformer("1", "Ivaylo Iliev"));
			Assert.AreEqual("2 (03:38) will be performed by Gosho Goshov", stage.AddSongToPerformer("2", "Gosho Goshov"));
			Assert.AreEqual("3 (02:38) will be performed by Ivaylo Iliev", stage.AddSongToPerformer("3", "Ivaylo Iliev"));

			Assert.AreEqual("2 performers played 3 songs",stage.Play());

		}
	}
}