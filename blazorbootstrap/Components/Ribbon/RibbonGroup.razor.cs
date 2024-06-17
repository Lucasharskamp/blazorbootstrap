﻿namespace BlazorBootstrap;

/// <summary>
/// Represents a group of <see cref="RibbonTab"/>'s within a <see cref="Ribbon"/> component.
/// </summary>
public partial class RibbonGroup : BlazorBootstrapComponentBase
{
    #region Properties, Indexers

    /// <inheritdoc />
    protected override string? ClassNames =>
        BuildClassNames(Class,
            ("bb-ribbon-group", true),
            (BootstrapClass.Flex, true),
            (BootstrapClass.FlexRow, true),
            (BootstrapClass.Border, true));

    /// <summary>
    /// Gets or sets the content to be rendered inside this component.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

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
                case nameof(ChildContent):  ChildContent = (RenderFragment)parameter.Value; break;
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
}
