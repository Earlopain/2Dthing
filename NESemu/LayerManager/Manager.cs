using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Camera;
using Layers.Internal;

namespace Layers
{
    public class LayerManager
    {
        private SpriteBatch SpriteBatch { get; }
        private GraphicsDevice GraphicsDevice { get; }
        private List<Layer> LayerList { get; }
        public Vector2 BaseScreenSize { get; }
        /// <summary>
        /// Contains all texture data, drawn top to bottom, only if visible
        /// </summary>
        /// <param name="gd">GraphicsDevice used to determine screensize and create spriteBatch</param>
        public LayerManager(GraphicsDevice gd)
        {
            this.BaseScreenSize = new Vector2(gd.DisplayMode.Width, gd.DisplayMode.Height);
            this.GraphicsDevice = gd;
            this.SpriteBatch = new SpriteBatch(gd);
            this.LayerList = new List<Layer>();
        }
        private Layer addLayer(int height)
        {
            LayerList.Add(new Layer(height));
            return LayerList[LayerList.Count - 1];
        }
        /// <summary>
        /// Gets the leveled layer or creates it if not available
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public Layer getLayer(int height)
        {
            Layer l = LayerList.Find(layer => layer.Height == height);
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
            LayerList.Sort(delegate (Layer x, Layer y)
            {
                return x.Height.CompareTo(y.Height);
            });

            //create transformation matrix for different screen resolutions and apply it at drawing
            float horScaling = (float)GraphicsDevice.PresentationParameters.BackBufferWidth / BaseScreenSize.X * 1;
            float verScaling = (float)GraphicsDevice.PresentationParameters.BackBufferHeight / BaseScreenSize.Y * 1;
            Vector3 screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            Matrix globalTransformation = Matrix.CreateScale(screenScalingFactor);

            foreach (Layer l in LayerList)
            {
                List<LayerElement> visibleElements = getVisibleElements(l.elementList, camera);
                //apply previous transformation
                SpriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);
                foreach (LayerElement le in visibleElements)
                {   //draw texture at position * zoom relative to the camera center at a size*zoom
                    SpriteBatch.Draw(le.Texture, new Rectangle((int)(le.Position.X * camera.ScalingFactorObjects + camera.ScreenCenter.X), (int)(le.Position.Y * camera.ScalingFactorObjects + camera.ScreenCenter.Y), (int)(le.Texture.Width * camera.ScalingFactorObjects), (int)(le.Texture.Height * camera.ScalingFactorObjects)), Color.White);
                }
                SpriteBatch.End();
            }
        }

        private List<LayerElement> getVisibleElements(List<LayerElement> list, CameraManager camera)
        {
            List<LayerElement> result = new List<LayerElement>();
            //the area which is visible by the camera
            Rectangle drawArea = new Rectangle(camera.Offset.X - camera.VisibleScreenSize.X / 2, camera.Offset.Y - camera.VisibleScreenSize.Y / 2, camera.VisibleScreenSize.X, camera.VisibleScreenSize.Y);
            foreach (LayerElement le in list)
            {
                //no fucking idea, I just tried until it worked, why negative position??
                Rectangle r = new Rectangle((int)(-(le.Position.X * camera.ScalingFactorObjects) - le.Texture.Width * camera.ScalingFactorObjects), (int)(-(le.Position.Y * camera.ScalingFactorObjects) - le.Texture.Height * camera.ScalingFactorObjects), (int)(le.Texture.Width * camera.ScalingFactorObjects), (int)(le.Texture.Height * camera.ScalingFactorObjects));
                //whatever, if they intersect, it must still be visible
                if (r.Intersects(drawArea))
                    result.Add(le);

            }
            return result;
        }
    }
}