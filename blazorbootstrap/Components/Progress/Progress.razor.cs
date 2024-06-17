﻿namespace BlazorBootstrap;

/// <summary>
/// Documentation and examples for using the Blazor Bootstrap progress component featuring support for stacked bars, animated backgrounds, and text labels. <br/>
/// For more information, visit the <see href="https://getbootstrap.com/docs/5.0/components/progress/">Bootstrap Progress</see> documentation.
/// </summary>
public partial class Progress : BlazorBootstrapComponentBase
{ 

    #region Methods
 
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
                case nameof(Height): Height = (double)parameter.Value; break;
                case nameof(Class): Class = (string)parameter.Value!; break;
                case nameof(Id): Id = (string)parameter.Value!; break;
                case nameof(Style): Style = (string)parameter.Value!; break;

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
        BuildClassNames(Class, (BootstrapClass.Progress, true));

    /// <inheritdoc />
    protected override string? StyleNames =>
        BuildStyleNames(Style, ($"height:{Height.ToString(CultureInfo.InvariantCulture)}px", Height >= 0));

    /// <summary>
    /// Gets or sets the content to be rendered within the component.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the height of the Progress. Height is measured in pixels.
    /// </summary>
    /// <remarks>
    /// Default value is 16.
    /// </remarks>
    [Parameter]
    public double Height { get; set; } = 16;

    #endregion
}
