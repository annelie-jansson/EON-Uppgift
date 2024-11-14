using EON_Uppgift;

namespace EON_Uppgift_Tests
{
    [TestFixture]
    public class CycleCalculatorTests
    {
        [Test]
        public void TestLongCycle()
        {
            List<string> cycles = new() {
"addx 15",
"addx -11",
"addx 6",
"addx -3",
"addx 5",
"addx -1",
"addx -8",
"addx 13",
"addx 4",
"noop",
"addx -1",
"addx 5",
"addx -1",
"addx 5",
"addx -1",
"addx 5",
"addx -1",
"addx 5",
"addx -1",
"addx -35",
"addx 1",
"addx 24",
"addx -19",
"addx 1",
"addx 16",
"addx -11",
"noop",
"noop",
"addx 21",
"addx -15",
"noop",
"noop",
"addx -3",
"addx 9",
"addx 1",
"addx -3",
"addx 8",
"addx 1",
"addx 5",
"noop",
"noop",
"noop",
"noop",
"noop",
"addx -36",
"noop",
"addx 1",
"addx 7",
"noop",
"noop",
"noop",
"addx 2",
"addx 6",
"noop",
"noop",
"noop",
"noop",
"noop",
"addx 1",
"noop",
"noop",
"addx 7",
"addx 1",
"noop",
"addx -13",
"addx 13",
"addx 7",
"noop",
"addx 1",
"addx -33",
"noop",
"noop",
"noop",
"addx 2",
"noop",
"noop",
"noop",
"addx 8",
"noop",
"addx -1",
"addx 2",
"addx 1",
"noop",
"addx 17",
"addx -9",
"addx 1",
"addx 1",
"addx -3",
"addx 11",
"noop",
"noop",
"addx 1",
"noop",
"addx 1",
"noop",
"noop",
"addx -13",
"addx -19",
"addx 1",
"addx 3",
"addx 26",
"addx -30",
"addx 12",
"addx -1",
"addx 3",
"addx 1",
"noop",
"noop",
"noop",
"addx -9",
"addx 18",
"addx 1",
"addx 2",
"noop",
"noop",
"addx 9",
"noop",
"noop",
"noop",
"addx -1",
"addx 2",
"addx -37",
"addx 1",
"addx 3",
"noop",
"addx 15",
"addx -21",
"addx 22",
"addx -6",
"addx 1",
"noop",
"addx 2",
"addx 1",
"noop",
"addx -10",
"noop",
"noop",
"addx 20",
"addx 1",
"addx 2",
"addx 2",
"addx -6",
"addx -11",
"noop",
"noop",
"noop",
            };
            CycleCalculator calculator = new CycleCalculator();

            var result = calculator.RunCycles(cycles);

            Assert.That(result, Is.EqualTo(13140));
        }

        [Test]
        public void NoopDoesNotChangeScore() 
        {
            List<string> cycles = new() { "noop", "noop", "noop" };
            CycleCalculator calculator = new CycleCalculator(17);

            var result = calculator.RunCycles(cycles);

            Assert.That(result, Is.EqualTo(20));
        }


        [Test]
        public void AddXWillAddToScore()
        {
            List<string> cycles = new() { "addx 2", "noop", "noop" };
            CycleCalculator calculator = new CycleCalculator(17);

            var result = calculator.RunCycles(cycles);

            Assert.That(result, Is.EqualTo(60));
        }

        [Test]
        public void AddXWillSubtractFromScore()
        {
            List<string> cycles = new() { "addx -2", "noop", "noop" };
            CycleCalculator calculator = new CycleCalculator(17);

            var result = calculator.RunCycles(cycles);

            Assert.That(result, Is.EqualTo(-20));
        }


        [Test]
        public void AddXTakesTwoCyclesToScore()
        {
            List<string> cycles = new() { "noop", "addx -999", "noop" };
            CycleCalculator calculator = new CycleCalculator(17);

            var result = calculator.RunCycles(cycles);
            
            Assert.That(result, Is.EqualTo(20));
        }

    }
}
