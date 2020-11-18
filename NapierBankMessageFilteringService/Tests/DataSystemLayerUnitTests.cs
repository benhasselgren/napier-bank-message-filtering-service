using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Tests
{
    [TestClass]
    public class DataSystemLayerUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            string path = "My.Tool.Namespace";
            string file = thisAssembly.GetManifestResourceStream(path + "." + "test.csv").ToString();
        }
    }
}
