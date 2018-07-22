using Microsoft.Xna.Framework;

namespace Layers
{
    public static class Util
    {
        public static Point getDrawingOffset(Rectangle area, Rectangle drawArea)
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

        public static Rectangle getDrawingRectangle(Rectangle drawArea, Rectangle camera, Point offset)
        {
            if (drawArea.Top < camera.Top && drawArea.Left < camera.Left)
            {
                return new Rectangle(drawArea.Location.X + offset.X, drawArea.Location.Y + offset.Y, drawArea.Width - offset.X, drawArea.Height - offset.Y);
            }//top right
            else if (drawArea.Top < camera.Top && drawArea.Right > camera.Right)
            {
                return new Rectangle(drawArea.Location.X, drawArea.Location.Y + offset.Y, drawArea.Width - offset.X, drawArea.Height - offset.Y);
            }//bottom left
            else if (drawArea.Bottom > camera.Bottom && drawArea.Left < camera.Left)
            {
                return new Rectangle(drawArea.Location.X + offset.X, drawArea.Location.Y, drawArea.Width - offset.X, drawArea.Height - offset.Y);
            }//botom right
            else if (drawArea.Bottom > camera.Bottom && drawArea.Right > camera.Right)
            {
                return new Rectangle(drawArea.Location.X, drawArea.Location.Y, drawArea.Width - offset.X, drawArea.Height - offset.Y);
            }//top only
            else if (drawArea.Top < camera.Top)
            {
                return new Rectangle(drawArea.Location.X, drawArea.Location.Y + offset.Y, drawArea.Width, drawArea.Height - offset.Y);
            }//left only
            else if (drawArea.Left < camera.Left)
            {
                return new Rectangle(drawArea.Location.X + offset.X, drawArea.Location.Y, drawArea.Width - offset.X, drawArea.Height);
            }//bottom only
            else if (drawArea.Bottom > camera.Bottom)
            {
                return new Rectangle(drawArea.Location.X, drawArea.Location.Y, drawArea.Width, drawArea.Height - offset.Y);
            }//right only
            else if (drawArea.Right > camera.Right)
            {
                return new Rectangle(drawArea.Location.X, drawArea.Location.Y, drawArea.Width - offset.X, drawArea.Height);
            }
            return Rectangle.Empty;
        }

        public static Rectangle getTexurePart(Point offset, Rectangle area, Rectangle camera)
        {
            if (area.Top < camera.Top && area.Left < camera.Left)
            {
                return new Rectangle(offset.X, offset.Y, area.Width - offset.X, area.Height - offset.Y);
            }//top right
            else if (area.Top < camera.Top && area.Right > camera.Right)
            {
                return new Rectangle(0, offset.Y, area.Width - offset.X, area.Height - offset.Y);
            }//bottom left
            else if (area.Bottom > camera.Bottom && area.Left < camera.Left)
            {
                return new Rectangle(offset.X, 0, area.Width - offset.X, area.Height - offset.Y);
            }//botom right
            else if (area.Bottom > camera.Bottom && area.Right > camera.Right)
            {
                return new Rectangle(0, 0, area.Width - offset.X, area.Height - offset.Y);
            }//top only
            else if (area.Top < camera.Top)
            {
                return new Rectangle(0, offset.Y, area.Width, area.Height - offset.Y);
            }//left only
            else if (area.Left < camera.Left)
            {
                return new Rectangle(offset.X, 0, area.Width - offset.X, area.Height);
            }//bottom only
            else if (area.Bottom > camera.Bottom)
            {
                return new Rectangle(0, 0, area.Width, area.Height - offset.Y);
            }//right only
            else if (area.Right > camera.Right)
            {
                return new Rectangle(0, 0, area.Width - offset.X, area.Height);
            }
            return Rectangle.Empty;
        }
    }
}