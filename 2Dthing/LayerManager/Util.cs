using Microsoft.Xna.Framework;

namespace Layers
{
    public static class Util
    {
        public static Point getNewRecRespectScreenBounds(Rectangle area, Rectangle drawArea)
        {   //top left
            if (area.Top < drawArea.Top && area.Left < drawArea.Left)
            {
                return new Point(drawArea.Left - area.Left, drawArea.Top - area.Top);
            }//top right
            else if (area.Top < drawArea.Top && area.Right > drawArea.Right)
            {
                return new Point(area.Right - drawArea.Right, drawArea.Top - area.Top);
            }//bottom left
            else if (area.Bottom > drawArea.Bottom && area.Left < drawArea.Left)
            {
                return new Point(drawArea.Left - area.Left, area.Bottom - drawArea.Bottom);
            }//botom right
            else if (area.Bottom > drawArea.Bottom && area.Right > drawArea.Right)
            {
                return new Point(area.Right - drawArea.Right, area.Bottom - drawArea.Bottom);
            }//top only
            else if (area.Top < drawArea.Top)
            {
                return new Point(0, drawArea.Top - area.Top);
            }//left only
            else if (area.Left < drawArea.Left)
            {
                return new Point(drawArea.Left - area.Left, 0);
            }//bottom only
            else if (area.Bottom > drawArea.Bottom)
            {
                return new Point(0, area.Bottom - drawArea.Bottom);
            }//right only
            else if (area.Right > drawArea.Right)
            {
                return new Point(area.Right - drawArea.Right, 0);
            }
            return Point.Zero;
        }
    }
}