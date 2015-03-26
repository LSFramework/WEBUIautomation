using System;

namespace WEBUItests.BrowserStack
{
    /// <summary>
    /// Marks a class as a test fixture that can be run multiple times.
    /// The class must have a FixtureSetUp method that accepts a single argument.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class BrowserStackFixtureAttribute : Attribute
    {
        /// <summary>
        /// The arguments of the test fixture. Each argument results in one call of the entire Test Fixture.
        /// </summary>
        /// <param name="argument">The arguments of the Test Fixture.</param>
        public BrowserStackFixtureAttribute(string argument)
        {
            Argument = argument;
        }

        /// <summary>
        /// Gets the arguments of the Test Fixture.
        /// </summary>
        public string Argument { get; private set; }
    }
}
