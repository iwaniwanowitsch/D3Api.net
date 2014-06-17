namespace D3ApiDotNet.WpfUI.ViewModels.Interfaces
{
    public interface IItemViewModel
    {
        bool HasTooltipEnabled { get; set; }
        IItemDetailViewModel ItemDetailViewModel { get; }
    }
}
