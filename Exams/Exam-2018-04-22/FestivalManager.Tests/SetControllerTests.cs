using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;
// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void PerforSetsTest()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);
            ISet set = new Short("Set1");
            ISet set2 = new Short("Set2");
            stage.AddSet(set);
            stage.AddSet(set2);
            IPerformer performer = new Performer("Pesho", 23);
            IInstrument guitar = new Guitar();
            stage.AddPerformer(performer);
            set.AddPerformer(performer);
            performer.AddInstrument(guitar);
            ISong song = new Song("Song1", new System.TimeSpan(0, 5, 0));
            stage.AddSong(song);
            set.AddSong(song);

            string expectedResult = "1. Set1:" + "\r\n" +
                "-- 1. Song1 (05:00)" + "\r\n" +
                "-- Set Successful" + "\r\n" +
                "2. Set2:" + "\r\n" +
                "-- Did not perform";


            string actualResult = setController.PerformSets();

            Assert.That(actualResult, Is.EqualTo(expectedResult).NoClip);
            Assert.That(guitar.Wear, Is.EqualTo(40));
        }
    }
}