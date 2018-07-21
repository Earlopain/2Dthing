using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Camera
{
    public class CameraManager
    {
        public Rectangle DrawArea {get;}
        public Point VisibleScreenSize { get; }
        public Point ScreenCenter { get; set; }
        public Point Offset { get; set; }
        public float ZoomFactor { get; set;}

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
            this.ZoomFactor = 1f;
            this.DrawArea = new Rectangle((gd.DisplayMode.Width - this.VisibleScreenSize.X) / 2, (gd.DisplayMode.Height - this.VisibleScreenSize.Y) / 2, this.VisibleScreenSize.X, this.VisibleScreenSize.Y);
        }

        public void ApplyKeyState(KeyboardState keyboardState)
        {
            int movementSpeed = 5;
            float zoomSpeed = 0.03f;
            Keys[] keys = keyboardState.GetPressedKeys();
            foreach (Keys key in keys)
            {
                switch (key)
                {
                    case Keys.W:
                        ScreenCenter = new Point(ScreenCenter.X, ScreenCenter.Y - movementSpeed);
                        Offset = new Point(Offset.X, Offset.Y - movementSpeed);
                        break;
                    case Keys.A:
                        ScreenCenter = new Point(ScreenCenter.X - movementSpeed, ScreenCenter.Y);
                        Offset = new Point(Offset.X - movementSpeed, Offset.Y);
                        break;
                    case Keys.S:
                        ScreenCenter = new Point(ScreenCenter.X, ScreenCenter.Y + movementSpeed);
                        Offset = new Point(Offset.X, Offset.Y + movementSpeed);
                        break;
                    case Keys.D:
                        ScreenCenter = new Point(ScreenCenter.X + movementSpeed, ScreenCenter.Y);
                        Offset = new Point(Offset.X + movementSpeed, Offset.Y);
                        break;
                    case Keys.F:
                        ZoomFactor += zoomSpeed;
                        break;
                    case Keys.G:
                        ZoomFactor -= zoomSpeed;
                        if (ZoomFactor < 0)
                            ZoomFactor = 0.1f;
                        break;
                }
            }
        }
    }
}