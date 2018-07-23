using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using Camera;

namespace Sprites
{
    public interface ISpriteInterface
    {
        Texture2D Texture { get; }
        Point Position { get; }
        int Rows { get; }
        int Columns { get; }
        void Draw(SpriteBatch spriteBatch, Rectangle area, CameraManager camera);
    }

    public class DrawInformation
    {
        Point Offset;
        public Rectangle DrawLocation;
        public Rectangle TexturePart;
        public DrawInformation(Rectangle area, CameraManager camera)
        {
            Layers.LocationOverlap overlap = Layers.Util.getOverlapLocation(area, camera.DrawArea);
            this.Offset = Layers.Util.getDrawingOffset(area, camera.DrawArea, overlap);
            this.DrawLocation = Layers.Util.getDrawingRectangle(area, camera.DrawArea, this.Offset, overlap);
            this.TexturePart = Layers.Util.getTexurePart(area, camera.DrawArea, this.Offset, overlap, camera.ZoomFactor);
        }

        public DrawInformation(Rectangle area, CameraManager camera, Rectangle sourceRectangle)
        {
            Layers.LocationOverlap overlap = Layers.Util.getOverlapLocation(area, camera.DrawArea);
            this.Offset = Layers.Util.getDrawingOffset(area, camera.DrawArea, overlap);
            this.DrawLocation = Layers.Util.getDrawingRectangle(area, camera.DrawArea, this.Offset, overlap);
            this.TexturePart = Layers.Util.getTexurePart(area, camera.DrawArea, this.Offset, overlap, sourceRectangle, camera.ZoomFactor);
        }
    }
}