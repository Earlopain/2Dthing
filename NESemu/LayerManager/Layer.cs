using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

namespace Layers
{
    public class Layer
    {
        public int height { get; }
        public List<LayerElement> elementList = new List<LayerElement>();
        public Layer(int height)
        {
            this.height = height;
        }

        public void addTexture2D(Texture2D texture, int x, int y)
        {
            elementList.Add(new LayerElement(texture, x, y));
        }
    }
    public class LayerElement
    {
        public Texture2D texture;
        public int x, y;
        public LayerElement(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            this.x = x;
            this.y = y;
        }
    }

}
