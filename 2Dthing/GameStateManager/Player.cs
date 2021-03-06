using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using Layers;
using Camera;
using Sprites;

namespace GameState
{
    public class Player
    {
        public ISpriteInterface Sprite;
        public Point Position;
        public int Depth;
        public Player(Texture2D texture, int depth, Point pos)
        {
            this.Sprite = new AnimatedSprite(texture, pos, 1, 8);
            this.Depth = depth;
            this.Position = pos;
        }

        public Player()
        {
            this.Sprite = new StaticSprite();
            this.Depth = 0;
            this.Position = Point.Zero;
        }

        public void ApplyUserInput(KeyboardState keyboardState, MouseState mouseState)
        {
            int movementSpeed = 5;
            Keys[] keys = keyboardState.GetPressedKeys();
            foreach (Keys key in keys)
            {
                switch (key)
                {
                    case Keys.W:
                        Position = new Point(Position.X, Position.Y - movementSpeed);
                        break;
                    case Keys.A:
                        Position = new Point(Position.X - movementSpeed, Position.Y);
                        break;
                    case Keys.S:
                        Position = new Point(Position.X, Position.Y + movementSpeed);
                        break;
                    case Keys.D:
                        Position = new Point(Position.X + movementSpeed, Position.Y);
                        break;
                }
            }
        }
    }
}