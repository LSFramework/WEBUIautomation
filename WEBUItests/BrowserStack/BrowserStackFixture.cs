using NUnit.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUItests.BaseBrowsersTest;

namespace WEBUItests.BrowserStack
{
    /// <summary>
    /// A test fixture that can be run multiple times.
    /// </summary>
    [Serializable]
    public class BrowserStackFixture : TestSuite
    {
        /// <summary>
        /// Initializes an instance of this class.
        /// </summary>
        /// <remarks>
        /// This constructor creates the root test suite.
        /// </remarks>
        /// <param name="fixtureType">The type of the test fixture.</param>
        public BrowserStackFixture(Type fixtureType): base(fixtureType)
        {
            BrowserStackFixtureAttribute attr = (BrowserStackFixtureAttribute)Reflect.GetAttribute(fixtureType, typeof(BrowserStackFixtureAttribute).FullName, true);
            
            this.Fixture = Reflect.Construct(fixtureType);     

            MethodInfo method = Reflect.GetNamedMethod(fixtureType, attr.Argument);
        
            Params = (List<string>)method.Invoke(null, null);                

            foreach (string param in Params)
            {
                this.Add(new BrowserStackFixture(fixtureType, param));
            }
        }


        /// <summary>
        /// Initializes an instance of this class.
        /// </summary>
        /// <param name="fixtureType">The type of the test fixture</param>
        /// <param name="param">The argument to pass to the Test Fixture Set Up method</param>
        public BrowserStackFixture(Type fixtureType, string param) : base(fixtureType)
        {
            this.Fixture = Reflect.Construct(fixtureType); 
            this.Param = param;            
            ModifyTestName(this.TestName, param);            
            this.fixtureTearDownMethods = Reflect.GetMethodsWithAttribute(fixtureType, NUnitFramework.FixtureTearDownAttribute, true);           
            this.setUpMethods = Reflect.GetMethodsWithAttribute(fixtureType, NUnitFramework.SetUpAttribute, true);
            this.tearDownMethods = Reflect.GetMethodsWithAttribute(fixtureType, NUnitFramework.TearDownAttribute, true);            

            foreach (MethodInfo method in Reflect.GetMethodsWithAttribute(fixtureType, NUnitFramework.TestAttribute, true))
            {
                NUnitTestMethod methodTest = new NUnitTestMethod(method);
                ModifyTestName(methodTest.TestName, param);
                this.Add(methodTest);
            }            
        }

        /// <summary>
        /// Gets the argument under which this test fixture was created.
        /// This is <c>null</c> for the root test suite.
        /// </summary>
        private string Param { get; set; }

        private List<string> Params { get; set; }
        
        /// <summary>
        /// Performs a one-time set-up for this test suite.
        /// </summary>
        /// <remarks>
        /// The implementation calls the base method and then calls all methods decorated
        /// with NUnit's Test Fixture Set Up Attribute that accept a single argument parameter.
        /// </remarks>
        /// <param name="suiteResult">The result of the test.</param>
        protected override void DoOneTimeSetUp(TestResult suiteResult)
        {
            base.DoOneTimeSetUp(suiteResult);
            try
            {
                if (this.Param != null)
                {            
                    foreach (MethodInfo setupMethod in Reflect.GetMethodsWithAttribute(FixtureType, NUnitFramework.FixtureSetUpAttribute, true))
                    {
                        if (setupMethod.GetParameters().Length == 1)
                        {
                            Reflect.InvokeMethod(setupMethod, this.Fixture, this.Param);
                        }
                    }                   
                }
            }      
           
            catch (Exception innerException)
            {
                if (innerException is NUnitException || innerException is TargetInvocationException)
                {
                    innerException = innerException.InnerException;
                }

                if (innerException is InvalidTestFixtureException)
                {
                    suiteResult.Invalid(innerException.Message);
                }
                else
                {
                    if (this.IsIgnoreException(innerException))
                    {
                        base.RunState = RunState.Ignored;
                        suiteResult.Ignore(innerException.Message);
                        suiteResult.StackTrace = innerException.StackTrace;
                        base.IgnoreReason = innerException.Message;
                    }
                    else
                    {
                        if (this.IsAssertException(innerException))
                        {
                            suiteResult.Failure(innerException.Message, innerException.StackTrace, FailureSite.SetUp);
                        }
                        else
                        {
                            suiteResult.Error(innerException, FailureSite.SetUp);
                        }
                    }
                }
            }
           
        }

        private static void ModifyTestName(TestName name, string argument)
        {
            name.Name = ModifyName(name.Name, argument);
            name.FullName = ModifyName(name.FullName, argument);
        }

        private static string ModifyName(string originalName, string argument)
        {
            return string.Format("{0} ({1})", originalName, argument);
        }        
    }
}
