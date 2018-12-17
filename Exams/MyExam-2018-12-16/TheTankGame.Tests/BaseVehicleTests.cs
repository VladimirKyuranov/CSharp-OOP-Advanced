using TheTankGame.Entities.Vehicles;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Parts;
using TheTankGame.Entities.Parts.Contracts;

namespace TheTankGame.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class BaseVehicleTests
    {
        public object IVehicle { get; private set; }

        [Test]
        public void BaseVehicleTest()
        {
            IAssembler assembler = new VehicleAssembler();
            IVehicle vanguard = new Vanguard("Vanguard1", 500, 1000, 500, 500, 1000, assembler);
            IVehicle revenger = new Revenger("Revenger1", 1000, 500, 1000, 1000, 500, assembler);
            IPart arsenalPart = new ArsenalPart("Arsenal1", 100, 100, 100);
            IPart shellPart = new ShellPart("Shell1", 100, 100, 100);
            IPart endurancePart = new EndurancePart("Endurance1", 100, 100, 100);
            vanguard.AddArsenalPart(arsenalPart);
            vanguard.AddEndurancePart(endurancePart);
            vanguard.AddShellPart(shellPart);

            double totalWeight = vanguard.TotalWeight;
            decimal totalPrice = vanguard.TotalPrice;
            long totalAttack = vanguard.TotalAttack;
            long totalDefense = vanguard.TotalDefense;
            long totalHitPoints = vanguard.TotalHitPoints;

            Assert.That(totalWeight, Is.EqualTo(800).NoClip);
            Assert.That(totalPrice, Is.EqualTo(1300).NoClip);
            Assert.That(totalAttack, Is.EqualTo(600).NoClip);
            Assert.That(totalDefense, Is.EqualTo(600).NoClip);
            Assert.That(totalHitPoints, Is.EqualTo(1100).NoClip);

            string expectedResult = "Vanguard - Vanguard1\r\nTotal Weight: 800.000\r\nTotal Price: 1300.000\r\nAttack: 600\r\nDefense: 600\r\nHitPoints: 1100\r\nParts: Arsenal1, Endurance1, Shell1";
            string actualResult = vanguard.ToString();

            Assert.That(expectedResult, Is.EqualTo(actualResult).NoClip);
        }
    }
}