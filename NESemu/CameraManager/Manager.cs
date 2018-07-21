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

        /// <summary>
        /// Used in conjucture with Layers.LayerManager to decide what to draw on the screen and where
        /// </summary>
        /// <param name="gd">GraphicsDevice used for determining screensize and center</param>
        /// <param name="screenEdgeDistance">Offset to real screenedge which will not be used</param>
        /// <param name="scalingFactorObjects">Zoom factor</param>
        public CameraManager(GraphicsDevice gd, int screenEdgeDistance, double scalingFactorObjects)
        {
            offset = new Point(0, 0);
            visibleScreenSize = new Point(gd.DisplayMode.Width - screenEdgeDistance * 2, gd.DisplayMode.Height - screenEdgeDistance * 2);
            screenCenter = new Point(gd.DisplayMode.Width / 2, gd.DisplayMode.Height / 2);
            this.scalingFactorObjects = scalingFactorObjects;
        }

        public void applyKeyState(KeyboardState ks)
        {
            int movementSpeed = 5;
            double zoomSpeed = 0.1;
            Keys[] keys = ks.GetPressedKeys();
            foreach (Keys key in keys)
            {
                switch (key)
                {
                    case Keys.W:
                        screenCenter.Y -= movementSpeed;
                        offset.Y -= movementSpeed;
                        break;
                    case Keys.A:
                        screenCenter.X -= movementSpeed;
                        offset.X -= movementSpeed;
                        break;
                    case Keys.S:
                        screenCenter.Y += movementSpeed;
                        offset.Y += movementSpeed;
                        break;
                    case Keys.D:
                        screenCenter.X += movementSpeed;
                        offset.X += movementSpeed;
                        break;
                    case Keys.F:
                        scalingFactorObjects += zoomSpeed;
                        break;
                    case Keys.G:
                        scalingFactorObjects -= zoomSpeed;
                        if (scalingFactorObjects < 0)
                            scalingFactorObjects = 0;
                        break;
                }
            }
        }
    }
}