using System.Drawing;
using System.IO;

namespace D3apiData.API.Objects.Images
{
    /// <summary>
    /// D3Api: D3Icon, used to capsule icon images
    /// </summary>
    public class D3Icon
    {
        /// <summary />
        public Image Icon { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="stream">stream containing image</param>
        public D3Icon(Stream stream)
        {
            Icon = Image.FromStream(stream);
        }
    }
}
