using NUnit.Framework;
using System;
using TinyIoC;

namespace BerlinClock.TDDTests
{
    [TestFixture]
    public class TimeConverterTests
    {
        private ITimeConverter _berlinClock;

        [SetUp]
        public void SetUp()
        {
            Container.Register();
            _berlinClock = TinyIoCContainer.Current.Resolve<ITimeConverter>();
        }

        [Test]
        public void Throws_When_IncorrectTimeFormat()
        {
            var ex = Assert.Throws<ArgumentException>(() => _berlinClock.convertTime(""));
            Assert.That(ex.Message, Is.EqualTo("Incorrect time format"));
        }

        [Test]
        public void DoesntThrow_When_CorrectTimeFormat()
        {
            Assert.DoesNotThrow(() =>_berlinClock.convertTime("00:00:00"));
        }

        [Test]
        public void HasFiveRows()
        {
            var result = _berlinClock.convertTime("00:00:00");
            string[] lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            Assert.AreEqual(5, lines.Length);
        }

        [Test]
        public void FirstRowHas1Lamp()
        {
            Assert.AreEqual(1, GetRow(_berlinClock.convertTime("00:00:00"), 0).Length);
        }

        [Test]
        public void SecondRowHas4Lamps()
        {
            Assert.AreEqual(4, GetRow(_berlinClock.convertTime("00:00:00"), 1).Length);
        }

        [Test]
        public void ThirdRowHas4Lamps()
        {
            Assert.AreEqual(4, GetRow(_berlinClock.convertTime("00:00:00"), 2).Length);
        }

        [Test]
        public void FourthRowHas11Lamps()
        {
            Assert.AreEqual(11, GetRow(_berlinClock.convertTime("00:00:00"), 3).Length);
        }

        [Test]
        public void FifthRowHas4Lamps()
        {
            Assert.AreEqual(4, GetRow(_berlinClock.convertTime("00:00:00"), 4).Length);
        }

        [Test]
        public void FirstRowBlinksYellow_When_EvenSeconds()
        {
            Assert.AreEqual("Y", GetRow(_berlinClock.convertTime("00:00:00"), 0));
        }

        [Test]
        public void FirstRowOff_When_OddSeconds()
        {
            Assert.AreEqual("O", GetRow(_berlinClock.convertTime("00:00:01"), 0));
        }

        [Test]
        public void SecondRowOff_When_HourIsLessThanFive()
        {
            Assert.AreEqual("OOOO", GetRow(_berlinClock.convertTime("01:00:00"), 1));
        }

        [Test]
        public void SecondRowDisplayOneRed_When_HourIsLessThanTen()
        {
            Assert.AreEqual("ROOO", GetRow(_berlinClock.convertTime("09:00:00"), 1));
        }

        [Test]
        public void SecondRowDisplayTwoRed_When_HourIsLessThanFifteen()
        {
            Assert.AreEqual("RROO", GetRow(_berlinClock.convertTime("12:00:00"), 1));
        }

        [Test]
        public void SecondRowDisplayThreeRed_When_HourIsLessThanTwenty()
        {
            Assert.AreEqual("RRRO", GetRow(_berlinClock.convertTime("19:00:00"), 1));
        }

        [Test]
        public void SecondRowDisplayFourRed_When_HourIsGreaterThanTwenty()
        {
            Assert.AreEqual("RRRR", GetRow(_berlinClock.convertTime("23:00:00"), 1));
        }

        [Test]
        public void ThirdRowOff_When_HoursIsMultiplyOfFive()
        {
            Assert.AreEqual("OOOO", GetRow(_berlinClock.convertTime("05:00:00"), 2));
        }

        [Test]
        public void ThirdRowDisplayOneRed()
        {
            Assert.AreEqual("ROOO", GetRow(_berlinClock.convertTime("06:00:00"), 2));
        }

        [Test]
        public void ThirdRowDisplayTwoRed()
        {
            Assert.AreEqual("RROO", GetRow(_berlinClock.convertTime("12:00:00"), 2));
        }

        [Test]
        public void ThirdRowDisplayThreeRed()
        {
            Assert.AreEqual("RRRO", GetRow(_berlinClock.convertTime("23:00:00"), 2));
        }

        [Test]
        public void ThirdRowDisplayFourRed()
        {
            Assert.AreEqual("RRRR", GetRow(_berlinClock.convertTime("09:00:00"), 2));
        }

        [Test]
        public void FourthRowOff_When_MinutesLessThanFive()
        {
            Assert.AreEqual("OOOOOOOOOOO", GetRow(_berlinClock.convertTime("00:02:00"), 3));
        }

        [Test]
        public void FourthRowDisplayForteenMinutes()
        {
            Assert.AreEqual("YYOOOOOOOOO", GetRow(_berlinClock.convertTime("00:14:00"), 3));
        }

        [Test]
        public void FourthRowDisplayTwentySixMinutes()
        {
            Assert.AreEqual("YYRYYOOOOOO", GetRow(_berlinClock.convertTime("00:26:00"), 3));
        }

        private string GetRow(string clock, int rowIndex)
        {
            string[] lines = clock.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            return lines[rowIndex];
        }
    }
}
