using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Camera
{
    public class CameraManager
    {
        public Point VisibleScreenSize { get; }
        public Point ScreenCenter { get;}
        public Point Offset { get;}
        public double ScalingFactorObjects { get; }

        /// <summary>
        /// Used in conjucture with Layers.LayerManager to decide what to draw on the screen and where
        /// </summary>
        /// <param name="gd">GraphicsDevice used for determining screensize and center</param>
        /// <param name="screenEdgeDistance">Offset to real screenedge which will not be used</param>
        /// <param name="scalingFactorObjects">Zoom factor</param>
        public CameraManager(GraphicsDevice gd, int screenEdgeDistance, double scalingFactorObjects)
        {
            this.Offset = Point.Zero;
            this.VisibleScreenSize = new Point(gd.DisplayMode.Width - screenEdgeDistance * 2, gd.DisplayMode.Height - screenEdgeDistance * 2);
            this.ScreenCenter = new Point(gd.DisplayMode.Width / 2, gd.DisplayMode.Height / 2);
            this.ScalingFactorObjects = scalingFactorObjects;
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
                        ScreenCenter.Y -= movementSpeed;
                        Offset.Y -= movementSpeed;
                        break;
                    case Keys.A:
                        ScreenCenter.X -= movementSpeed;
                        Offset.X -= movementSpeed;
                        break;
                    case Keys.S:
                        ScreenCenter.Y += movementSpeed;
                        Offset.Y += movementSpeed;
                        break;
                    case Keys.D:
                        ScreenCenter.X += movementSpeed;
                        Offset.X += movementSpeed;
                        break;
                    case Keys.F:
                        ScalingFactorObjects += zoomSpeed;
                        break;
                    case Keys.G:
                        ScalingFactorObjects -= zoomSpeed;
                        if (ScalingFactorObjects < 0)
                            ScalingFactorObjects = 0;
                        break;
                }
            }
        }
    }
}