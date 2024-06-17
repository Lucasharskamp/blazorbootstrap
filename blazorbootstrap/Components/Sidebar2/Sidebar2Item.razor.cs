﻿namespace BlazorBootstrap;

/// <summary>
/// Represents a sidebar item within a <see cref="Sidebar2"/> component, or those within a <see cref="Sidebar2ItemGroup"/> component.
/// </summary>
public partial class Sidebar2Item : BlazorBootstrapComponentBase
{
    #region Methods

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        if (NavLinkExtensions.ShouldExpand(NavigationManager, ChildItems!, Match))
            NavItemGroupExpanded = true;

        base.OnInitialized();
    }

    private void AutoHideNavMenu()
    {
        Root.HideNavMenuOnMobile();
    }

    private string GetNavLinkStyle()
    {
        // Implementation:
        // Level 0 = 1rem    = 0 + 1 + (0 * 0.5)
        // Level 1 = 2.5rem  = 1 + 1 + (1 * 0.5)
        // Level 2 = 4rem    = 2 + 1 + (2 * 0.5)
        // ...
        // Level n = .....   = n + 1 + (n * 0.5)

        var level = Level + 1 + Level * 0.5;

        if (HasChildren && !NavItemGroupExpanded)
            level += 0.25;
        else if (!HasChildren && Level == 0)
            level += 0.25;

        return $"padding-left:{level}rem;";
    }

    private void ToggleNavItemGroup() => NavItemGroupExpanded = !NavItemGroupExpanded;


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
                case nameof(ChildItems): ChildItems = (IReadOnlyCollection<NavItem>)parameter.Value; break;
                case nameof(Class): Class = (string)parameter.Value; break;
                case nameof(CollapseSidebar): CollapseSidebar = (bool)parameter.Value; break;
                case nameof(CustomIconName): CustomIconName = (string)parameter.Value; break;
                case nameof(HasChildren): HasChildren = (bool)parameter.Value; break;
                case nameof(Href): Href = (string)parameter.Value; break;
                case nameof(IconName): IconName = (IconName)parameter.Value; break;
                case nameof(Id): Id = (string)parameter.Value!; break;
                case nameof(Level): Level = (int)parameter.Value; break;
                case nameof(Match): Match = (NavLinkMatch)parameter.Value; break;
                case nameof(NavItemGroupExpanded): NavItemGroupExpanded = (bool)parameter.Value; break;
                case nameof(OnNavItemGroupExpanded): OnNavItemGroupExpanded = (Action<bool>)parameter.Value; break;
                case nameof(Root): Root = (Sidebar2)parameter.Value!; break;
                case nameof(Style): Style = (string)parameter.Value; break;
                case nameof(Target): Target = (Target)parameter.Value; break;
                case nameof(Text): Text = (string)parameter.Value; break;

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
            ("nav-item", true),
            ($"nav-item-level-{Level}", true),
            ("nav-item-group", HasChildren),
            ("active", NavItemGroupExpanded));

    /// <summary>
    /// Gets or sets the child items.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public IReadOnlyCollection<NavItem>? ChildItems { get; set; }

    [CascadingParameter] public bool CollapseSidebar { get; set; }

    /// <summary>
    /// Gets or sets the custom icon name.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public string? CustomIconName { get; set; }

    /// <summary>
    /// Gets or sets the has child items state.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool HasChildren { get; set; }

    /// <summary>
    /// Gets or sets the link href attribute.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public string? Href { get; set; }

    /// <summary>
    /// Gets or sets the icon color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="IconColor.None" />.
    /// </remarks>
    [Parameter]
    public IconColor IconColor { get; set; }

    private string IconColorCssClass => IconColor.ToIconColorClass();

    /// <summary>
    /// Gets or sets the icon name.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="IconName.None" />.
    /// </remarks>
    [Parameter]
    public IconName IconName { get; set; }

    /// <summary>
    /// Gets or sets the nested level.
    /// </summary>
    /// <remarks>
    /// Default value is 0.
    /// </remarks>
    [Parameter]
    public int Level { get; set; } = 0;

    /// <summary>
    /// Gets or sets a value representing the URL matching behavior.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="NavLinkMatch.Prefix" />.
    /// </remarks>
    [Parameter]
    public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;

    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    [Parameter] public bool NavItemGroupExpanded { get; set; } = false;

    /// <summary>
    /// Get nav link style.
    /// </summary>
    private string NavLinkStyle => GetNavLinkStyle();

    [Parameter] public Action<bool> OnNavItemGroupExpanded { get; set; } = default!;

    /// <summary>
    /// Gets or sets the root.
    /// </summary>
    [CascadingParameter]
    public Sidebar2 Root { get; set; } = default!;

    /// <summary>
    /// Gets or sets the link target.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Target.None" />.
    /// </remarks>
    [Parameter]
    public Target Target { get; set; } = Target.None;

    private string TargetString => Target.ToTargetString()!;

    /// <summary>
    /// Gets or sets the sidebar item text.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public string? Text { get; set; }

    #endregion
}
