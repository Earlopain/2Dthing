using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Layers.Internal
{
    public class Layer
    {
        public int Depth { get; }
        public List<LayerElement> elementList = new List<LayerElement>();
        public Layer(int depth)
        {
            this.Depth = depth;
        }

        public void addTexture2D(Texture2D texture, int x, int y)
        {
            elementList.Add(new LayerElement(texture, new Point(x, y)));
        }

        public void addTexture2D(Texture2D texture, Point p)
        {
            elementList.Add(new LayerElement(texture, p));
        }
    }
    public class LayerElement
    {
        public Texture2D Texture;
        public Point Position;

        public LayerElement(Texture2D texture, Point p)
        {
            this.Texture = texture;
            this.Position = p;
        }
    }

}
