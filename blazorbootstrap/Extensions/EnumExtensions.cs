namespace BlazorBootstrap;

/// <summary>
/// Enum extensions
/// Pattern matching: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
/// Discard pattern: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#discard-pattern
/// </summary>
public static class EnumExtensions
{
    #region Methods

    /// <summary>
    /// Turns the <see cref="BsColor"/> into an HTML Bootstrap alert color class name.
    /// </summary>
    /// <param name="alertColor">Alert Color to convert</param>
    /// <returns>CSS class name for use in HTML elements.</returns>
    public static string ToAlertColorClass(this BsColor alertColor) =>
        alertColor switch
        {
            BsColor.Primary => "alert-primary",
            BsColor.Secondary => "alert-secondary",
            BsColor.Success => "alert-success",
            BsColor.Danger => "alert-danger",
            BsColor.Warning => "alert-warning",
            BsColor.Info => "alert-info",
            BsColor.Light => "alert-light",
            BsColor.Dark => "alert-dark",
            _ => ""
        };

    /// <summary>
    /// Turns the <see cref="AutoCompleteSize"/> into an HTML Bootstrap CSS class name.
    /// </summary>
    /// <param name="autoCompleteSize">Auto complete size to convert</param>
    /// <returns>CSS class name for use in HTML elements.</returns>
    public static string ToAutoCompleteSizeClass(this AutoCompleteSize autoCompleteSize) =>
        autoCompleteSize switch
        {
            AutoCompleteSize.Large => "form-control-lg",
            AutoCompleteSize.Small => "form-control-sm",
            _ => ""
        };

    /// <summary>
    /// Converts the <see cref="BsColor"/> of <paramref name="backgroundColor"/> into an HTML Bootstrap CSS class name with text colors for those backgrounds.
    /// </summary>
    /// <param name="backgroundColor">Background color to convert, and assigns text colors for those backgrounds as well.</param>
    /// <returns>CSS class name for use in HTML elements.</returns>
    public static string ToBackgroundAndTextClass(this BsColor backgroundColor) =>
        backgroundColor switch
        {
            BsColor.Primary => "bg-primary text-white",
            BsColor.Secondary => "bg-secondary text-white",
            BsColor.Success => "bg-success text-white",
            BsColor.Danger => "bg-danger text-white",
            BsColor.Warning => "bg-warning text-dark",
            BsColor.Info => "bg-info text-dark",
            BsColor.Light => "bg-light text-dark",
            BsColor.Dark => "bg-dark text-white",
            BsColor.Body => "bg-body text-dark",
            BsColor.White => "bg-white text-dark",
            BsColor.Transparent => "bg-transparent text-dark",
            _ => ""
        };

    public static string ToBackgroundColorClass(this BsColor backgroundColor) =>
        backgroundColor switch
        {
            BsColor.Primary => "bg-primary",
            BsColor.Secondary => "bg-secondary",
            BsColor.Success => "bg-success",
            BsColor.Danger => "bg-danger",
            BsColor.Warning => "bg-warning",
            BsColor.Info => "bg-info",
            BsColor.Light => "bg-light",
            BsColor.Dark => "bg-dark",
            BsColor.Body => "bg-body",
            BsColor.White => "bg-white",
            BsColor.Transparent => "bg-transparent",
            _ => ""
        };

    public static string ToTextColorClass(this BsColor badgeColor) =>
        badgeColor switch
        {
            BsColor.Primary => "text-bg-primary",
            BsColor.Secondary => "text-bg-secondary",
            BsColor.Success => "text-bg-success",
            BsColor.Danger => "text-bg-danger",
            BsColor.Warning => "text-bg-warning",
            BsColor.Info => "text-bg-info",
            BsColor.Light => "text-bg-light",
            BsColor.Dark => "text-bg-dark",
            BsColor.Body => "text-bg-body",
            BsColor.Black => "text-bg-black",
            BsColor.White => "text-bg-white",
            BsColor.Transparent => "text-bg-transparent",
            _ => ""
        };

    public static string ToBadgeIndicatorClass(this BadgeIndicatorType badgeIndicatorType) =>
        badgeIndicatorType switch
        {
            BadgeIndicatorType.RoundedPill => "rounded-pill",
            BadgeIndicatorType.RoundedCircle => "rounded-circle",
            _ => "" // default: Top right
        };

    public static string ToBadgePlacementClass(this BadgePlacement badgePlacement) =>
        badgePlacement switch
        {
            BadgePlacement.TopLeft => "top-0 start-0 translate-middle",
            BadgePlacement.TopCenter => "top-0 start-50 translate-middle",
            BadgePlacement.TopRight => "top-0 start-100 translate-middle",
            BadgePlacement.MiddleLeft => "top-50 start-0 translate-middle",
            BadgePlacement.MiddleCenter => "top-50 start-50 translate-middle",
            BadgePlacement.MiddleRight => "top-50 start-100 translate-middle",
            BadgePlacement.BottomLeft => "top-100 start-0 translate-middle",
            BadgePlacement.BottomCenter => "top-100 start-50 translate-middle",
            BadgePlacement.BottomRight => "top-100 start-100 translate-middle",
            _ => "top-0 start-100 translate-middle" // default: Top right
        };

    /// <summary>
    /// Returns the Bootstrap CSS Class for a specific button color.
    /// </summary>
    /// <param name="bsColor">Button color to retrieve the class from</param>
    /// <returns>Button color</returns>
    public static string ToButtonColorClass(this BsColor bsColor) =>
        bsColor switch
        {
            BsColor.Primary => "btn-primary",
            BsColor.Secondary => "btn-secondary",
            BsColor.Success => "btn-success",
            BsColor.Danger => "btn-danger",
            BsColor.Warning => "btn-warning",
            BsColor.Info => "btn-info",
            BsColor.Light => "btn-light",
            BsColor.Dark => "btn-dark",
            BsColor.Link => "btn-link",
            _ => ""
        };

    public static string ToDropdownBsColorClass(this BsColor BsColor) =>
        BsColor switch
        {
            BsColor.Primary => "btn-primary",
            BsColor.Secondary => "btn-secondary",
            BsColor.Success => "btn-success",
            BsColor.Danger => "btn-danger",
            BsColor.Warning => "btn-warning",
            BsColor.Info => "btn-info",
            BsColor.Light => "btn-light",
            BsColor.Dark => "btn-dark",
            BsColor.Link => "btn-link",
            _ => ""
        };

    public static string ToButtonOutlineColorClass(this BsColor BsColor) =>
        BsColor switch
        {
            BsColor.Primary => "btn-outline-primary",
            BsColor.Secondary => "btn-outline-secondary",
            BsColor.Success => "btn-outline-success",
            BsColor.Danger => "btn-outline-danger",
            BsColor.Warning => "btn-outline-warning",
            BsColor.Info => "btn-outline-info",
            BsColor.Light => "btn-outline-light",
            BsColor.Dark => "btn-outline-dark",
            BsColor.Link => "btn-outline-link",
            _ => ""
        };

    public static string ToButtonSizeClass(this ButtonSize buttonSize) =>
        buttonSize switch
        {
            ButtonSize.ExtraSmall => "btn-xs",
            ButtonSize.Small => "btn-sm",
            ButtonSize.Medium => "btn-md",
            ButtonSize.Large => "btn-lg",
            ButtonSize.ExtraLarge => "btn-xl",
            _ => ""
        };

    public static string ToButtonSpinnerSizeClass(this ButtonSize buttonSize) =>
        buttonSize switch
        {
            ButtonSize.ExtraSmall => "xs",
            ButtonSize.Small => "sm",
            ButtonSize.Medium => "md",
            ButtonSize.Large => "lg",
            ButtonSize.ExtraLarge => "xl",
            _ => ""
        };

    public static string ToButtonTypeString(this ButtonType buttonType) =>
        buttonType switch
        {
            ButtonType.Button => "button",
            ButtonType.Submit => "submit",
            ButtonType.Reset => "reset",
            _ => ""
        };

    public static string ToCalloutColorClass(this BsColor bsColor) =>
        bsColor switch
        {
            BsColor.Default => "",
            BsColor.Danger => $"bb-callout-danger",
            BsColor.Warning => $"bb-callout-warning",
            BsColor.Info => $"bb-callout-info",
            BsColor.Success => $"bb-callout-success",
            BsColor.Primary => $"bb-callout-primary",
            BsColor.Secondary => $"bb-callout-secondary",
            BsColor.Light => $"bb-callout-light",
            BsColor.Dark => $"bb-callout-dark",
            _ => ""
        };

    public static string ToCssString(this Unit unit) =>
        unit switch
        {
            Unit.Em => "em",
            Unit.Percentage => "%",
            Unit.Pt => "pt",
            Unit.Px => "px",
            Unit.Rem => "rem",
            Unit.Vh => "vh",
            Unit.VMax => "vmax",
            Unit.VMin => "vmin",
            Unit.Vw => "vw",
            _ => string.Empty
        };

    public static string ToDialogSizeClass(this DialogSize dialogSize) =>
        dialogSize switch
        {
            DialogSize.Regular => "",
            DialogSize.Small => "modal-sm",
            DialogSize.Large => "modal-lg",
            DialogSize.ExtraLarge => "modal-xl",
            _ => ""
        };

    public static string ToDropdownDirectionClass(this DropdownDirection dropdownDirection) =>
        dropdownDirection switch
        {
            DropdownDirection.Dropdown => "dropdown",
            DropdownDirection.DropdownCentered => "dropdown dropdown-center",
            DropdownDirection.DropEnd => "dropend",
            DropdownDirection.DropUp => "dropup",
            DropdownDirection.DropUpCentered => "dropup dropup-center",
            DropdownDirection.DropStart => "dropstart",
            _ => ""
        };

    public static string ToDropdownMenuPositionClass(this DropdownMenuPosition dropdownMenuPosition) =>
        dropdownMenuPosition switch
        {
            DropdownMenuPosition.Start => "dropdown-menu-start",
            DropdownMenuPosition.End => "dropdown-menu-end",
            _ => ""
        };

    public static string ToDropdownButtonSizeClass(this DropdownSize dropdownSize) =>
        dropdownSize switch
        {
            DropdownSize.Small => "btn-sm",
            DropdownSize.Large => "btn-lg",
            _ => ""
        };
    

    public static string ToModalFullscreenClass(this ModalFullscreen modalFullscreen) =>
        modalFullscreen switch
        {
            ModalFullscreen.Disabled => "",
            ModalFullscreen.Always => "modal-fullscreen",
            ModalFullscreen.SmallDown => "modal-fullscreen-sm-down",
            ModalFullscreen.MediumDown => "modal-fullscreen-md-down",
            ModalFullscreen.LargeDown => "modal-fullscreen-lg-down",
            ModalFullscreen.ExtraLargeDown => "modal-fullscreen-xl-down",
            ModalFullscreen.ExtraExtraLargeDown => "modal-fullscreen-xxl-down",
            _ => ""
        };

    public static string ToModalHeaderColorClass(this ModalType modalType) =>
        modalType switch
        {
            ModalType.Primary => "text-bg-primary border-bottom border-primary",
            ModalType.Secondary => "text-bg-secondary border-bottom border-secondary",
            ModalType.Success => "text-bg-success border-bottom border-success",
            ModalType.Danger => "text-bg-danger border-bottom border-danger",
            ModalType.Warning => "text-bg-warning border-bottom border-warning",
            ModalType.Info => "text-bg-info border-bottom border-info",
            ModalType.Light => "text-bg-light border-bottom",
            ModalType.Dark => "text-bg-dark border-bottom border-dark",
            _ => ""
        };

    public static string ToModalSizeClass(this ModalSize modalSize) =>
        modalSize switch
        {
            ModalSize.Regular => "",
            ModalSize.Small => "modal-sm",
            ModalSize.Large => "modal-lg",
            ModalSize.ExtraLarge => "modal-xl",
            _ => ""
        };

    public static string ToOffcanvasPlacementClass(this Placement placement) =>
        placement switch
        {
            Placement.Start => "offcanvas-start",
            Placement.End => "offcanvas-end",
            Placement.Top => "offcanvas-top",
            _ => "offcanvas-bottom"
        };

    public static string ToOffcanvasSizeClass(this OffcanvasSize offcanvasSize) =>
        offcanvasSize switch
        {
            OffcanvasSize.Regular => "",
            OffcanvasSize.Small => "bb-offcanvas-sm",
            OffcanvasSize.Large => "bb-offcanvas-lg",
            _ => ""
        };

    public static string ToPaginationAlignmentClass(this Alignment alignment) =>
        alignment switch
        {
            Alignment.Start => "justify-content-start",
            Alignment.Center => "justify-content-center",
            Alignment.End => "justify-content-end",
            _ => ""
        };

    public static string ToPaginationSizeClass(this PaginationSize paginationSize) =>
        paginationSize switch
        {
            PaginationSize.Small => "pagination-sm",
            PaginationSize.Large => "pagination-lg",
            _ => ""
        };

    public static string ToPlaceholderAnimationClass(this PlaceholderAnimation placeholderAnimation) =>
        placeholderAnimation switch
        {
            PlaceholderAnimation.Glow => "placeholder-glow",
            PlaceholderAnimation.Wave => "placeholder-wave",
            _ => ""
        };

    public static string ToPlaceholderSizeClass(this PlaceholderSize placeholderSize) =>
        placeholderSize switch
        {
            PlaceholderSize.ExtraSmall => "placeholder-xs",
            PlaceholderSize.Small => "placeholder-sm",
            PlaceholderSize.Large => "placeholder-lg",
            _ => ""
        };

    public static string ToPlaceholderWidthClass(this PlaceholderWidth placeholderWidth) =>
        placeholderWidth switch
        {
            PlaceholderWidth.Col1 => "col-1",
            PlaceholderWidth.Col2 => "col-2",
            PlaceholderWidth.Col3 => "col-3",
            PlaceholderWidth.Col4 => "col-4",
            PlaceholderWidth.Col5 => "col-5",
            PlaceholderWidth.Col6 => "col-6",
            PlaceholderWidth.Col7 => "col-7",
            PlaceholderWidth.Col8 => "col-8",
            PlaceholderWidth.Col9 => "col-9",
            PlaceholderWidth.Col10 => "col-10",
            PlaceholderWidth.Col11 => "col-11",
            PlaceholderWidth.Col12 => "col-12",
            _ => ""
        };

    public static string ToPositionClass(this Position position) =>
        position switch
        {
            Position.Static => BootstrapClass.PositionAbsolute,
            Position.Relative => BootstrapClass.PositionRelative,
            Position.Absolute => BootstrapClass.PositionAbsolute,
            Position.Fixed => BootstrapClass.PositionFixed,
            Position.Sticky => BootstrapClass.PositionSticky,
            _ => ""
        };

    public static object ToSortableListPullMode(this SortableListPullMode sortableListPullMode) =>
        sortableListPullMode switch
        {
            SortableListPullMode.True => true,
            SortableListPullMode.False => false,
            SortableListPullMode.Clone => "clone",
            //SortableListPullMode.Array => "array"
            _ => throw new ArgumentOutOfRangeException(nameof(sortableListPullMode), sortableListPullMode, "Invalid SortableListPullMode value supplied")
        };

    public static object ToSortableListPutMode(this SortableListPutMode sortableListPutMode) =>
        sortableListPutMode == SortableListPutMode.True;
     
    public static string ToSpinnerSizeClass(this SpinnerSize spinnerSize) =>
        spinnerSize switch
        {
            SpinnerSize.Small => "sm",
            SpinnerSize.Medium => "md",
            SpinnerSize.Large => "lg",
            SpinnerSize.ExtraLarge => "xl",
            _ => "md"
        };

    public static string ToSpinnerTypeClass(this SpinnerType spinnerType) =>
        spinnerType switch
        {
            SpinnerType.Border => "spinner-border",
            SpinnerType.Grow => "spinner-grow",
            SpinnerType.Dots => "spinner-dots",
            _ => "spinner-border"
        };

    public static string ToTargetString(this Target target) =>
        target switch
        {
            Target.Blank => "_blank",
            Target.Parent => "_parent",
            Target.Top => "_top",
            Target.Self => "_self",
            _ => ""
        };

    public static string ToTextAlignmentClass(this Alignment alignment) =>
        alignment switch
        {
            BlazorBootstrap.Alignment.Start => "text-start",
            BlazorBootstrap.Alignment.Center => "text-center",
            BlazorBootstrap.Alignment.End => "text-end",
            _ => ""
        };
     

    public static string? ToTooltipColorClass(this BsColor BsColor) =>
        BsColor switch
        {
            BsColor.Primary => "bb-tooltip-primary",
            BsColor.Secondary => "bb-tooltip-tooltip-secondary",
            BsColor.Success => "bb-tooltip-success",
            BsColor.Danger => "bb-tooltip-danger",
            BsColor.Warning => "bb-tooltip-warning",
            BsColor.Info => "bb-tooltip-info",
            BsColor.Light => "bb-tooltip-light",
            BsColor.Dark => "bb-tooltip-dark",
            _ => null
        };

    public static string ToTooltipPlacementName(this TooltipPlacement tooltipPlacement) =>
        tooltipPlacement switch
        {
            TooltipPlacement.Auto => "auto",
            TooltipPlacement.Right => "right",
            TooltipPlacement.Bottom => "bottom",
            TooltipPlacement.Left => "left",
            _ => "top"
        };

    public static string ToToastsPlacementClass(this ToastsPlacement toastsPlacement) =>
        toastsPlacement switch
        {
            ToastsPlacement.TopLeft => "top-0 start-0",
            ToastsPlacement.TopCenter => "top-0 start-50 translate-middle-x",
            ToastsPlacement.TopRight => "top-0 end-0",
            ToastsPlacement.MiddleLeft => "top-50 start-0 translate-middle-y",
            ToastsPlacement.MiddleCenter => "top-50 start-50 translate-middle",
            ToastsPlacement.MiddleRight => "top-50 end-0 translate-middle-y",
            ToastsPlacement.BottomLeft => "bottom-0 start-0",
            ToastsPlacement.BottomCenter => "bottom-0 start-50 translate-middle-x",
            ToastsPlacement.BottomRight => "bottom-0 end-0",
            _ => "top-0 end-0" // default: Top right
        };

    public static string ToToastTextColorClass(this BsColor BsColor) =>
        BsColor switch
        {
            BsColor.Primary
                or BsColor.Secondary
                or BsColor.Success
                or BsColor.Danger
                or BsColor.Dark => "text-white",
            BsColor.Warning
                or BsColor.Info
                or BsColor.Light => "text-dark",
            _ => ""
        };

    #endregion
}
