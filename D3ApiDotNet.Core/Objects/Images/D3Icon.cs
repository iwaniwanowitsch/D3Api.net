#region

using System.IO;
using System.Drawing;
using D3ApiDotNet.Core.NotifyPropertyChanged;

#endregion

namespace D3ApiDotNet.Core.Objects.Images
{
    /// <summary>
    /// D3ApiServiceExample: D3Icon, used to capsule icon images
    /// </summary>
    public class D3Icon : BaseNotifyPropertyChanged
    {
        /// <summary />
        public Image Icon { get; set; }

        public D3Icon()
        {
            
        }

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
