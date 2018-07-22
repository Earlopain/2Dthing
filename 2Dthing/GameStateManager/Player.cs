using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Camera;

namespace GameState
{
    public class Player
    {
        public Texture2D Texture;
        public Point Position;
        public int Depth;
        public Player(Texture2D texture, int depth, Point pos)
        {
            this.Texture = texture;
            this.Depth = depth;
            this.Position = pos;
        }

        public void ApplyKeyState(KeyboardState keyboardState)
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