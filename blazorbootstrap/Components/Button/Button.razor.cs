﻿namespace BlazorBootstrap;

/// <summary>
/// Use Blazor Bootstrap button styles for actions in forms, dialogs, and more with support for multiple sizes, states, etc. <br/>
/// This component is based on the <see href="https://getbootstrap.com/docs/5.0/components/buttons/">Bootstrap Button</see> component.
/// </summary>
public partial class Button : BlazorBootstrapComponentBase
{
    #region Fields and Constants

    private bool isFirstRenderComplete = false;

    private bool previousActive;

    private bool previousDisabled;

    private int? previousTabIndex;

    private Target previousTarget;

    private string? previousTo = default!;

    private BsColor previousTooltipColor = default!;

    private string previousTooltipTitle = default!;

    private ButtonType previousType;

    private bool setButtonAttributesAgain = false;

    #endregion

    #region Methods

    /// <inheritdoc />
    protected override async ValueTask DisposeAsyncCore(bool disposing)
    {
        if (disposing && !string.IsNullOrWhiteSpace(TooltipTitle) && IsRenderComplete)
            try
            {
                await JsRuntime.InvokeVoidAsync("window.blazorBootstrap.tooltip.dispose", Element);
            }
            catch (JSDisconnectedException)
            {
                // do nothing
            }

        await base.DisposeAsyncCore(disposing);
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            isFirstRenderComplete = true;

            if (!string.IsNullOrWhiteSpace(TooltipTitle))
                await JsRuntime.InvokeVoidAsync("window.blazorBootstrap.tooltip.initialize", Element);
        }

        await base.OnAfterRenderAsync(firstRender);
    }
     

    /// <inheritdoc />
    protected override async Task OnParametersSetAsync()
    {
        if (isFirstRenderComplete)
        {
            if (previousDisabled != Disabled)
            {
                previousDisabled = Disabled;
                setButtonAttributesAgain = true;
            }

            if (previousActive != Active)
            {
                previousActive = Active;
                setButtonAttributesAgain = true;
            }

            if (previousType != Type)
            {
                previousType = Type;
                setButtonAttributesAgain = true;
            }

            if (previousTarget != Target)
            {
                previousTarget = Target;
                setButtonAttributesAgain = true;
            }

            if (previousTabIndex != TabIndex)
            {
                previousTabIndex = TabIndex;
                setButtonAttributesAgain = true;
            }

            if (previousTo != To)
            {
                previousTo = To;
                setButtonAttributesAgain = true;
            }

            if (previousTooltipTitle != TooltipTitle || previousTooltipColor != TooltipColor) setButtonAttributesAgain = true;

            if (setButtonAttributesAgain)
            {
                setButtonAttributesAgain = false;
                SetAttributes();
            }

            // additional scenario
            // NOTE: do not change the below sequence
            if (Disabled)
            {
                await JsRuntime.InvokeVoidAsync("window.blazorBootstrap.tooltip.dispose", Element);
            }
            else if (previousTooltipTitle != TooltipTitle || previousTooltipColor != TooltipColor)
            {
                await JsRuntime.InvokeVoidAsync("window.blazorBootstrap.tooltip.dispose", Element);
                await JsRuntime.InvokeVoidAsync("window.blazorBootstrap.tooltip.update", Element);
            }

            previousTooltipTitle = TooltipTitle;
            previousTooltipColor = TooltipColor;
        }
    }

    /// <summary>
    /// Hides the loading state and enables the button.
    /// </summary>
    public void HideLoading()
    {
        Loading = false;
        Disabled = false;
#if NET6_0
        StateHasChanged();
        #endif
    }

    /// <summary>
    /// Shows the loading state and disables the button.
    /// </summary>
    /// <param name="text"></param>
    public void ShowLoading(string text = "")
    {
        LoadingText = text;
        Loading = true;
        Disabled = true;
#if NET6_0
        StateHasChanged();
#endif
    }

    /// <summary>
    /// Default <see cref="LoadingTemplate"/> for a button in case the user does not provide one.
    /// </summary>
    /// <returns>The default loading template</returns>
    protected virtual RenderFragment ProvideDefaultLoadingTemplate() => builder =>
    {
        builder.AddMarkupContent(0, $"<span class=\"spinner-border spinner-border-{(Size == ButtonSize.None ? ButtonSize.Medium : Size).ToButtonSpinnerSizeClass()}\" role=\"status\" aria-hidden=\"true\"></span> {LoadingText}");
    };

    private void SetAttributes()
    {
        if (Active && !AdditionalAttributes.TryGetValue("aria-pressed", out _))
            AdditionalAttributes.Add("aria-pressed", "true");
        else if (!Active)
            AdditionalAttributes.Remove("aria-pressed");

        // 'a' tag
        if (Type == ButtonType.Link)
        {
            if (!AdditionalAttributes.TryGetValue("role", out _))
                AdditionalAttributes.Add("role", "button");

            // To can be changed when the Button is used within a Virtualize component
            if (!AdditionalAttributes.TryGetValue("href", out _))
                AdditionalAttributes.Add("href", To!);
            else
                AdditionalAttributes["href"] = To!;

            if (Target != Target.None)
                if (!AdditionalAttributes.TryGetValue("target", out _))
                    AdditionalAttributes.Add("target", Target.ToTargetString()!);
                else
                    AdditionalAttributes["target"] = Target.ToTargetString()!;

            if (Disabled)
            {
                AdditionalAttributes["aria-disabled"] = "true";
                AdditionalAttributes["tabindex"] = -1;
            }
            else
            {
                AdditionalAttributes.Remove("aria-disabled");

                if (TabIndex is not null && !AdditionalAttributes.TryGetValue("tabindex", out _))
                    AdditionalAttributes.Add("tabindex", TabIndex);
                else if (TabIndex is null)
                    AdditionalAttributes.Remove("tabindex");
            }
        }
        else // button, submit
        {
            AdditionalAttributes.Remove("role");
            AdditionalAttributes.Remove("href");
            AdditionalAttributes.Remove("target");
            AdditionalAttributes.Remove("aria-disabled");

            if (TabIndex is not null && !AdditionalAttributes.TryGetValue("tabindex", out _))
                AdditionalAttributes.Add("tabindex", TabIndex);
            else if (TabIndex is null)
                AdditionalAttributes.Remove("tabindex");
        }

        // button enabled (and) tooltip text not empty
        if (!Disabled && !string.IsNullOrWhiteSpace(TooltipTitle))
        {
            // Ref: https://getbootstrap.com/docs/5.2/components/buttons/#toggle-states
            // The below code creates an issue when the `button` or `a` element has a tooltip.

            if (!AdditionalAttributes.TryGetValue("data-bs-placement", out _))
                AdditionalAttributes.Add("data-bs-placement", TooltipPlacement.ToTooltipPlacementName());

            AdditionalAttributes["title"] = TooltipTitle;

            AdditionalAttributes["data-bs-custom-class"] = TooltipColor.ToTooltipColorClass()!;
        }
        // button disabled (or) tooltip text empty
        else
        {
            AdditionalAttributes.Remove("data-bs-toggle");
            AdditionalAttributes.Remove("data-bs-placement");
            AdditionalAttributes.Remove("title");
            AdditionalAttributes.Remove("data-bs-custom-class", out _);
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
                case nameof(Active): Active = (bool)parameter.Value; break;
                case nameof(Block): Block = (bool)parameter.Value; break;
                case nameof(ChildContent): ChildContent = (RenderFragment)parameter.Value; break;
                case nameof(Class): Class = (string)parameter.Value; break;
                case nameof(Color): Color = (BsColor)parameter.Value; break;
                case nameof(Disabled): Disabled = (bool)parameter.Value; break;
                case nameof(Id): Id = (string)parameter.Value; break;
                case nameof(Loading): Loading = (bool)parameter.Value; break;
                case nameof(LoadingTemplate): LoadingTemplate = (RenderFragment?)parameter.Value; break;
                case nameof(LoadingText): LoadingText = (string)parameter.Value; break;
                case nameof(Outline): Outline = (bool)parameter.Value; break;
                case nameof(Position): Position = (Position)parameter.Value; break;
                case nameof(Size): Size = (ButtonSize)parameter.Value; break;
                case nameof(Style): Style = (string)parameter.Value; break;
                case nameof(TabIndex): TabIndex = (int?)parameter.Value; break;
                case nameof(Target): Target = (Target)parameter.Value; break;
                case nameof(To): To = (string?)parameter.Value; break;
                case nameof(TooltipColor): TooltipColor = (BsColor)parameter.Value; break;
                case nameof(TooltipPlacement): TooltipPlacement = (TooltipPlacement)parameter.Value; break;
                case nameof(TooltipTitle): TooltipTitle = (string)parameter.Value; break;
                case nameof(Type): 
                    Type = (ButtonType)parameter.Value;
                    ButtonTypeString = Type.ToButtonTypeString();
                    break;
                default:
                    AdditionalAttributes![parameter.Name] = parameter.Value;
                    break;
            }
        }

        previousDisabled = Disabled;
        previousActive = Active;
        previousType = Type;
        previousTarget = Target;
        previousTabIndex = TabIndex;
        previousTo = To;
        previousTooltipTitle = TooltipTitle;
        previousTooltipColor = TooltipColor;

        LoadingTemplate ??= ProvideDefaultLoadingTemplate();
        
        SetAttributes();
        
        return base.SetParametersAsync(ParameterView.Empty);
    }

    #endregion

    #region Properties, Indexers

    /// <inheritdoc />
    protected override string? ClassNames =>
        BuildClassNames(Class,
            (BootstrapClass.Button, true),
            (Color.ToBackgroundColorClass(), Color != BsColor.Transparent && !Outline),
            (Color.ToButtonOutlineColorClass(), Color != BsColor.Transparent && Outline),
            (Size.ToButtonSizeClass(), Size != ButtonSize.None),
            (BootstrapClass.ButtonDisabled, Disabled && Type == ButtonType.Link),
            (BootstrapClass.ButtonActive, Active),
            (BootstrapClass.ButtonBlock, Block),
            (BootstrapClass.ButtonLoading!, Loading && LoadingTemplate is not null),
            (Position.ToPositionClass(), Position != Position.None));

    /// <summary>
    /// Gets or sets the button active state.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool Active { get; set; }

    /// <summary>
    /// Gets or sets the block level button.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool Block { get; set; }

    private string ButtonTypeString { get; set; } = "";

    /// <summary>
    /// Gets or sets the content to be rendered within the component.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    /// <summary>
    /// Gets or sets the button color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="BsColor.Transparent" />.
    /// </remarks>
    [Parameter]
    public BsColor Color { get; set; } = BsColor.Transparent;

    /// <summary>
    /// Gets or sets the button disabled state.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// If <see langword="true" />, shows the loading spinner or a <see cref="LoadingTemplate" />.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool Loading { get; set; }

    /// <summary>
    /// Gets or sets the button loading template.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? LoadingTemplate { get; set; } = default!;

    /// <summary>
    /// Gets or sets the loading text.
    /// <see cref="LoadingTemplate" /> takes precedence.
    /// </summary>
    /// <remarks>
    /// Default value is 'Loading...'.
    /// </remarks>
    [Parameter]
    public string LoadingText { get; set; } = "Loading...";
    
    /// <summary>
    /// Gets or sets the button outline.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool Outline { get; set; }

    /// <summary>
    /// Gets or sets the position.
    /// Use <see cref="Position" /> to modify a <see cref="Badge" /> and position it in the corner of a link or button.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Position.None" />.
    /// </remarks>
    [Parameter]
    public Position Position { get; set; } = Position.None;

    /// <summary>
    /// Gets or sets the button size.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ButtonSize.None" />.
    /// </remarks>
    [Parameter]
    public ButtonSize Size { get; set; } = ButtonSize.None;

    /// <summary>
    /// Gets or sets the button tab index.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public int? TabIndex { get; set; }

    /// <summary>
    /// Gets or sets the link button target.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Target.None" />
    /// </remarks>
    [Parameter]
    public Target Target { get; set; } = Target.None;

    /// <summary>
    /// Gets or sets the link button href attribute.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public string? To { get; set; }

    /// <summary>
    /// Gets or sets the button tooltip color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="BsColor.Transparent" />.
    /// </remarks>
    [Parameter]
    public BsColor TooltipColor { get; set; } = BsColor.Transparent;

    /// <summary>
    /// Gets or sets the button tooltip placement.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="TooltipPlacement.Top" />.
    /// </remarks>
    [Parameter]
    public TooltipPlacement TooltipPlacement { get; set; } = TooltipPlacement.Top;

    /// <summary>
    /// Gets or sets the button tooltip title.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public string TooltipTitle { get; set; } = default!;

    /// <summary>
    /// Gets or sets the button type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ButtonType.Button" />.
    /// </remarks>
    [Parameter]
    public ButtonType Type { get; set; } = ButtonType.Button;

    #endregion

    // TODO: Review
    // - Disable text wrapping: https://getbootstrap.com/docs/5.1/components/buttons/#disable-text-wrapping
}
