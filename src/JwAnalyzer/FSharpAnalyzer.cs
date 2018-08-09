using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System;

namespace JwAnalyzer {

    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class FSharpAnalyzer : DiagnosticAnalyzer {

        static DiagnosticDescriptor Rule =
            new DiagnosticDescriptor(
                "CALL191",
                "Use F#",
                "You are using C# swith to F# instead",
                "Language Choice",
                DiagnosticSeverity.Warning,
                isEnabledByDefault: true,
                helpLinkUri: "http://fsharp.org"
            );

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context) {
            context.RegisterSyntaxTreeAction(AnalyzeTree);
        }

        private static void AnalyzeTree(SyntaxTreeAnalysisContext context) {
            var rootLocation = context.Tree.GetRoot().GetLocation();
            var diag = Diagnostic.Create(Rule, rootLocation);
            context.ReportDiagnostic(diag);
        }
    }
}