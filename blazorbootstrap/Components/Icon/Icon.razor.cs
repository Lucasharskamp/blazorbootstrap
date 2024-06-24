﻿namespace BlazorBootstrap;

/// <summary>
/// Blazor Bootstrap icon component will display an icon from any icon font. <br/>
/// Use the parameter <see cref="Name"/> to specify the Bootstrap icon name. The values from <see cref="IconName"/>
/// are derived from the <see href="https://icons.getbootstrap.com/">official Bootstrap icons set.</see> <br/>
/// Alternatively, one may set the <see cref="CustomIconName"/> parameter to specify custom icons of your own, like the ones from `fontawesome`. <br/>
/// </summary>
public partial class Icon : BlazorBootstrapComponentBase
{
    #region Properties, Indexers

    /// <inheritdoc />
    protected override string? ClassNames =>
        BuildClassNames(Class,
            (BootstrapIconUtility.Icon(), string.IsNullOrWhiteSpace(CustomIconName)),
            (BootstrapIconUtility.Icon(Name), string.IsNullOrWhiteSpace(CustomIconName)),
            (CustomIconName!, !string.IsNullOrWhiteSpace(CustomIconName)),
            (BootstrapIconUtility.IconSize(Size)!, Size != IconSize.None),
            (Color.ToTextColorClass(), Color != BsColor.Transparent));

    /// <summary>
    /// Gets or sets the icon color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="BsColor.Transparent" />.
    /// </remarks>
    [Parameter]
    public BsColor Color { get; set; } = BsColor.Transparent;

    /// <summary>
    /// Gets or sets the custom icon name.
    /// Specify custom icons of your own, like `fontawesome`. Example: `fas fa-alarm-clock`.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public string? CustomIconName { get; set; }

    /// <summary>
    /// Gets or sets the icon name.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="IconName.None" />.
    /// </remarks>
    [Parameter]
    public IconName Name { get; set; } = IconName.None;

    /// <summary>
    /// Gets or sets the icon size.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="IconSize.None" />.
    /// </remarks>
    [Parameter]
    public IconSize Size { get; set; } = IconSize.None;

    #endregion

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
                case nameof(Class): Class = (string)parameter.Value!; break;
                case nameof(Color): Color = (BsColor)parameter.Value; break;
                case nameof(CustomIconName): CustomIconName = (string)parameter.Value; break;
                case nameof(Id): Id = (string)parameter.Value!; break;
                case nameof(Name): Name = (IconName)parameter.Value; break;
                case nameof(Size): Size = (IconSize)parameter.Value; break;
                case nameof(Style): Style = (string)parameter.Value!; break;

                default:
                    AdditionalAttributes![parameter.Name] = parameter.Value;
                    break;
            }
        }

        return base.SetParametersAsync(ParameterView.Empty);
    }
    
    #endregion
}
