using System.IO;
using System.Reflection;

namespace AngloAmerican.SDET.APITest.Config
{
    class ConfigSetUp
    {
        public static string GetProjectDirectoryPath()
        {
            var testProjectAssemblyPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            var projDirPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(testProjectAssemblyPath).ToString()).ToString());
            return projDirPath.ToString();
        }
    }
}
