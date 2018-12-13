namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private readonly IStage stage;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly ISetFactory setfactory;

		public FestivalController(IStage stage, ISetFactory setFactory, IInstrumentFactory instrumentFactory)
		{
			this.stage = stage;
            this.instrumentFactory = instrumentFactory;
            this.setfactory = setFactory;
		}

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = this.setfactory.CreateSet(name, type);
            this.stage.AddSet(set);

            string result = $"Registered {type} set";
            return result;
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumenti = args.Skip(2).ToArray();

            var instrumenti2 = instrumenti
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = new Performer(name, age);

            foreach (var instrument in instrumenti2)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            int[] durations = args[1]
                .Split(":")
                .Select(int.Parse)
                .ToArray();
            TimeSpan duration = new TimeSpan(0, durations[0], durations[1]);
            ISong song = new Song(name, duration);
            this.stage.AddSong(song);

            return $"Registered song {name} ({duration:mm\\:ss})";
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song} to {set.Name}";
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string ProduceReport()
		{
            StringBuilder builder = new StringBuilder();

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

			builder.AppendLine($"Festival length: {FormatTimeSpan(totalFestivalLength)}");

			foreach (var set in this.stage.Sets)
			{
				builder.AppendLine($"--{set.Name} ({FormatTimeSpan(set.ActualDuration)}):");

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					builder.AppendLine($"---{performer.Name} ({instruments})");
				}

                if (!set.Songs.Any())
                    builder.AppendLine("--No songs played");
                else
                {
                    builder.AppendLine("--Songs played:");

                    foreach (var song in set.Songs)
                    {
                        builder.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})");
                    }
                }
			}

			return builder.ToString().TrimEnd();
		}

        private static string FormatTimeSpan(TimeSpan timeSpan)
        {
            var formatted = string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);
            return formatted;
        }
    }
}