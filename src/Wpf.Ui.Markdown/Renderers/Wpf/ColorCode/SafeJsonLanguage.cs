using System.Collections.Generic;
using ColorCode;
using ColorCode.Common;

namespace Wpf.Ui.Markdown.Renderers.Wpf.ColorCode;

/// <summary>
/// A JSON language definition that avoids catastrophic regex backtracking in ColorCode's built-in JSON parser.
/// </summary>
internal sealed class SafeJsonLanguage : ILanguage
{
    public static readonly SafeJsonLanguage Instance = new();

    // Friedl's unrolled loop – avoids backtracking while still handling escaped characters.
    private const string RegexString = @"""[^""\\]*(?:\\.[^""\\]*)*""";
    private const string RegexNumber = @"-?(?:0|[1-9][0-9]*)(?:\.[0-9]*)?(?:[eE][-+]?[0-9]+)?";

    private static readonly IList<LanguageRule> RulesList = new List<LanguageRule>
    {
        new LanguageRule(
            $@"[,\{{]\s*({RegexString})\s*:",
            new Dictionary<int, string> { { 1, ScopeName.JsonKey } }),
        new LanguageRule(
            RegexString,
            new Dictionary<int, string> { { 0, ScopeName.JsonString } }),
        new LanguageRule(
            RegexNumber,
            new Dictionary<int, string> { { 0, ScopeName.JsonNumber } }),
        new LanguageRule(
            @"\b(true|false|null)\b",
            new Dictionary<int, string> { { 0, ScopeName.JsonConst } }),
    };

    public string Id => LanguageId.Json;

    public string Name => "JSON";

    public string CssClassName => "json";

    public string? FirstLinePattern => null;

    public IList<LanguageRule> Rules => RulesList;

    public bool HasAlias(string lang) => false;
}
