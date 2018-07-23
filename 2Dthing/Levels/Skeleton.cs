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
        public int Rows;
        public int Columns;

        public Element(int X, int Y, string Name, string Type, int Rows, int Columns)
        {
            this.Name = Name;
            this.Type = Type;
            this.Position = new Point(X, Y);
            this.Rows = Rows;
            this.Columns = Columns;
        }
    }
}