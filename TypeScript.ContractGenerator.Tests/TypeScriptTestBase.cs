using NUnit.Framework;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;

namespace SkbKontur.TypeScript.ContractGenerator.Tests
{
    [TestFixture(JavaScriptTypeChecker.TypeScript)]
    public abstract class TypeScriptTestBase : TestBase
    {
        protected TypeScriptTestBase(JavaScriptTypeChecker javaScriptTypeChecker)
            : base(javaScriptTypeChecker)
        {
        }
    }
}