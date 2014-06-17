using System.Windows;
using System.Windows.Controls;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.TemplateSelectors
{
    public class ContentViewModelTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LoadDataViewModelTemplate { get; set; }
        public DataTemplate HeroViewModelTemplate { get; set; }
        public DataTemplate AllItemListViewModelTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var loadDataViewModel = item as ILoadDataViewModel;

            if (loadDataViewModel != null)
                return LoadDataViewModelTemplate;

            var heroViewModel = item as IHeroViewModel;

            if (heroViewModel != null)
                return HeroViewModelTemplate;

            var allItemsViewModel = item as IAllItemListViewModel;

            if (allItemsViewModel != null)
                return AllItemListViewModelTemplate;

            return null;
        }
    }
}
