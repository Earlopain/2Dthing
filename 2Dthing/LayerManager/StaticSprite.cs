using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

using Camera;

namespace Sprites
{
    public class StaticSprite : ISpriteInterface
    {
        public Texture2D Texture { get; }
        public Point Position { get; }
        public int Rows { get; }
        public int Columns { get; }
        public StaticSprite(Texture2D texture, Point p)
        {
            this.Texture = texture;
            this.Position = p;
            this.Rows = 1;
            this.Columns = 1;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle area, CameraManager camera)
        {
            //area not fully inside camera view, cut of the rest
            if (!camera.DrawArea.Contains(area))
            {
                Point offset = Layers.Util.getNewRecRespectScreenBounds(area, camera.DrawArea);
                //determine location, top left, bottom right etc
                //top left
                if (area.Top < camera.DrawArea.Top && area.Left < camera.DrawArea.Left)
                {
                    spriteBatch.Draw(Texture, new Rectangle(area.Location.X + offset.X, area.Location.Y + offset.Y, area.Width - offset.X, area.Height - offset.Y), new Rectangle(offset.X, offset.Y, area.Width - offset.X, area.Height - offset.Y), Color.White);
                }//top right
                else if (area.Top < camera.DrawArea.Top && area.Right > camera.DrawArea.Right)
                {
                    spriteBatch.Draw(Texture, new Rectangle(area.Location.X, area.Location.Y + offset.Y, area.Width - offset.X, area.Height - offset.Y), new Rectangle(0, offset.Y, area.Width - offset.X, area.Height - offset.Y), Color.White);
                }//bottom left
                else if (area.Bottom > camera.DrawArea.Bottom && area.Left < camera.DrawArea.Left)
                {
                    spriteBatch.Draw(Texture, new Rectangle(area.Location.X + offset.X, area.Location.Y, area.Width - offset.X, area.Height - offset.Y), new Rectangle(offset.X, 0, area.Width - offset.X, area.Height - offset.Y), Color.White);
                }//botom right
                else if (area.Bottom > camera.DrawArea.Bottom && area.Right > camera.DrawArea.Right)
                {
                    spriteBatch.Draw(Texture, new Rectangle(area.Location.X, area.Location.Y, area.Width - offset.X, area.Height - offset.Y), new Rectangle(0, 0, area.Width - offset.X, area.Height - offset.Y), Color.White);
                }//top only
                else if (area.Top < camera.DrawArea.Top)
                {
                    spriteBatch.Draw(Texture, new Rectangle(area.Location.X, area.Location.Y + offset.Y, area.Width, area.Height - offset.Y), new Rectangle(0, offset.Y, area.Width, area.Height - offset.Y), Color.White);
                }//left only
                else if (area.Left < camera.DrawArea.Left)
                {
                    spriteBatch.Draw(Texture, new Rectangle(area.Location.X + offset.X, area.Location.Y, area.Width - offset.X, area.Height), new Rectangle(offset.X, 0, area.Width - offset.X, area.Height), Color.White);
                }//bottom only
                else if (area.Bottom > camera.DrawArea.Bottom)
                {
                    spriteBatch.Draw(Texture, new Rectangle(area.Location.X, area.Location.Y, area.Width, area.Height - offset.Y), new Rectangle(0, 0, area.Width, area.Height - offset.Y), Color.White);
                }//right only
                else if (area.Right > camera.DrawArea.Right)
                {
                    spriteBatch.Draw(Texture, new Rectangle(area.Location.X, area.Location.Y, area.Width - offset.X, area.Height), new Rectangle(0, 0, area.Width - offset.X, area.Height), Color.White);
                }
                return;
            }
            spriteBatch.Draw(Texture, area, Color.White);

        }
    }
}