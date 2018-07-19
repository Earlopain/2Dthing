using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Layers
{
    public class LayerManager
    {
        private SpriteBatch spriteBatch;
        private List<Layer> layerList = new List<Layer>();

        public LayerManager(GraphicsDevice gd)
        {
            spriteBatch = new SpriteBatch(gd);
        }
        public Layer addLayer(int height)
        {
            layerList.Add(new Layer(height));
            return layerList[layerList.Count - 1];
        }

        public Layer getLayer(int height)
        {
            Layer l = layerList.Find(layer => layer.height == height);
            if (l == null)
            {
                l = addLayer(height);
            }
            return l;
        }

        public void draw()
        {
            layerList.Sort(delegate (Layer x, Layer y)
            {
                return x.height.CompareTo(y.height);
            });
            foreach (Layer l in layerList)
            {
                spriteBatch.Begin();
                foreach (LayerElement le in l.elementList)
                {
                    spriteBatch.Draw(le.texture, new Rectangle(le.x, le.y, le.texture.Width, le.texture.Height), Color.White);
                }
                spriteBatch.End();
            }
        }
    }
}