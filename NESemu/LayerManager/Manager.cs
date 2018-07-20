using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Camera;

namespace Layers
{
    public class LayerManager
    {
        private SpriteBatch spriteBatch;
        private GraphicsDevice gd;
        private List<Layer> layerList = new List<Layer>();
        public Vector2 baseScreenSize;

        public LayerManager(GraphicsDevice gd, CameraManager c)
        {
            //this.baseScreenSize = new Vector2(c.visibleScreenSize.X, c.visibleScreenSize.Y);
            this.baseScreenSize = new Vector2(1920, 1080);
            this.gd = gd;
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

        public void draw(CameraManager camera)
        {
            layerList.Sort(delegate (Layer x, Layer y)
            {
                return x.height.CompareTo(y.height);
            });

            Vector3 screenScalingFactor;

            float horScaling = (float)gd.PresentationParameters.BackBufferWidth / baseScreenSize.X * 1;
            float verScaling = (float)gd.PresentationParameters.BackBufferHeight / baseScreenSize.Y * 1;
            screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            Matrix globalTransformation = Matrix.CreateScale(screenScalingFactor);
            foreach (Layer l in layerList)
            {
                List<LayerElement> visibleElements = getVisibleElements(l.elementList, camera);
                spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);
                foreach (LayerElement le in visibleElements)
                {

                    spriteBatch.Draw(le.texture, new Rectangle((int)(le.x * camera.scalingFactorObjects + camera.screenCenter.X), (int)(le.y * camera.scalingFactorObjects + camera.screenCenter.Y), (int)(le.texture.Width * camera.scalingFactorObjects), (int)(le.texture.Height * camera.scalingFactorObjects)), Color.White);
                }
                spriteBatch.End();
            }
        }

        private List<LayerElement> getVisibleElements(List<LayerElement> list, CameraManager camera)
        {
            List<LayerElement> result = new List<LayerElement>();
            Rectangle drawArea = new Rectangle(camera.offset.X - camera.visibleScreenSize.X / 2, camera.offset.Y - camera.visibleScreenSize.Y / 2, camera.visibleScreenSize.X, camera.visibleScreenSize.Y);
            foreach (LayerElement le in list)
            {
                Rectangle r = new Rectangle((int)(-(le.x * camera.scalingFactorObjects) - le.texture.Width * camera.scalingFactorObjects), (int)(-(le.y * camera.scalingFactorObjects) - le.texture.Height * camera.scalingFactorObjects), (int)(le.texture.Width * camera.scalingFactorObjects), (int)(le.texture.Height * camera.scalingFactorObjects));

                if (r.Intersects(drawArea))
                    result.Add(le);

            }
            return result;
        }
    }
}