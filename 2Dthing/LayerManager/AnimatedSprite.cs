using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

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
            this.AnimationSpeed = 0.2f;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle area)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = (int)CurrentFrame % Columns;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            spriteBatch.Draw(Texture, area, sourceRectangle, Color.White);
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