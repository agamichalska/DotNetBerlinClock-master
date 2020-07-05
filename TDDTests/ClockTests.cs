using NUnit.Framework;
using System;
using System.Collections.Generic;
using TinyIoC;

namespace BerlinClock.TDDTests
{
    [TestFixture]
    public class ClockTests
    {
        private IClock _clock;
        private List<int> _timeTable;

        [SetUp]
        public void SetUp()
        {
            Container.Register();
            _clock = TinyIoCContainer.Current.Resolve<IClock>();
        }

        [Test]
        public void Throws_When_IncorrectInput()
        {
            var ex = Assert.Throws<ArgumentException>(() => _clock.ReadTime(new List<int>()));
            Assert.That(ex.Message, Is.EqualTo("Incorrect time table"));
        }

        [Test]
        public void ReadsTime_When_CorrectInput()
        {
            var output = "Y\r\nROOO\r\nROOO\r\nYOOOOOOOOOO\r\nYOOO";
            var input = new List<int> { 1, 1, 1, 1, 1 };

            Assert.AreEqual(output, _clock.ReadTime(input));
        }
    }
}
