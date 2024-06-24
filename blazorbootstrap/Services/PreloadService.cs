namespace BlazorBootstrap;

public class PreloadService
{
    #region Events

    internal event Action OnHide = default!;
    internal event Action<BsColor, string?> OnShow = default!;

    #endregion

    #region Methods

    public void Hide() => OnHide?.Invoke();

    public void Show(BsColor spinnerColor = BsColor.Light, string? loadingText = null) => OnShow?.Invoke(spinnerColor, loadingText);

    #endregion
}
