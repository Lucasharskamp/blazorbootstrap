namespace BlazorBootstrap;

/// <summary>
/// Represents the color of a Bootstrap component, whether it be a border color, text color, background color or anything else. <br/>
/// For more information, check out <seealso href="https://getbootstrap.com/docs/5.0/utilities/colors/" />.
/// </summary>
public enum BsColor
{
    /// <summary>
    /// Retain the default color of this component. This is the default value.
    /// </summary>
    Default = 0,
    /// <summary>
    /// The Primary color.
    /// </summary>
    Primary,
    /// <summary>
    /// The Secondary color.
    /// </summary>
    Secondary,
    /// <summary>
    /// The Success color.
    /// </summary>
    Success,
    /// <summary>
    /// The Danger color. (often used for error messages)
    /// </summary>
    Danger,
    /// <summary>
    /// The Warning color.
    /// </summary>
    Warning,
    /// <summary>
    /// The Info color to highlight important information the user needs to know about.
    /// </summary>
    Info,
    /// <summary>
    /// The Light color.
    /// </summary>
    /// <remarks>
    /// Using the Light color can cause unexpected styling issues when using light/dark mode.
    /// </remarks>
    Light,
    /// <summary>
    /// The Dark color.
    /// </summary>
    /// <remarks>
    /// Using the Dark color can cause unexpected styling issues when using light/dark mode.
    /// </remarks>
    Dark,
    /// <summary>
    /// Make the color of this component transparent (whether it's the border, text, background, etc.).
    /// </summary>
    Transparent,
    /// <summary>
    /// Take the color of this component from the original HTML's body color, as assigned in the CSS variable --bs-body
    /// </summary>
    /// <remarks>
    /// If you manually override the HTML's body color, this color will not be updated. Make sure you set it properly in the CSS!
    /// </remarks>
    Body,
    /// <summary>
    /// Black color as defined in the Bootstrap CSS.
    /// </summary>
    Black,
    /// <summary>
    /// White color as defined in the Bootstrap CSS.
    /// </summary>
    White,
    /// <summary>
    /// Muted color (usually <see cref="Secondary"/>)
    /// </summary>
    Muted,
    /// <summary>
    /// Link color 
    /// </summary>
    Link
}