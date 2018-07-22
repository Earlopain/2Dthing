using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Camera;
using GameState;
using Sprites;

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
                foreach (ISpriteInterface le in l.elementList)
                {   //draw texture at position * zoom relative to the camera center at a size*zoom
                    //The actual position of the element in the world + camera position

                    //area of the screen ocupied by the element
                    Rectangle drawElement = getAreaOnScreen(le.Position, le, camera);
                    //draw only if visible, not need to worry about depth as layers are sorted lowest to highest
                    if (drawElement.Intersects(camera.DrawArea))
                        le.Draw(SpriteBatch, drawElement, camera);
                }
                if (l.Depth == Player.Depth)
                {
                    Vector2 screenPos = getScreenPos(Player.Position, camera);
                    Player.Sprite.Draw(SpriteBatch, getAreaOnScreen(Player.Position, Player.Sprite, camera), camera);

                }
            }
            SpriteBatch.End();
        }

        public Vector2 getScreenPos(Point p, CameraManager camera)
        {
            Vector2 origPos = new Vector2(p.X + camera.ScreenCenter.X, p.Y + camera.ScreenCenter.Y);
            return new Vector2(General.Util.Map(origPos.X, BaseScreenSize.X, BaseScreenSize.X / 2 - BaseScreenSize.X / 2 / camera.ZoomFactor, BaseScreenSize.X / 2 / camera.ZoomFactor + BaseScreenSize.X / 2), General.Util.Map(origPos.Y, BaseScreenSize.Y, BaseScreenSize.Y / 2 - BaseScreenSize.Y / 2 / camera.ZoomFactor, BaseScreenSize.Y / 2 / camera.ZoomFactor + BaseScreenSize.Y / 2));
        }
        public Rectangle getAreaOnScreen(Point original, ISpriteInterface sprite, CameraManager camera)
        {
            Vector2 screenPos = getScreenPos(original, camera);
            return new Rectangle((int)Math.Ceiling(screenPos.X - sprite.Texture.Width / sprite.Columns / camera.ZoomFactor), (int)Math.Ceiling(screenPos.Y - sprite.Texture.Height / sprite.Rows / camera.ZoomFactor), (int)Math.Ceiling(sprite.Texture.Width / sprite.Columns / camera.ZoomFactor), (int)Math.Ceiling(sprite.Texture.Height / sprite.Rows / camera.ZoomFactor));
        }
    }
}