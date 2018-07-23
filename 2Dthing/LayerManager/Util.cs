using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Layers
{
    public static class Util
    {
        public static Point getDrawingOffset(Rectangle drawArea, Rectangle camera, LocationOverlap overlap)
        {
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

        public static Rectangle getDrawingRectangle(Rectangle drawArea, Rectangle camera)
        {
            return Rectangle.Intersect(drawArea, camera);
        }

        public static Rectangle getTexurePart(Rectangle area, Rectangle camera, Point offset, LocationOverlap overlap, float zoomFactor)
        {
            return getTexurePart(area, camera, offset, overlap, new Rectangle(0, 0, area.Width, area.Height), zoomFactor);
        }

        public static Rectangle getTexurePart(Rectangle area, Rectangle camera, Point offset, LocationOverlap overlap, Rectangle sourceRectangle, float zoomFactor)
        {
            Rectangle result;
            Point size = new Point((int)((area.Width - offset.X) * zoomFactor), (int)((area.Height - offset.Y) * zoomFactor));
            switch (overlap)
            {
                case LocationOverlap.TopLeft:
                    result = new Rectangle((int)(offset.X * zoomFactor), (int)(offset.Y * zoomFactor), size.X, size.Y);
                    break;
                case LocationOverlap.TopRight:
                    result = new Rectangle(0, (int)(offset.Y * zoomFactor), size.X, size.Y);
                    break;
                case LocationOverlap.BottomLeft:
                    result = new Rectangle((int)(offset.X * zoomFactor), 0, size.X, size.Y);
                    break;
                case LocationOverlap.BottomRight:
                    result = new Rectangle(0, 0, size.X, size.Y);
                    break;
                case LocationOverlap.TopOnly:
                    result = new Rectangle(0, (int)(offset.Y * zoomFactor), size.X, size.Y);
                    break;
                case LocationOverlap.LeftOnly:
                    result = new Rectangle((int)(offset.X * zoomFactor), 0, size.X, size.Y);
                    break;
                case LocationOverlap.BottomOnly:
                    result = new Rectangle(0, 0, size.X, size.Y);
                    break;
                case LocationOverlap.RightOnly:
                    result = new Rectangle(0, 0, size.X, size.Y);
                    break;
                default:
                    result = new Rectangle(0, 0, size.X, size.Y);
                    break;
            }
            //Apply the Texture offset if texture is multiframe
            result.Offset(sourceRectangle.Location);
            return result;
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