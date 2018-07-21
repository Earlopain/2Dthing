using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using Newtonsoft.Json;

using Layers;


namespace Level
{
    public class LevelParser
    {

        public static LayerManager LoadLevel(string level, ContentManager Content)
        {
            string jsonString = System.IO.File.ReadAllText(Content.RootDirectory + "/Levels/" + level + ".lvl");
            System.IO.File.WriteAllText(Content.RootDirectory + "/Levels/" + level + ".read", jsonString);
            System.Console.WriteLine(jsonString);
            return null;
        }

        public static void MakeTemp(LayerManager LayerManager, ContentManager Content)
        {
            //bottom right
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 0, 0);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 25, 25);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 50, 50);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 75, 75);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 125, 125);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 150, 150);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 175, 175);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 200, 200);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 250, 250);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 300, 300);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 350, 350);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 400, 400);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 450, 450);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 500, 500);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 550, 550);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 600, 600);
            //top right
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 0, 0);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 25, -25);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 50, -50);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 75, -75);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 125, -125);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 150, -150);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 175, -175);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 200, -200);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 250, -250);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 300, -300);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 350, -350);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 400, -400);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), 450, -450);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), 500, -500);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 550, -550);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), 600, -600);
            //bottom left
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 0, 0);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), -25, 25);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), -50, 50);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), -75, 75);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), -125, 125);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), -150, 150);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), -175, 175);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), -200, 200);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), -250, 250);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), -300, 300);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), -350, 350);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), -400, 400);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), -450, 450);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), -500, 500);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), -550, 550);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), -600, 600);
            //top left
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), 0, 0);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), -25, -25);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), -50, -50);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), -75, -75);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), -125, -125);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), -150, -150);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), -175, -175);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), -200, -200);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), -250, -250);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), -300, -300);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), -350, -350);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), -400, -400);
            LayerManager.GetLayer(1).addTexture2D(Content.Load<Texture2D>("Layer1"), -450, -450);
            LayerManager.GetLayer(2).addTexture2D(Content.Load<Texture2D>("Layer2"), -500, -500);
            LayerManager.GetLayer(0).addTexture2D(Content.Load<Texture2D>("Layer0"), -550, -550);
            LayerManager.GetLayer(-1).addTexture2D(Content.Load<Texture2D>("Layer-1"), -600, -600);
        }
    }
}