using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using D3apiData.Repositories;

namespace D3apiData.WebInteraction
{
    class ItemNamesCollector
    {
        private readonly StreamWebRepository _client;

        /// <summary>
        /// constructor for class, which collects item names from battle.net/en/item/
        /// </summary>
        /// <param name="client">webclient for requests</param>
        public ItemNamesCollector(StreamWebRepository client)
        {
            if (client == null)
                throw new ArgumentNullException("client");
            _client = client;
        }

        /// <summary>
        /// gets alls item names via webclient
        /// </summary>
        /// <param name="root">url root eg. "eu.battle.net"</param>
        /// <param name="language">language shortage eg. "en"</param>
        /// <returns></returns>
        public List<string> GetAllItemNames(string root, string language)
        {
            var pathes = new List<string>
            {
                @"/d3/"+language+"/item/helm/",
                @"/d3/"+language+"/item/spirit-stone/",
                @"/d3/"+language+"/item/voodoo-mask/",
                @"/d3/"+language+"/item/wizard-hat/",
                @"/d3/"+language+"/item/pauldrons/",
                @"/d3/"+language+"/item/chest-armor/",
                @"/d3/"+language+"/item/cloak/",
                @"/d3/"+language+"/item/bracers/",
                @"/d3/"+language+"/item/gloves/",
                @"/d3/"+language+"/item/belt/",
                @"/d3/"+language+"/item/mighty-belt/",
                @"/d3/"+language+"/item/pants/",
                @"/d3/"+language+"/item/boots/",
                @"/d3/"+language+"/item/amulet/",
                @"/d3/"+language+"/item/ring/",
                @"/d3/"+language+"/item/shield/",
                @"/d3/"+language+"/item/crusader-shield/",
                @"/d3/"+language+"/item/mojo/",
                @"/d3/"+language+"/item/orb/",
                @"/d3/"+language+"/item/quiver/",
                @"/d3/"+language+"/item/enchantress-focus/",
                @"/d3/"+language+"/item/scoundrel-token/",
                @"/d3/"+language+"/item/templar-relic/",
                @"/d3/"+language+"/item/axe-1h/",
                @"/d3/"+language+"/item/dagger/",
                @"/d3/"+language+"/item/mace-1h/",
                @"/d3/"+language+"/item/spear/",
                @"/d3/"+language+"/item/sword-1h/",
                @"/d3/"+language+"/item/ceremonial-knife/",
                @"/d3/"+language+"/item/fist-weapon/",
                @"/d3/"+language+"/item/flail-1h/",
                @"/d3/"+language+"/item/mighty-weapon-1h/",
                @"/d3/"+language+"/item/axe-2h/",
                @"/d3/"+language+"/item/mace-2h/",
                @"/d3/"+language+"/item/polearm/",
                @"/d3/"+language+"/item/staff/",
                @"/d3/"+language+"/item/sword-2h/",
                @"/d3/"+language+"/item/daibo/",
                @"/d3/"+language+"/item/flail-2h/",
                @"/d3/"+language+"/item/mighty-weapon-2h/",
                @"/d3/"+language+"/item/bow/",
                @"/d3/"+language+"/item/crossbow/",
                @"/d3/"+language+"/item/hand-crossbow/",
                @"/d3/"+language+"/item/wand/",
                @"/d3/"+language+"/item/potion/",
                @"/d3/"+language+"/item/crafting-material/",
                @"/d3/"+language+"/item/blacksmith-plan/",
                @"/d3/"+language+"/item/dye/",
                @"/d3/"+language+"/item/gem/",

            };

            var results = new List<string>();
            var visited = new List<string>();
            var containings = new List<string> { "/d3/" + language + "/item/", "/d3/" + language + "/artisan/blacksmith/recipe/", "/d3/" + language + "/artisan/jeweler/recipe/" };

            foreach (var path in pathes)
            {
                GrabAllLinks(root, path, containings, visited, results);
            }

            return results;
        }

        /// <summary>
        /// grabs all links from a website
        /// </summary>
        /// <param name="root">root of url</param>
        /// <param name="path">path extending root</param>
        /// <param name="containings">strings the links to be collected must contain</param>
        /// <param name="visited">already visited links</param>
        /// <param name="results">resulting links</param>
        private void GrabAllLinks(string root, string path, IEnumerable<string> containings, ICollection<string> visited, ICollection<string> results)
        {
            string sitecontent;
            using(var stream = _client.Retrieve(root + path))
                using(var reader = new StreamReader(stream))
                    sitecontent = reader.ReadToEnd();
            var enumerable = containings as IList<string> ?? containings.ToList();
            foreach (var containing in enumerable)
            {
                string[] split = sitecontent.Split(new string[] { containing }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string linkstring in split)
                {
                    if (linkstring.IndexOf("\" rel=\"np\"", System.StringComparison.Ordinal) > 0 && linkstring.IndexOf("\" rel=\"np\"", System.StringComparison.Ordinal) < 200)
                    {
                        string result = linkstring.Remove(linkstring.IndexOf("\" rel=\"np\"", System.StringComparison.Ordinal));
                        if (!visited.Contains(containing + result) && !result.EndsWith("/"))
                        {
                            results.Add(result);
                            visited.Add(containing + result);
                        }
                    }
                }
            }
            if (path.Contains("#"))
                path = path.Remove(path.IndexOf("#", System.StringComparison.Ordinal));
            var sites = sitecontent.Split(new string[] { "#page=" }, StringSplitOptions.RemoveEmptyEntries).Count() - 1;
            for (int i = 2; i < sites / 2; i++)
            {
                if (!visited.Contains(path + "#page=" + i))
                {
                    visited.Add(path + "#page=" + i);
                    GrabAllLinks(root, path + "#page=" + i, enumerable, visited, results);
                }
            }
        }
    }
}
