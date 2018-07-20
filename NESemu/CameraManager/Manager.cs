using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Camera
{
    public class CameraManager
    {
        public Point visibleScreenSize;
        public Point screenCenter;
        public Point offset;
        public double scalingFactorObjects;
        public CameraManager(GraphicsDevice gd, int screenEdgeDistance, double scalingFactorObjects)
        {
            offset = new Point(0, 0);
            visibleScreenSize = new Point(gd.DisplayMode.Width - screenEdgeDistance * 2, gd.DisplayMode.Height - screenEdgeDistance * 2);
            screenCenter = new Point(gd.DisplayMode.Width / 2, gd.DisplayMode.Height / 2);
            this.scalingFactorObjects = scalingFactorObjects;
        }

        public void applyKeyState(KeyboardState ks)
        {
            Keys[] keys = ks.GetPressedKeys();
            foreach (Keys key in keys)
            {
                switch (key)
                {
                    case Keys.W:
                        screenCenter.Y -= 5;
                        offset.Y -= 5;
                        break;
                    case Keys.A:
                        screenCenter.X -= 5;
                        offset.X -= 5;
                        break;
                    case Keys.S:
                        screenCenter.Y += 5;
                        offset.Y += 5;
                        break;
                    case Keys.D:
                        screenCenter.X += 5;
                        offset.X += 5;
                        break;
                }
            }
        }
    }
}