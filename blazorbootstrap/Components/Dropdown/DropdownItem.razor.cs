﻿namespace BlazorBootstrap;

public partial class DropdownItem : BlazorBootstrapComponentBase
{
    #region Fields and Constants

    private bool isFirstRenderComplete = false;

    private bool previousActive;

    private bool previousDisabled;

    private int? previousTabIndex;

    private Target previousTarget;

    private DropdownItemType previousType;

    private bool setButtonAttributesAgain = false;

    #endregion

    #region Methods

    /// <inheritdoc />
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
            isFirstRenderComplete = true;

        base.OnAfterRender(firstRender);
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        previousActive = Active;
        previousDisabled = Disabled;
        previousTabIndex = TabIndex;
        previousTarget = Target;
        previousType = Type;

        SetAttributes();

        base.OnInitialized();
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        if (isFirstRenderComplete)
        {
            if (previousActive != Active)
            {
                previousActive = Active;
                setButtonAttributesAgain = true;
            }

            if (previousDisabled != Disabled)
            {
                previousDisabled = Disabled;
                setButtonAttributesAgain = true;
            }

            if (previousTabIndex != TabIndex)
            {
                previousTabIndex = TabIndex;
                setButtonAttributesAgain = true;
            }

            if (previousTarget != Target)
            {
                previousTarget = Target;
                setButtonAttributesAgain = true;
            }

            if (previousType != Type)
            {
                previousType = Type;
                setButtonAttributesAgain = true;
            }

            if (setButtonAttributesAgain)
            {
                setButtonAttributesAgain = false;
                SetAttributes();
            }
        }
    }

    private void SetAttributes()
    { 
        if (Active && !AdditionalAttributes!.TryGetValue("aria-current", out _))
            AdditionalAttributes.Add("aria-current", "true");
        else if (!Active)
            AdditionalAttributes!.Remove("aria-current");

        // 'a' tag
        if (Type == DropdownItemType.Link)
        {
            if (!AdditionalAttributes!.TryGetValue("role", out _))
                AdditionalAttributes.Add("role", "button");

            if (!AdditionalAttributes.TryGetValue("href", out _))
                AdditionalAttributes.Add("href", To!);

            if (Target != Target.None)
                if (!AdditionalAttributes.TryGetValue("target", out _))
                    AdditionalAttributes.Add("target", Target.ToTargetString()!);

            if (Disabled)
            {
                if (AdditionalAttributes.TryGetValue("aria-disabled", out _))
                    AdditionalAttributes["aria-disabled"] = "true";
                else
                    AdditionalAttributes.Add("aria-disabled", "true");

                if (AdditionalAttributes.TryGetValue("tabindex", out _))
                    AdditionalAttributes["tabindex"] = -1;
                else
                    AdditionalAttributes.Add("tabindex", -1);
            }
            else
            {
                AdditionalAttributes.Remove("aria-disabled", out _);

                if (TabIndex is not null && !AdditionalAttributes.TryGetValue("tabindex", out _))
                    AdditionalAttributes.Add("tabindex", TabIndex);
                else if (TabIndex is null)
                    AdditionalAttributes.Remove("tabindex");
            }
        }
        else // button
        {
            AdditionalAttributes!.Remove("role", out _);
            AdditionalAttributes.Remove("href", out _);
            AdditionalAttributes.Remove("target", out _);
            AdditionalAttributes.Remove("aria-disabled", out _);

            if (TabIndex is not null && !AdditionalAttributes.TryGetValue("tabindex", out _))
                AdditionalAttributes.Add("tabindex", TabIndex);
            else if (TabIndex is null)
                AdditionalAttributes.Remove("tabindex");
        }
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
                case nameof(Active): Active = (bool)parameter.Value!; break;
                case nameof(ChildContent): ChildContent = (RenderFragment)parameter.Value!; break;
                case nameof(Class): Class = (string)parameter.Value!; break;
                case nameof(Disabled): Disabled = (bool)parameter.Value!; break;
                case nameof(Id): Id = (string)parameter.Value!; break;
                case nameof(Style): Style = (string)parameter.Value!; break;
                case nameof(TabIndex): TabIndex = (int?)parameter.Value!; break;
                case nameof(Target): Target = (Target)parameter.Value!; break;
                case nameof(To): To = (string?)parameter.Value!; break;
                case nameof(Type): Type = (DropdownItemType)parameter.Value!; break;
                default: AdditionalAttributes![parameter.Name] = parameter.Value!; break;
            }
        }
        // SetAttributes() is handled in OnParametersSet()

        return base.SetParametersAsync(ParameterView.Empty);
    }

    #endregion

    #region Properties, Indexers
    
    /// <inheritdoc />
    protected override string? ClassNames =>
        BuildClassNames(Class,
            (BootstrapClass.DropdownItem, true),
            (BootstrapClass.Active, Active),
            (BootstrapClass.Disabled, Disabled));

    /// <summary>
    /// Gets or sets the dropdown item active state.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool Active { get; set; }

    /// <summary>
    /// Gets or sets the content to be rendered within the component.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    /// <summary>
    /// If <see langword="true" />, dropdown item will be disabled.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets the dropdown item tab index.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public int? TabIndex { get; set; }

    /// <summary>
    /// Gets or sets the target of dropdown item (if <see cref="Type"/> is <see cref="DropdownItemType.Link"/>).
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Target.None" />.
    /// </remarks>
    [Parameter]
    public Target Target { get; set; } = Target.None;

    /// <summary>
    /// Get or sets the link href attribute (if <see cref="Type"/> is <see cref="DropdownItemType.Link"/>).
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public string? To { get; set; }

    /// <summary>
    /// Gets or sets the dropdown item type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="DropdownItemType.Button" />.
    /// </remarks>
    [Parameter]
    public DropdownItemType Type { get; set; } = DropdownItemType.Button;

    #endregion
}
