using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Camera;
using GameState;
using Layers.Internal;

namespace Layers
{
    public class LayerManager
    {
        private SpriteBatch SpriteBatch { get; }
        private GraphicsDevice GraphicsDevice { get; }
        private List<Layer> LayerList { get; }
        public Player Player;
        public Point BaseScreenSize { get; }
        /// <summary>
        /// Contains all texture data, drawn top to bottom, only if visible
        /// </summary>
        /// <param name="gd">GraphicsDevice used to determine screensize and create spriteBatch</param>
        public LayerManager(GraphicsDevice gd, ContentManager content)
        {
            this.BaseScreenSize = new Point(gd.DisplayMode.Width, gd.DisplayMode.Height);
            this.GraphicsDevice = gd;
            this.SpriteBatch = new SpriteBatch(gd);
            this.LayerList = new List<Layer>();
        }
        private Layer AddLayer(int depth)
        {
            LayerList.Add(new Layer(depth));
            return LayerList[LayerList.Count - 1];
        }
        /// <summary>
        /// Gets the leveled layer or creates it if not available
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public Layer GetLayer(int depth)
        {
            Layer l = LayerList.Find(layer => layer.Depth == depth);
            if (l == null)
            {
                l = AddLayer(depth);
            }
            return l;
        }

        /// <summary>
        /// Draws all LayerElements in view
        /// </summary>
        /// <param name="camera">Current view to draw</param>
        public void Draw(CameraManager camera)
        {
            //Sorts layers lowest to highest
            LayerList.Sort(delegate (Layer x, Layer y)
            {
                return x.Depth.CompareTo(y.Depth);
            });

            //create transformation matrix for different screen resolutions and apply it at drawing
            float horScaling = (float)GraphicsDevice.PresentationParameters.BackBufferWidth / BaseScreenSize.X;
            float verScaling = (float)GraphicsDevice.PresentationParameters.BackBufferHeight / BaseScreenSize.Y;
            Vector3 screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            Matrix globalTransformation = Matrix.CreateScale(screenScalingFactor);
            SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, globalTransformation);
            //apply previous transformation
            foreach (Layer l in LayerList)
            {
                foreach (LayerElement le in l.elementList)
                {   //draw texture at position * zoom relative to the camera center at a size*zoom
                    //The actual position of the element in the world + camera position

                    //mapped onto the screen
                    Vector2 screenPos = getScreenPos(le.Position.X, le.Position.Y, camera);
                    //area of the screen ocupied by the element
                    Rectangle drawElement = new Rectangle((int)(screenPos.X), (int)(screenPos.Y), (int)Math.Ceiling(le.Texture.Width / camera.ZoomFactor + 1), (int)Math.Ceiling(le.Texture.Height / camera.ZoomFactor + 1));
                    //draw only if visible, not need to worry about depth as layers are sorted lowest to highest
                    if (drawElement.Intersects(camera.DrawArea))
                        SpriteBatch.Draw(le.Texture, drawElement, Color.White);
                }
                if (l.Depth == Player.Depth)
                {
                    Vector2 screenPos = getScreenPos(Player.Position.X, Player.Position.Y, camera);
                    SpriteBatch.Draw(Player.Texture, new Rectangle((int)(screenPos.X), (int)(screenPos.Y), Player.Texture.Width, Player.Texture.Height), Color.White);

                }
            }
            SpriteBatch.End();
        }

        public Vector2 getScreenPos(int x, int y, CameraManager camera)
        {
            Vector2 origPos = new Vector2(x + camera.ScreenCenter.X, y + camera.ScreenCenter.Y);
            Vector2 screenPos = new Vector2(Util.Map(origPos.X, BaseScreenSize.X, BaseScreenSize.X / 2 - BaseScreenSize.X / 2 / camera.ZoomFactor, BaseScreenSize.X / 2 / camera.ZoomFactor + BaseScreenSize.X / 2), Util.Map(origPos.Y, BaseScreenSize.Y, BaseScreenSize.Y / 2 - BaseScreenSize.Y / 2 / camera.ZoomFactor, BaseScreenSize.Y / 2 / camera.ZoomFactor + BaseScreenSize.Y / 2));
            return screenPos;

        }
    }
}