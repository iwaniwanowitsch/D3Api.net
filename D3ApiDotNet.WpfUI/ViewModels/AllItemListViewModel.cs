using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.DataAccess.WebInteraction;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.Commands;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class AllItemListViewModel : BaseContentViewModel, IAllItemListViewModel
    {
        private readonly ApiAccessFacade _api;
        private readonly ItemNamesCollector _itemNamesCollector;

        public AllItemListViewModel([NotNull] ApiAccessFacade api, [NotNull] ItemNamesCollector itemNamesCollector,
            [NotNull] ObservableCollection<Item> itemList, [NotNull] IManageContentViewModelActions manageContentViewModelActions)
            : base(manageContentViewModelActions, false, true)
        {
            if (api == null) throw new ArgumentNullException("api");
            if (itemNamesCollector == null) throw new ArgumentNullException("itemNamesCollector");
            if (itemList == null) throw new ArgumentNullException("itemList");
            AllItemList = itemList;
            _api = api;
            _itemNamesCollector = itemNamesCollector;
            LoadItems();
        }

        public async void LoadItems()
        {
            var itemNames =
                await Task.Factory.StartNew(() => _itemNamesCollector.GetAllItemNames("eu.battle.net", "en"));
            foreach (var itemName in itemNames)
            {
                Item item = await Task.Factory.StartNew(() =>
                {
                    try
                    {
                        return _api.ItemRepository.GetByItemId(itemName);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                });

                if (item != null && !AllItemList.Contains(item))
                    AllItemList.Add(item);
            }
            IsLoading = false;
        }

        public override string Name
        {
            get { return "All Items List"; }
        }

        public ObservableCollection<Item> AllItemList { get; set; }
    }
}