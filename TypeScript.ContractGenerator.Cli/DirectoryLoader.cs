using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace SkbKontur.TypeScript.ContractGenerator.Cli
{
    public class TestAssemblyLoadContext : AssemblyLoadContext
    {
        public TestAssemblyLoadContext(string mainAssemblyToLoadPath)
            : base(isCollectible : true)
        {
            resolver = new AssemblyDependencyResolver(mainAssemblyToLoadPath);
        }

        protected override Assembly Load(AssemblyName name)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(a => a.FullName.Split(',')[0].Equals(name.Name, StringComparison.OrdinalIgnoreCase));
            if (assembly != null)
                return assembly;
            string assemblyPath = resolver.ResolveAssemblyToPath(name);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }

            return null;
        }

        private readonly AssemblyDependencyResolver resolver;
    }
}