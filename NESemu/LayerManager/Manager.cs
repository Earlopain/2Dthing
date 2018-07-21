using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Camera;
using Layers.Internal;

namespace Layers
{
    public class LayerManager
    {
        private SpriteBatch spriteBatch;
        private GraphicsDevice gd;
        private List<Layer> layerList = new List<Layer>();
        public Vector2 baseScreenSize;
        /// <summary>
        /// Contains all texture data, drawn top to bottom, only if visible
        /// </summary>
        /// <param name="gd">GraphicsDevice used to determine screensize and create spriteBatch</param>
        public LayerManager(GraphicsDevice gd)
        {
            this.baseScreenSize = new Vector2(gd.DisplayMode.Width, gd.DisplayMode.Height);
            this.gd = gd;
            spriteBatch = new SpriteBatch(gd);
        }
        private Layer addLayer(int height)
        {
            layerList.Add(new Layer(height));
            return layerList[layerList.Count - 1];
        }
        /// <summary>
        /// Gets the leveled layer or creates it if not available
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public Layer getLayer(int height)
        {
            Layer l = layerList.Find(layer => layer.height == height);
            if (l == null)
            {
                l = addLayer(height);
            }
            return l;
        }
        /// <summary>
        /// Draws all LayerElements in view
        /// </summary>
        /// <param name="camera">Current view to draw</param>
        public void draw(CameraManager camera)
        {
            //Sorts layers lowest to highest
            layerList.Sort(delegate (Layer x, Layer y)
            {
                return x.height.CompareTo(y.height);
            });

            //create transformation matrix for different screen resolutions and apply it at drawing
            float horScaling = (float)gd.PresentationParameters.BackBufferWidth / baseScreenSize.X * 1;
            float verScaling = (float)gd.PresentationParameters.BackBufferHeight / baseScreenSize.Y * 1;
            Vector3 screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            Matrix globalTransformation = Matrix.CreateScale(screenScalingFactor);

            foreach (Layer l in layerList)
            {
                List<LayerElement> visibleElements = getVisibleElements(l.elementList, camera);
                //apply previous transformation
                spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);
                foreach (LayerElement le in visibleElements)
                {   //draw texture at position * zoom relative to the camera center at a size*zoom
                    spriteBatch.Draw(le.texture, new Rectangle((int)(le.position.X * camera.scalingFactorObjects + camera.screenCenter.X), (int)(le.position.Y * camera.scalingFactorObjects + camera.screenCenter.Y), (int)(le.texture.Width * camera.scalingFactorObjects), (int)(le.texture.Height * camera.scalingFactorObjects)), Color.White);
                }
                spriteBatch.End();
            }
        }

        private List<LayerElement> getVisibleElements(List<LayerElement> list, CameraManager camera)
        {
            List<LayerElement> result = new List<LayerElement>();
            //the area which is visible by the camera
            Rectangle drawArea = new Rectangle(camera.offset.X - camera.visibleScreenSize.X / 2, camera.offset.Y - camera.visibleScreenSize.Y / 2, camera.visibleScreenSize.X, camera.visibleScreenSize.Y);
            foreach (LayerElement le in list)
            {
                //no fucking idea, I just tried until it worked, why negative position??
                Rectangle r = new Rectangle((int)(-(le.position.X * camera.scalingFactorObjects) - le.texture.Width * camera.scalingFactorObjects), (int)(-(le.position.Y * camera.scalingFactorObjects) - le.texture.Height * camera.scalingFactorObjects), (int)(le.texture.Width * camera.scalingFactorObjects), (int)(le.texture.Height * camera.scalingFactorObjects));
                //whatever, if they intersect, it must still be visible
                if (r.Intersects(drawArea))
                    result.Add(le);

            }
            return result;
        }
    }
}