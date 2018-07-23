using Microsoft.Xna.Framework;

namespace Layers
{
    public static class Util
    {
        public static Point getDrawingOffset(Rectangle drawArea, Rectangle camera)
        {
            LocationOverlap overlap = getOverlapLocation(drawArea, camera);
            switch (overlap)
            {
                case LocationOverlap.TopLeft:
                    return new Point(camera.Left - drawArea.Left, camera.Top - drawArea.Top);
                case LocationOverlap.TopRight:
                    return new Point(drawArea.Right - camera.Right, camera.Top - drawArea.Top);
                case LocationOverlap.BottomLeft:
                    return new Point(camera.Left - drawArea.Left, drawArea.Bottom - camera.Bottom);
                case LocationOverlap.BottomRight:
                    return new Point(drawArea.Right - camera.Right, drawArea.Bottom - camera.Bottom);
                case LocationOverlap.TopOnly:
                    return new Point(0, camera.Top - drawArea.Top);
                case LocationOverlap.LeftOnly:
                    return new Point(camera.Left - drawArea.Left, 0);
                case LocationOverlap.BottomOnly:
                    return new Point(0, drawArea.Bottom - camera.Bottom);
                case LocationOverlap.RightOnly:
                    return new Point(drawArea.Right - camera.Right, 0);
                default:
                    return Point.Zero;
            }
        }

        public static Rectangle getDrawingRectangle(Rectangle drawArea, Rectangle camera, Point offset)
        {
            LocationOverlap overlap = getOverlapLocation(drawArea, camera);
            switch (overlap)
            {
                case LocationOverlap.TopLeft:
                    return new Rectangle(drawArea.Location.X + offset.X, drawArea.Location.Y + offset.Y, drawArea.Width - offset.X, drawArea.Height - offset.Y);
                case LocationOverlap.TopRight:
                    return new Rectangle(drawArea.Location.X, drawArea.Location.Y + offset.Y, drawArea.Width - offset.X, drawArea.Height - offset.Y);
                case LocationOverlap.BottomLeft:
                    return new Rectangle(drawArea.Location.X + offset.X, drawArea.Location.Y, drawArea.Width - offset.X, drawArea.Height - offset.Y);
                case LocationOverlap.BottomRight:
                    return new Rectangle(drawArea.Location.X, drawArea.Location.Y, drawArea.Width - offset.X, drawArea.Height - offset.Y);
                case LocationOverlap.TopOnly:
                    return new Rectangle(drawArea.Location.X, drawArea.Location.Y + offset.Y, drawArea.Width, drawArea.Height - offset.Y);
                case LocationOverlap.LeftOnly:
                    return new Rectangle(drawArea.Location.X + offset.X, drawArea.Location.Y, drawArea.Width - offset.X, drawArea.Height);
                case LocationOverlap.BottomOnly:
                    return new Rectangle(drawArea.Location.X, drawArea.Location.Y, drawArea.Width, drawArea.Height - offset.Y);
                case LocationOverlap.RightOnly:
                    return new Rectangle(drawArea.Location.X, drawArea.Location.Y, drawArea.Width - offset.X, drawArea.Height);
                default:
                    return drawArea;
            }
        }

        public static Rectangle getTexurePart(Point offset, Rectangle area, Rectangle camera)
        {
            LocationOverlap overlap = getOverlapLocation(area, camera);
            switch (overlap)
            {
                case LocationOverlap.TopLeft:
                    return new Rectangle(offset.X, offset.Y, area.Width - offset.X, area.Height - offset.Y);
                case LocationOverlap.TopRight:
                    return new Rectangle(0, offset.Y, area.Width - offset.X, area.Height - offset.Y);
                case LocationOverlap.BottomLeft:
                    return new Rectangle(offset.X, 0, area.Width - offset.X, area.Height - offset.Y);
                case LocationOverlap.BottomRight:
                    return new Rectangle(0, 0, area.Width - offset.X, area.Height - offset.Y);
                case LocationOverlap.TopOnly:
                    return new Rectangle(0, offset.Y, area.Width, area.Height - offset.Y);
                case LocationOverlap.LeftOnly:
                    return new Rectangle(offset.X, 0, area.Width - offset.X, area.Height);
                case LocationOverlap.BottomOnly:
                    return new Rectangle(0, 0, area.Width, area.Height - offset.Y);
                case LocationOverlap.RightOnly:
                    return new Rectangle(0, 0, area.Width - offset.X, area.Height);
                default:
                    return new Rectangle(0, 0, area.Width, area.Height);
            }
        }

        public static LocationOverlap getOverlapLocation(Rectangle drawArea, Rectangle camera)
        {
            if (drawArea.Top < camera.Top && drawArea.Left < camera.Left)
                return LocationOverlap.TopLeft;
            else if (drawArea.Top < camera.Top && drawArea.Right > camera.Right)
                return LocationOverlap.TopRight;
            else if (drawArea.Bottom > camera.Bottom && drawArea.Left < camera.Left)
                return LocationOverlap.BottomLeft;
            else if (drawArea.Bottom > camera.Bottom && drawArea.Right > camera.Right)
                return LocationOverlap.BottomRight;
            else if (drawArea.Top < camera.Top)
                return LocationOverlap.TopOnly;
            else if (drawArea.Left < camera.Left)
                return LocationOverlap.LeftOnly;
            else if (drawArea.Bottom > camera.Bottom)
                return LocationOverlap.BottomOnly;
            else if (drawArea.Right > camera.Right)
                return LocationOverlap.RightOnly;
            return LocationOverlap.None;
        }
    }
}