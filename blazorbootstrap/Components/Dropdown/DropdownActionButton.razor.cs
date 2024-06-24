﻿namespace BlazorBootstrap;

public partial class DropdownActionButton : BlazorBootstrapComponentBase
{
    #region Methods

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        if (!AdditionalAttributes.TryGetValue("type", out _))
            AdditionalAttributes.Add("type", "button");

        base.OnInitialized();
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
                case nameof(ChildContent): ChildContent = (RenderFragment)parameter.Value!; break;
                case nameof(Class): Class = (string)parameter.Value; break;
                case nameof(Color): Color = (BsColor)parameter.Value!; break;
                case nameof(Disabled): Disabled = (bool)parameter.Value!; break;
                case nameof(Id): Id = (string)parameter.Value!; break;
                case nameof(Size): Size = (DropdownSize)parameter.Value!; break;
                case nameof(Style): Style = (string)parameter.Value; break;
                case nameof(TabIndex): TabIndex = (int?)parameter.Value!; break;
                default: AdditionalAttributes[parameter.Name] = parameter.Value; break;
            }
        }
        
        return base.SetParametersAsync(ParameterView.Empty);
    }

    #endregion

    #region Properties, Indexers
    
    /// <inheritdoc />
    protected override string? ClassNames =>
        BuildClassNames(Class,
            (BootstrapClass.Button, true),
            (Color.ToButtonColorClass(), Color != BsColor.Transparent),
            (Size.ToDropdownButtonSizeClass(), Size != DropdownSize.None));

    /// <summary>
    /// Gets or sets the content to be rendered within the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    /// <summary>
    /// Gets or sets the dropdown action button color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="BsColor.Transparent" />.
    /// </remarks>
    [CascadingParameter(Name = "Color")]
    public BsColor Color { get; set; } = BsColor.Transparent;

    /// <summary>
    /// Gets or sets the disabled.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [CascadingParameter(Name = "Disabled")]
    public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets the dropdown action button size.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="DropdownSize.None" />.
    /// </remarks>
    [CascadingParameter(Name = "Size")]
    public DropdownSize Size { get; set; } = DropdownSize.None;

    /// <summary>
    /// Gets or sets the dropdown action button tab index.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public int? TabIndex { get; set; }

    #endregion
}
