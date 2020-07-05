using NUnit.Framework;

namespace BerlinClock.TDDTests
{
    [TestFixture]
    public class LampTests
    {
        [Test]
        public void LampIsOff_When_Created()
        {
            var lamp = new Lamp();

            Assert.AreEqual("O", lamp.GetColor());
        }

        [Test]
        public void LampIsOn_When_TurnedOn()
        {
            var lamp = new Lamp();
            lamp.TurnOn();

            Assert.AreEqual("W", lamp.GetColor());
        }

        [Test]
        public void LampIsOff_When_TurnedOff()
        {
            var lamp = new Lamp();
            lamp.TurnOff();

            Assert.AreEqual("O", lamp.GetColor());
        }

        [Test]
        public void YellowLampIsYellow()
        {
            var lamp = new YellowLamp();
            lamp.TurnOn();

            Assert.AreEqual("Y", lamp.GetColor());
        }

        [Test]
        public void RedLampIsRed()
        {
            var lamp = new RedLamp();
            lamp.TurnOn();

            Assert.AreEqual("R", lamp.GetColor());
        }
    }
}
