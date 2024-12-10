﻿// ReSharper disable StringLiteralTypo

using System.Runtime.CompilerServices;

namespace BlazorBootstrap;

/// <summary>
/// Extensions for code highlighting
/// </summary>
public static class CodeExtensions
{

    /// <summary>
    /// Generates a code tag for PrismJS highlighting, to be used in pre or code HTML tags.
    /// </summary>
    /// <param name="languageCode">Language to select</param>
    /// <returns>Selected language lookup for Prism.js usage.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetCodeLanguage(this LanguageCode languageCode)
    {
        return "language-" + SupportedCodeLanguages[languageCode];
    }

    /// <summary>
    /// Supported code styles for PrismJS to format the code.
    /// </summary>

    internal static readonly Dictionary<LanguageCodeStyles, string> SupportedCodeStyles = new()
    {
        { LanguageCodeStyles.Atom, "atom" },
        { LanguageCodeStyles.CLike, "clike" },
        { LanguageCodeStyles.Css, "css" },
        { LanguageCodeStyles.Dfs, "dfs" },
        { LanguageCodeStyles.Html, "html" },
        { LanguageCodeStyles.Javascript, "javascript" },
        { LanguageCodeStyles.Js, "js" },
        { LanguageCodeStyles.Markup, "markup" },
        { LanguageCodeStyles.Mathml, "mathml" },
        { LanguageCodeStyles.Plain, "plain" }
    };

    /// <summary>
    /// Supported programming languages, config file styles and their corresponding PrismJS settings.
    /// </summary>

    internal static readonly Dictionary<LanguageCode, string> SupportedCodeLanguages = new()
    {
        { LanguageCode.ABAP, "abap" },
        { LanguageCode.ABNF, "abnf" },
        { LanguageCode.ActionScript, "actionscript" },
        { LanguageCode.Ada , "ada"},
        { LanguageCode.Agda, "agda" },
        { LanguageCode.Al, "al" },
        { LanguageCode.Antlr4, "antlr4" },
        { LanguageCode.ApacheConfig, "apacheconf" },
        { LanguageCode.Apex, "apex" },
        { LanguageCode.Apl, "apl" },
        { LanguageCode.AppleScript, "applescript" },
        { LanguageCode.AQL, "aql" },
        { LanguageCode.Arduino, "arduino" },
        { LanguageCode.ARFF, "arff" },
        { LanguageCode.AssemblyArm, "armasm" },
        { LanguageCode.Assembly6502, "asm6502" },
        { LanguageCode.Arturo, "arturo" },
        { LanguageCode.AsciiDoc, "asciidoc" },
        { LanguageCode.AspNet, "aspnet" },
        { LanguageCode.AtmelAvrAssembly, "asmatmel" },
        { LanguageCode.Atom, "atom" },
        { LanguageCode.AutoHotkey, "autohotkey" },
        { LanguageCode.AutoIt, "autoit" },
        { LanguageCode.AviSynth, "avisynth" },
        { LanguageCode.AvroIdl, "avdl" },
        { LanguageCode.Awk, "awk" },
        { LanguageCode.Bash, "bash" },
        { LanguageCode.Basic, "basic" },
        { LanguageCode.Batch , "batch" },
        { LanguageCode.BbCode, "bbcode" },
        { LanguageCode.Bbj, "bbj" },
        { LanguageCode.Bicep, "bicep" },
        { LanguageCode.Birb, "birb" },
        { LanguageCode.Bison, "bison" },
        { LanguageCode.Bnf, "bnf" },
        { LanguageCode.Bqn, "bqn" },
        { LanguageCode.BrainFuck, "brainfuck" },
        { LanguageCode.Bro, "bro" },
        { LanguageCode.Bsl, "bsk" },
        { LanguageCode.C, "c" },
        { LanguageCode.CPlusPlus, "cpp" },
        { LanguageCode.CSharp, "csharp" },
        { LanguageCode.CfScript, "cfc" },
        { LanguageCode.ChaiScript, "chaiscript" },
        { LanguageCode.Cil, "cil" },
        { LanguageCode.CilkC, "cilkc" },
        { LanguageCode.CilkCPlusPlus, "cilkcpp" },
        { LanguageCode.Clike, "clike" },
        { LanguageCode.Clojure, "clojure" },
        { LanguageCode.Cmake, "cmake" },
        { LanguageCode.Cobol, "cobol" },
        { LanguageCode.CoffeeScript, "coffee" },
        { LanguageCode.Concurnas , "conc" },
        { LanguageCode.ContentSecurityPolicy, "csp" },
        { LanguageCode.CookLang, "cooklang" },
        { LanguageCode.Coq, "coq" },
        { LanguageCode.Crystal, "crystal" },
        { LanguageCode.Css, "css" },
        { LanguageCode.CssExtras, "css-extras" },
        { LanguageCode.Csv, "csv" },
        { LanguageCode.Cue, "cue" },
        { LanguageCode.Cypher, "cypher" },
        { LanguageCode.D, "d" },
        { LanguageCode.Dart, "dart" },
        { LanguageCode.DataWeave, "dataweave" },
        { LanguageCode.Dax, "dax" },
        { LanguageCode.Dhall, "dhall" },
        { LanguageCode.Diff, "diff" },
        { LanguageCode.Django, "django" },
        { LanguageCode.DnsZoneFile, "dns-zone-file" },
        { LanguageCode.Docker, "docker" },
        { LanguageCode.DotGraphvi, "gv" },
        { LanguageCode.EditorConfig, "editorconfig" },
        { LanguageCode.Eiffel, "eiffel" },
        { LanguageCode.Ejs, "ejs" },
        { LanguageCode.Elixir, "agda" },
        { LanguageCode.Elm, "elm" },
        { LanguageCode.EmbeddedLuaTemplating, "etlua" },
        { LanguageCode.Erb, "erb" },
        { LanguageCode.Erlang, "erlang" },
        { LanguageCode.ExcelFormula, "xls" },
        { LanguageCode.FSharp, "fsharp" },
        { LanguageCode.Factor, "factor" },
        { LanguageCode.False, "false" },
        { LanguageCode.FirestoreSecurityRules, "firestore-security-rules" },
        { LanguageCode.Flow, "flow" },
        { LanguageCode.Fortran, "fortran" },
        { LanguageCode.FreeMarkerTemplateLanguage, "ftl" },
        { LanguageCode.GameMakerLanguage, "gml" },
        { LanguageCode.Gap, "gap" },
        { LanguageCode.GCode, "gcode" },
        { LanguageCode.GdScript, "gdscript" },
        { LanguageCode.Gedcom, "gedcom" },
        { LanguageCode.GetText, "gettext" },
        { LanguageCode.Gherkin, "gherkin" },
        { LanguageCode.Git, "git" },
        { LanguageCode.Glsl, "glsl" },
        { LanguageCode.Gn, "gn" },
        { LanguageCode.GnuLinkerScript, "ld" },
        { LanguageCode.Go, "go" },
        { LanguageCode.GoModule, "go-mod" },
        { LanguageCode.Gradle, "gradle" },
        { LanguageCode.GraphQl, "graphql" },
        { LanguageCode.Groovy, "groovy" },
        { LanguageCode.Haml, "haml" },
        { LanguageCode.HandleBars, "hbs" },
        { LanguageCode.Haskell, "haskell" },
        { LanguageCode.Haxe, "haxe" },
        { LanguageCode.Hcl, "hcl" },
        { LanguageCode.Hlsl, "hlsl" },
        { LanguageCode.Hoon, "hoon" },
        { LanguageCode.Html, "html" },
        { LanguageCode.Http, "http" },
        { LanguageCode.HttpPublicKeyPins, "hpkp" },
        { LanguageCode.HttpStrictTransportSecurity, "hsts" },
        { LanguageCode.IchigoJam, "ichigojam" },
        { LanguageCode.Icon, "icon" },
        { LanguageCode.IcuMessageFormat, "icu-message-format" },
        { LanguageCode.Idris, "idr" },
        { LanguageCode.Ignore, "ignore" },
        { LanguageCode.InformSeven, "inform7" },
        { LanguageCode.Ini, "ini" },
        { LanguageCode.Io, "io" },
        { LanguageCode.J, "j" },
        { LanguageCode.Java, "java" },
        { LanguageCode.JavaDoc, "javadoc" },
        { LanguageCode.JavaDocLike, "javadoclike" },
        { LanguageCode.JavaScript, "js" },
        { LanguageCode.JavaStackTrace, "javastacktrace" },
        { LanguageCode.Jexl, "jexl" },
        { LanguageCode.Jolie, "jolie" },
        { LanguageCode.JsDoc, "jsdoc" },
        { LanguageCode.JsExtras, "js-extras" },
        { LanguageCode.Json, "json" },
        { LanguageCode.JsonFive, "json5" },
        { LanguageCode.Jsonp, "jsonp" },
        { LanguageCode.JsStacktrace, "jsstacktrace" },
        { LanguageCode.JsTemplates, "js-templates" },
        { LanguageCode.Julia, "julia" },
        { LanguageCode.KeepAlivedConfigure, "keepalived" },
        { LanguageCode.Keyman, "keyman" },
        { LanguageCode.Kotlin, "kotlin" },
        { LanguageCode.KuMir, "kumir" },
        { LanguageCode.Kusto, "kusto" },
        { LanguageCode.LaTeX, "latex" },
        { LanguageCode.Latte, "latte" },
        { LanguageCode.Less, "agda" },
        { LanguageCode.LilyPond, "ly" },
        { LanguageCode.Liquid, "liquid" },
        { LanguageCode.Lisp, "lisp" },
        { LanguageCode.LiveScript, "livescript" },
        { LanguageCode.LLVM, "llvm" },
        { LanguageCode.LogFile, "log" },
        { LanguageCode.LolCode, "agda" },
        { LanguageCode.Lua, "lua" },
        { LanguageCode.MakeFile, "makefile" },
        { LanguageCode.Markdown, "md" },
        { LanguageCode.MarkupTemplating, "markup-templating" },
        { LanguageCode.Mata, "mata" },
        { LanguageCode.Matlab, "matlab" },
        { LanguageCode.MaxScript, "maxscript" },
        { LanguageCode.Mel, "mel" },
        { LanguageCode.Mermaid, "mermaid" },
        { LanguageCode.Metafont, "metafont" },
        { LanguageCode.Mizar, "mizar" },
        { LanguageCode.MongoDb, "mongodb" },
        { LanguageCode.Monkey, "monkey" },
        { LanguageCode.MoonScript, "moonscript" },
        { LanguageCode.NOneQl, "n1ql" },
        { LanguageCode.NFourJs, "n4js" },
        { LanguageCode.NandToTetrisHdl, "nand2tetris-hdl" },
        { LanguageCode.Naninovel, "nani" },
        { LanguageCode.Nasm, "nasm" },
        { LanguageCode.Neon, "neon" },
        { LanguageCode.Nevod, "nevod" },
        { LanguageCode.NGinx, "nginx" },
        { LanguageCode.Nim, "nim" },
        { LanguageCode.Nix, "nix" },
        { LanguageCode.Nsis, "nsis" },
        { LanguageCode.ObjectiveC, "objc" },
        { LanguageCode.Ocaml, "ocaml" },
        { LanguageCode.Odin, "odin" },
        { LanguageCode.OpenCl, "opencl" },
        { LanguageCode.OpenQasm, "openqasm" },
        { LanguageCode.Oz, "oz" },
        { LanguageCode.PariGp, "parigp" },
        { LanguageCode.Parser, "parser" },
        { LanguageCode.Pascal, "pascal" },
        { LanguageCode.Pascaligo, "pascaligo" },
        { LanguageCode.Patrol, "psl" },
        { LanguageCode.PcAxis, "pcaxis" },
        { LanguageCode.PeopleCode, "pcode" },
        { LanguageCode.Perl, "perl" },
        { LanguageCode.Php, "php" },
        { LanguageCode.PhpDoc, "phpdoc" },
        { LanguageCode.PhpExtras, "php-extras" },
        { LanguageCode.PlantUml, "plantuml" },
        { LanguageCode.PlSql, "plsql" },
        { LanguageCode.PowerQuery, "powerquery" },
        { LanguageCode.PowerShell, "powershell" },
        { LanguageCode.Processing, "processing" },
        { LanguageCode.Prolog, "prolog" },
        { LanguageCode.PromQl, "promql" },
        { LanguageCode.Properties, "properties" },
        { LanguageCode.Protobuf, "protobuf" },
        { LanguageCode.Pug, "pug" },
        { LanguageCode.Puppet, "puppet" },
        { LanguageCode.Pure, "pure" },
        { LanguageCode.PureBasic, "purebasic" },
        { LanguageCode.PureScript, "purescript" },
        { LanguageCode.Python, "python" },
        { LanguageCode.QSharp, "qsharp" },
        { LanguageCode.Q, "q" },
        { LanguageCode.Qml, "qml" },
        { LanguageCode.Qore, "qore" },
        { LanguageCode.R, "r" },
        { LanguageCode.Racket, "racket" },
        { LanguageCode.Razor, "cshtml" },
        { LanguageCode.ReactJs, "jsx" },
        { LanguageCode.ReactTsx, "tsx" },
        { LanguageCode.Reason, "reason" },
        { LanguageCode.Regex, "regex" },
        { LanguageCode.Rego, "rego" },
        { LanguageCode.Renpy, "renpy" },
        { LanguageCode.ReScript, "rescript" },
        { LanguageCode.ReST, "rest" },
        { LanguageCode.Rip, "rip" },
        { LanguageCode.Roboconf, "roboconf" },
        { LanguageCode.RobotFramework, "robotframework" },
        { LanguageCode.Rss, "rss" },
        { LanguageCode.Ruby, "ruby" },
        { LanguageCode.Rust, "rust" },
        { LanguageCode.Sas, "sas" }, 
        { LanguageCode.Sass, "sass" },
        { LanguageCode.Scss, "scss" },
        { LanguageCode.Scala, "scala" },
        { LanguageCode.Scheme, "scheme" },
        { LanguageCode.ShellSession, "shellsession" },
        { LanguageCode.Smali, "smali" },
        { LanguageCode.SmallTalk, "smalltalk" },
        { LanguageCode.Smarty, "smarty" },
        { LanguageCode.Sml, "sml" },
        { LanguageCode.SolidityEthereum, "solidity" },
        { LanguageCode.SolutionFile, "sln" },
        { LanguageCode.Soy, "soy" },
        { LanguageCode.SparQl, "rq" },
        { LanguageCode.Spl, "splunk-spl" },
        { LanguageCode.Sqf, "sqf" },
        { LanguageCode.Sql, "sql" },
        { LanguageCode.Squirrel, "squirrel" },
        { LanguageCode.Ssml, "ssml" },
        { LanguageCode.Stan, "stan" },
        { LanguageCode.Stata, "stata" },
        { LanguageCode.StructuredText, "iecst" },
        { LanguageCode.Stylus, "stylus" },
        { LanguageCode.SuperCollider, "sclang" },
        { LanguageCode.Swift, "swift" },
        { LanguageCode.SystemDConfigFile, "systemd" },
        { LanguageCode.TFourTemplating, "t4-templating" },
        { LanguageCode.TFourTextCSharp, "t4-cs" },
        { LanguageCode.TFourTextVisualBasic, "t4-vb" },
        { LanguageCode.Tap, "tap" },
        { LanguageCode.Tcl, "tcl" },
        { LanguageCode.TemplateToolkit, "tt2" },
        { LanguageCode.Textile, "textile" },
        { LanguageCode.Tremor, "tremor" },
        { LanguageCode.Turtle, "turtle" },
        { LanguageCode.Twig, "twig" },
        { LanguageCode.TypeScript, "typescript" },
        { LanguageCode.TypoScript, "typoscript" },
        { LanguageCode.UnrealScript, "unrealscript" },
        { LanguageCode.UoRazorScript, "uorazor" },
        { LanguageCode.Uri, "uri" },
        { LanguageCode.V, "v" },
        { LanguageCode.Vala, "vala" },
        { LanguageCode.VbNet, "vbnet" },
        { LanguageCode.Velocity, "velocity" },
        { LanguageCode.Vhdl, "vhdl" },
        { LanguageCode.Vim, "vim" },
        { LanguageCode.VisualBasic, "vb" },
        { LanguageCode.Warpscript, "warpscript" },
        { LanguageCode.WebAssembly, "wasm" },
        { LanguageCode.Wgsl, "wgsl" },
        { LanguageCode.WikiMarkup, "wiki" },
        { LanguageCode.WolframLanguage, "wolfram" },
        { LanguageCode.Wren, "wren" },
        { LanguageCode.Xeora, "xeora" },
        { LanguageCode.Xml, "xml" },
        { LanguageCode.XmlDoc, "xml-doc" },
        { LanguageCode.Xojo, "xojo" },
        { LanguageCode.Xquery, "xquery" },
        { LanguageCode.Yaml, "yaml" },
        { LanguageCode.Yang, "yang" },
        { LanguageCode.Zig, "zig" },
    };

    
}
