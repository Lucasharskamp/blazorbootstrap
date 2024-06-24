﻿namespace BlazorBootstrap.Demo.RCL;

public partial class Demo : ComponentBase
{
    #region Fields and Constants

    private BsColor clipboardTooltipIconColor = BsColor.Dark;

    private IconName clipboardTooltipIconName = IconName.Clipboard;

    private string? clipboardTooltipTitle = "Copy to clipboard";

    private string? snippet;

    /// <summary>
    /// A reference to this component instance for use in JavaScript calls.
    /// </summary>
    private DotNetObjectReference<Demo> objRef = default!;

    /// <summary>
    /// Can be used if the code snippet is provided directly, rather than from a .razor file
    /// </summary>
    [Parameter] public string? ProvidedCode { get; set; }

    #endregion

    #region Methods

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("highlightCode");

        await base.OnAfterRenderAsync(firstRender);
    }

    protected override async Task OnInitializedAsync()
    {
        objRef ??= DotNetObjectReference.Create(this);
        await base.OnInitializedAsync();
    }

    protected override async Task OnParametersSetAsync()
    {
        if (snippet is null)
        {
            if (ProvidedCode != null)
            {
                snippet = ProvidedCode;
            }
            else
            {
                var resourceName = Type.FullName + ".razor";

                using (var stream = Type.Assembly.GetManifestResourceStream(resourceName)!)
                {
                    try
                    {
                        if (stream is null)
                            return;

                        using (var reader = new StreamReader(stream))
                        {
                            snippet = await reader.ReadToEndAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Handles a copy error event from JavaScript.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    [JSInvokable]
    public void OnCopyFailJS(string errorMessage)
    {
        // TODO: show message
    }

    /// <summary>
    /// Handles a copy success event from JavaScript.
    /// </summary>
    [JSInvokable]
    public void OnCopySuccessJS()
    {
        clipboardTooltipTitle = "Copied!";
        clipboardTooltipIconName = IconName.Check2;
        clipboardTooltipIconColor = BsColor.Success;

        StateHasChanged();
    }

    /// <summary>
    /// Handles a copy status reset event from JavaScript.
    /// </summary>
    [JSInvokable]
    public void ResetCopyStatusJS()
    {
        clipboardTooltipTitle = "Copy to clipboard";
        clipboardTooltipIconName = IconName.Clipboard;
        clipboardTooltipIconColor = BsColor.Dark;

        StateHasChanged();
    }

    private ValueTask CopyToClipboardAsync() => JS.InvokeVoidAsync("copyToClipboard", snippet, objRef);

    #endregion

    #region Properties, Indexers

    [Inject] protected IJSRuntime JS { get; set; } = default!;

    [Parameter] public LanguageCode LanguageCode { get; set; } = LanguageCode.Razor;

    [Parameter] public bool ShowCodeOnly { get; set; }

    [Parameter] public bool Tabs { get; set; } = false;

    [Parameter] public Type Type { get; set; } = default!;

    #endregion
}
