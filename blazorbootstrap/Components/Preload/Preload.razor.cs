﻿namespace BlazorBootstrap;

/// <summary>
/// Indicate the loading state of a page with Blazor Bootstrap preload component.
/// </summary>
public partial class Preload : BlazorBootstrapComponentBase
{
    #region Fields and Constants

    private string? loadingText;

    private bool showBackdrop;

    private string? spinnerColor;

    #endregion

    #region Methods

    /// <inheritdoc />
    protected override async ValueTask DisposeAsyncCore(bool disposing)
    {
        if (disposing)
        {
            PageLoadingService.OnShow -= OnShow;
            PageLoadingService.OnHide -= OnHide;
        }

        await base.DisposeAsyncCore(disposing);
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        PageLoadingService.OnShow += OnShow;
        PageLoadingService.OnHide += OnHide;
    }

    private void OnHide()
    {
        showBackdrop = false;

        StateHasChanged();
    }

    private void OnShow(BsColor newSpinnerColor, string? newLoadingText)
    {
        this.spinnerColor = newSpinnerColor.ToTextColorClass();

        showBackdrop = true;

        this.loadingText = newLoadingText;

        StateHasChanged();
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
                case nameof(Class): Class = (string)parameter.Value!; break;
                case nameof(Id): Id = (string)parameter.Value!; break;
                case nameof(Style): Style = (string)parameter.Value!; break;
                case nameof(LoadingText): LoadingText = (string)parameter.Value; break;

                default:
                    AdditionalAttributes![parameter.Name] = parameter.Value;
                    break;
            }
        }

        return base.SetParametersAsync(ParameterView.Empty);
    }

    #endregion

    #region Properties, Indexers

    /// <inheritdoc />
    protected override string? ClassNames =>
        BuildClassNames(Class,
            (BootstrapClass.Modal, true),
            (BootstrapClass.PageLoadingModal, true),
            (BootstrapClass.ModalFade, true),
            (BootstrapClass.Show, showBackdrop));

    /// <inheritdoc />
    protected override string? StyleNames =>
        BuildStyleNames(Style,
            ("display:block", showBackdrop),
            ("display:none", !showBackdrop));

    /// <summary>
    /// Gets or sets the content to be rendered within the component.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the loading text.
    /// </summary>
    [Parameter]
    public string? LoadingText { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="PageLoadingService" /> instance.
    /// </summary>
    [Inject]
    private PreloadService PageLoadingService { get; set; } = default!;

    #endregion
}
