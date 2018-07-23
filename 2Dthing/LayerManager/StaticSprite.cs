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

        public StaticSprite()
        {
            this.Texture = new Texture2D(new GraphicsDevice(new GraphicsAdapter(), new GraphicsProfile(), new PresentationParameters()), 1, 1);
            //make texture 100% blank
            Color[] texData = new Color[1]; 
            texData[0] = new Color(0,0,0,0);
            Texture.SetData<Color>(texData);
            this.Position = Point.Zero;
            this.Rows = 1;
            this.Columns = 1;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle area, CameraManager camera)
        {
            area.Inflate(1,1);
            //area not fully inside camera view, cut of the rest
            if (!camera.DrawArea.Contains(area))
            {
                DrawInformation drawInformation = new DrawInformation(area, camera);
                spriteBatch.Draw(Texture, drawInformation.DrawLocation, drawInformation.TexturePart, Color.White);
                return;
            }
            spriteBatch.Draw(Texture, area, Color.White);

        }
    }
}