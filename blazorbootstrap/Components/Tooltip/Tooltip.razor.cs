﻿namespace BlazorBootstrap;

/// <summary>
/// Represents a tooltip that appears when the user hovers over an element that has the tooltip encased in it. <br/>
/// For more information, visit the <see href="https://getbootstrap.com/docs/5.0/components/tooltips/">Bootstrap Tooltips</see> documentation.
/// </summary>
public partial class Tooltip : BlazorBootstrapComponentBase
{
    #region Fields and Constants

    private BsColor color = default!;
    private bool isFirstRenderComplete = false;
    private DotNetObjectReference<Tooltip> objRef = default!;
    private string? title;

    #endregion

    #region Methods

    /// <inheritdoc />
    protected override async ValueTask DisposeAsyncCore(bool disposing)
    {
        if (disposing)
        {
            try
            {
                if (IsRenderComplete)
                    await JsRuntime.InvokeVoidAsync("window.blazorBootstrap.tooltip.dispose", Element);
            }
            catch (JSDisconnectedException)
            {
                // do nothing
            }

            objRef?.Dispose();
        }

        await base.DisposeAsyncCore(disposing);
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JsRuntime.InvokeVoidAsync("window.blazorBootstrap.tooltip.initialize", Element);

            isFirstRenderComplete = true;
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        objRef ??= DotNetObjectReference.Create(this);

        title = Title;

        color = Color;

        await base.OnInitializedAsync();
    }

    /// <inheritdoc />
    protected override async Task OnParametersSetAsync()
    {
        if (isFirstRenderComplete)
            if (title != Title || color != Color)
            {
                title = Title;
                color = Color;

                await JsRuntime.InvokeVoidAsync("window.blazorBootstrap.tooltip.dispose", Element);
                await JsRuntime.InvokeVoidAsync("window.blazorBootstrap.tooltip.update", Element);
            }
    }

    /// <summary>
    /// Invokes the javascript function to show the tooltip.
    /// </summary>
    /// <returns>The <see cref="ValueTask"/> associated with the Javascript invocation.</returns>
    public ValueTask ShowAsync()
    {
        return JsRuntime.InvokeVoidAsync("window.blazorBootstrap.tooltip.show", Element);
    }


    /// <summary>
    /// Parameters are loaded manually for sake of performance.
    /// <see href="https://learn.microsoft.com/en-us/aspnet/core/blazor/performance#implement-setparametersasync-manually"/>
    /// </summary> 
    public override Task SetParametersAsync(ParameterView parameters)
    {
        foreach (var parameter in parameters)
        {
            switch (parameter.Name)
            {
                case nameof(ChildContent): ChildContent = (RenderFragment)parameter.Value; break;
                case nameof(Class): Class = (string)parameter.Value; break;
                case nameof(Color): Color = (BsColor)parameter.Value; break;
                case nameof(Id): Id = (string)parameter.Value!; break;
                case nameof(IsHtml): IsHtml = (bool)parameter.Value; break;
                case nameof(Placement): Placement = (TooltipPlacement)parameter.Value; break;
                case nameof(Style): Style = (string)parameter.Value; break;
                case nameof(Title): Title = (string)parameter.Value; break;

                default:
                    AdditionalAttributes![parameter.Name] = parameter.Value;
                    break;
            }
        }

        return base.SetParametersAsync(ParameterView.Empty);
    }

    #endregion

    #region Properties, Indexers

    /// <summary>
    /// Gets or sets the content to be rendered within the component.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    /// <summary>
    /// Gets or sets the tooltip color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="BsColor.Transparent" />.
    /// </remarks>
    [Parameter]
    public BsColor Color { get; set; } = BsColor.Transparent;

    /// <summary>
    /// Gets or sets a value indicating whether to display the content as HTML instead of text.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool IsHtml { get; set; }

    /// <summary>
    /// Gets or sets the tooltip placement.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="TooltipPlacement.Top" />.
    /// </remarks>
    [Parameter]
    public TooltipPlacement Placement { get; set; } = TooltipPlacement.Top;

    /// <summary>
    /// Displays informative text when users hover, focus, or tap an element.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    [EditorRequired]
    public string Title { get; set; } = default!;

    #endregion
}
