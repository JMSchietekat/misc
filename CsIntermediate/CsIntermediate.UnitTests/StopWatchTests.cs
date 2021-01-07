
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsIntermediate;

namespace CsIntermediate.UnitTests
{
    [TestClass]
    public class StopWatchTests
    {
        // MethodName_Condition_Expectation
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Start_StopwatchIsAlreadyStarted_ThrowsAnException()
        {
            var stopwatch = new StopWatch();
            stopwatch.Start();
            stopwatch.Start();
        }

        [TestMethod]
        public void Duration_StopwatchStartedAndStopped_SecondsEqualDelayTime()
        {
            var random = new Random();
            var seconds = random.Next(1, 5);
            
            var stopwatch = new StopWatch();
            stopwatch.Start();
            Thread.Sleep(seconds * 1000);
            stopwatch.Stop();

            Assert.AreEqual(seconds, stopwatch.Duration().Seconds);
        }
    }
}