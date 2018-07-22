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
        public string Type;

        public Element(int x, int y, string name, string type)
        {
            this.Name = name;
            this.Type = type;
            this.Position = new Point(x, y);
        }
    }
}