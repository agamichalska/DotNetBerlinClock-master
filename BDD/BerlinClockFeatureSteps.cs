using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TinyIoC;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter berlinClock;
        private String theTime;

        public TheBerlinClockSteps()
        {
            Container.Register();
            berlinClock = TinyIoCContainer.Current.Resolve<ITimeConverter>();
        }

        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(berlinClock.convertTime(theTime), theExpectedBerlinClockOutput);
        }

    }
}
