using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Layers;
using GameState;


namespace Level
{
    public class LevelParser
    {

        public static LayerManager LoadLevel(string level, GraphicsDevice graphicsDevice, ContentManager content)
        {
            string jsonString = System.IO.File.ReadAllText(content.RootDirectory + "/Levels/" + level + ".json");
            LayerManager result = new LayerManager(graphicsDevice, content);
            Skeleton json = JsonConvert.DeserializeObject<Skeleton>(jsonString);
            List<Texture2D> currentlyLoaded = new List<Texture2D>();
            List<string> textureNames = new List<string>();
            foreach (Layer layer in json.Layers)
            {
                var currentLayer = result.GetLayer(layer.Depth);
                foreach (Element element in layer.Elements)
                {
                    Texture2D texture;
                    if (!textureNames.Contains(element.Name))
                    {
                        texture = content.Load<Texture2D>(element.Name);
                    }
                    else
                        texture = currentlyLoaded.Find(textureTemp => textureTemp.Name == element.Name);
                    if (element.Type == "Player")
                        result.Player = new Player(texture, layer.Depth, element.Position);
                    else
                        currentLayer.AddStaticSprite(texture, new Point(element.Position.X, element.Position.Y));
                }
            }
            return result;
        }

        public static void MakeTemp(LayerManager LayerManager, ContentManager Content)
        {
            //bottom right
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), 0, 0);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), 25, 25);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), 50, 50);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), 75, 75);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), 125, 125);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), 150, 150);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), 175, 175);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), 200, 200);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), 250, 250);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), 300, 300);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), 350, 350);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), 400, 400);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), 450, 450);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), 500, 500);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), 550, 550);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), 600, 600);
            //top right
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), 0, 0);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), 25, -25);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), 50, -50);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), 75, -75);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), 125, -125);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), 150, -150);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), 175, -175);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), 200, -200);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), 250, -250);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), 300, -300);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), 350, -350);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), 400, -400);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), 450, -450);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), 500, -500);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), 550, -550);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), 600, -600);
            //bottom left
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), 0, 0);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), -25, 25);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), -50, 50);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), -75, 75);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), -125, 125);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), -150, 150);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), -175, 175);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), -200, 200);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), -250, 250);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), -300, 300);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), -350, 350);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), -400, 400);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), -450, 450);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), -500, 500);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), -550, 550);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), -600, 600);
            //top left
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), 0, 0);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), -25, -25);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), -50, -50);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), -75, -75);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), -125, -125);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), -150, -150);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), -175, -175);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), -200, -200);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), -250, -250);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), -300, -300);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), -350, -350);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), -400, -400);
            LayerManager.GetLayer(1).AddStaticSprite(Content.Load<Texture2D>("Layer1"), -450, -450);
            LayerManager.GetLayer(2).AddStaticSprite(Content.Load<Texture2D>("Layer2"), -500, -500);
            LayerManager.GetLayer(0).AddStaticSprite(Content.Load<Texture2D>("Layer0"), -550, -550);
            LayerManager.GetLayer(-1).AddStaticSprite(Content.Load<Texture2D>("Layer-1"), -600, -600);
        }
    }
}