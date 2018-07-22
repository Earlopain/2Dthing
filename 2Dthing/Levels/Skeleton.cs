using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;



namespace Level
{
    public class Skeleton
    {
        public List<Layer> Layers;
    }

    public class Layer
    {
        public int Depth;
        public List<Element> Elements;
    }

    public class Element
    {
        public Point Position;
        public string Name;

        public Element(int x, int y, string name)
        {
            this.Name = name;
            this.Position = new Point(x, y);
        }
    }
}