using D3ApiDotNet.WpfUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace D3ApiDotNet.WpfUI.TemplateSelectors
{
    public class ContentViewModelTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LoadDataViewModelTemplate { get; set; }
        public DataTemplate HeroViewModelTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var loadDataViewModel = item as ILoadDataViewModel;

            if (loadDataViewModel != null)
                return LoadDataViewModelTemplate;

            var heroViewModel = item as IHeroViewModel;

            if (heroViewModel != null)
                return HeroViewModelTemplate;

            return null;
        }
    }
}
