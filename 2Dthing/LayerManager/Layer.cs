using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprites;

namespace Layers
{
    public class Layer
    {
        public int Depth { get; }
        public List<Sprites.ISpriteInterface> elementList { get; set; }
        public Layer(int depth)
        {
            this.elementList = new List<ISpriteInterface>();
            this.Depth = depth;
        }

        public void AddStaticSprite(Texture2D texture, Point position)
        {
            elementList.Add(new StaticSprite(texture, position));
        }

        public void AddStaticSprite(Texture2D texture, int x, int y)
        {
            elementList.Add(new StaticSprite(texture, new Point(x, y)));
        }

        public void AddAnimatedSprite(Texture2D texture, Point position, int rows, int columns)
        {
            elementList.Add(new AnimatedSprite(texture, position, rows, columns));
        }
    }

}
