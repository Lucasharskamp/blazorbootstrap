﻿namespace BlazorBootstrap;

/// <summary>
/// Represents a colored bar within a <see cref="Progress"/>. A <see cref="Progress"/> may contain multiple <see cref="ProgressBar"/> components.
/// </summary>
public partial class ProgressBar
{
    #region Methods

    /// <summary>
    /// Decrease the progress bar width.
    /// </summary>
    /// <param name="width"></param>
    public void DecreaseWidth(double width)
    {
        if (width is < 0 or > 100)
            return;

        if (Width - width < 0)
            Width = 0;
        else
            Width -= width;
    }

    /// <summary>
    /// Increase the progress bar width.
    /// </summary>
    /// <param name="width"></param>
    public void IncreaseWidth(double width)
    { 
        Width = Math.Clamp(Width + width, 0, 100);
    } 

    /// <summary>
    /// Set the progress bar width.
    /// </summary>
    /// <param name="width"></param>
    public void SetWidth(double width)
    { 
        Width = Math.Clamp(width, 0, 100);
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
                case nameof(Color): Color = (BsColor)parameter.Value; break;

                case nameof(Class): Class = (string)parameter.Value!; break;
                case nameof(Id): Id = (string)parameter.Value!; break;
                case nameof(Style): Style = (string)parameter.Value!; break;
                case nameof(Label): Label = (string)parameter.Value; break;
                case nameof(Type): Type = (ProgressType)parameter.Value; break;

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
            (BootstrapClass.ProgressBar, true),
            (BootstrapClass.ProgressBarStriped, Type is ProgressType.Striped or ProgressType.StripedAndAnimated),
            (BootstrapClass.ProgressBarAnimated, Type == ProgressType.StripedAndAnimated),
            (Color.ToBackgroundColorClass(), Color != BsColor.Transparent));

    /// <inheritdoc />
    protected override string? StyleNames =>
        BuildStyleNames(Style,
            // FIX: Toast progressbar not showing: https://github.com/vikramlearning/blazorbootstrap/issues/155
            ($"width:{Width.ToString(CultureInfo.InvariantCulture)}%", Width is >= 0 and <= 100));

    /*
     * StateHasChanged() needed to be invoked in .NET 6 to re-render a component when a property got altered.
     * In .NET 7 and later, this is no longer necessary, and having a set/get body is considered bad practice.
     * Hence, the following code are 3 simple properties in .NET 7 and later,
     * but for .NET 6, they are implemented with a set/get body and a private variable for the sake of StateHasChanged().
     */


#if NET6_0
    private BsColor color = BsColor.Transparent;

    /// <summary>
    /// Gets or sets the progress color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="BsColor.Transparent" />.
    /// </remarks>
    [Parameter]
    public BsColor Color
    {
        get => color;
        set
        {
            color = value;
            StateHasChanged();
        }
    }
#else
    /// <summary>
    /// Gets or sets the progress color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="BsColor.Transparent" />.
    /// </remarks>
    [Parameter]
    public BsColor Color { get; set; } = BsColor.Transparent;
#endif


    /// <summary>
    /// Gets or sets the progress bar label.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public string Label { get; set; } = default!;


#if NET6_0
    private ProgressType type = ProgressType.Default;
    /// <summary>
    /// Gets or sets the progress bar type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ProgressType.Default" />.
    /// </remarks>
    [Parameter]
    public ProgressType Type
    {
        get => type;
        set
        {
            type = value;
            StateHasChanged();
        }
    }
#else
    /// <summary>
    /// Gets or sets the progress bar type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ProgressType.Default" />.
    /// </remarks>
    [Parameter]
    public ProgressType Type { get; set; } 
#endif

#if NET6_0
    private double width = 0;

    /// <summary>
    /// Get or sets the progress bar width.
    /// </summary>
    /// <remarks>
    /// Default value is 0.
    /// </remarks>
    [Parameter]
    public double Width
    {
        get => width;
        set
        {
            width = value;
            StateHasChanged();
        }
    }
#else
    /// <summary>
    /// Get or sets the progress bar width.
    /// </summary>
    /// <remarks>
    /// Default value is 0.
    /// </remarks>
    [Parameter]
    public double Width { get; set; } 
#endif

    #endregion
}
