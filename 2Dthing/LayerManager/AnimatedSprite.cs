using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using Camera;

namespace Sprites
{
    public class AnimatedSprite : ISpriteInterface
    {
        public Texture2D Texture { get; set; }
        public Point Position { get; set; }
        public int Rows { get; }
        public int Columns { get; }
        float AnimationSpeed;
        float CurrentFrame;
        int TotalFrames;
        public AnimatedSprite(Texture2D texture, Point p, int rows, int columns)
        {
            this.Texture = texture;
            this.Position = p;
            this.Rows = rows;
            this.Columns = columns;
            this.TotalFrames = rows * columns;
            this.CurrentFrame = 0;
            this.AnimationSpeed = .1f;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle area, CameraManager camera)
        {
            area.Inflate(1,1);
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = (int)CurrentFrame % Columns;
            //the full frame to display relative to the texture
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            DrawInformation drawInformation = new DrawInformation(area, camera, sourceRectangle);
            spriteBatch.Draw(Texture, drawInformation.DrawLocation, drawInformation.TexturePart, Color.White);
            Update();
        }

        public void Update()
        {
            CurrentFrame += AnimationSpeed;
            if (CurrentFrame >= TotalFrames)
                CurrentFrame = 0;
        }
    }
}