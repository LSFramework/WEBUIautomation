using NUnit.Core;
using NUnit.Core.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUItests.BrowserStack
{
    /// <summary>
    /// Entry point for the Browser Test Fixture Addin.
    /// </summary>
    [NUnitAddin(Description = "Browser Stack Fixture Addin", Name = "BrowserStackFixtureAddin", Type = ExtensionType.Core)]
    public class BrowserStackFixtureAddin : IAddin, ISuiteBuilder
    {
        #region IAddin

        /// <summary>
        /// Installs this addin in NUnit's Suite Builders.
        /// </summary>
        /// <param name="host">The extension host.</param>
        /// <returns><c>true</c> if installation was successful; <c>false</c> otherwise.</returns>
        public bool Install(IExtensionHost host)
        {
            IExtensionPoint extensionPoint = host.GetExtensionPoint("SuiteBuilders");
            if (extensionPoint != null)
            {
                extensionPoint.Install(this);
                return true;
            }

            return false;
        }

        #endregion

        #region ISuiteBuilder

        /// <summary>
        /// Builds a test from the given type.
        /// </summary>
        /// <param name="type">The type to build a test from. This must be a class decorated with <see cref="BrowserStackFixtureAttribute"/>.</param>
        /// <returns>A corresponding test, which is of type <see cref="BrowserStackFixture"/>.</returns>
        public Test BuildFrom(Type type)
        {
            return new BrowserStackFixture(type);
        }

        /// <summary>
        /// Checks if this suite builder can create a test for the given type.
        /// </summary>
        /// <param name="type">A type.</param>
        /// <returns><c>true</c> if the type isn't abstract, has a default constructor and is decorated with
        /// <see cref="BrowserStackFixtureAttribute"/>; <c>false</c> otherwise.</returns>
        public bool CanBuildFrom(Type type)
        {
            return !type.IsAbstract &&
                type.GetConstructor(Type.EmptyTypes) != null &&
                NUnit.Core.Reflect.HasAttribute(type, typeof(BrowserStackFixtureAttribute).FullName, true);
        }
        #endregion
    }
}
