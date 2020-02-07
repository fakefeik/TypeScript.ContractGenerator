using System;

using SkbKontur.TypeScript.ContractGenerator.CodeDom;

namespace SkbKontur.TypeScript.ContractGenerator.Internals
{
    public class DefaultCodeGenerationContext : ICodeGenerationContext
    {
        public string Tab => "    ";
        public string NewLine => "\n";

        public string GetReferenceFromUnitToAnother(TypeScriptUnit currentUnit, TypeScriptUnit targetUnit)
        {
            var path1 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + currentUnit.Path);
            var path2 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + targetUnit.Path);
            var diff = path1.MakeRelativeUri(path2);
            return "./" + diff.OriginalString;
        }

        public string GetReferenceFromUnitToAnother(string currentUnit, string targetUnit)
        {
            var path1 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + currentUnit);
            var path2 = new Uri(@"C:\a\a\a\a\a\a\a\a\" + targetUnit);
            var diff = path1.MakeRelativeUri(path2);
            return "./" + diff.OriginalString;
        }
    }
}