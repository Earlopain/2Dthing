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
        /// <summary>
        /// Returns a LayerManager containing all needed info needed for it
        /// </summary>
        /// <param name="level">String representation of the level name</param>
        /// <param name="graphicsDevice">Used to draw sprites on the screen</param>
        /// <param name="content">Used to load sprites from disk</param>
        /// <returns></returns>
        public static LayerManager LoadLevel(string level, GraphicsDevice graphicsDevice, ContentManager content)
        {   //load json from disk
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
                    else if (element.Type == "Animated")
                    {
                        if (element.Rows == 0 || element.Columns == 0)
                            throw new Exception("Animation must have rows and columns which are not 0: " + element.Name + " " + element.Position.ToString());
                        currentLayer.AddAnimatedSprite(texture, new Point(element.Position.X, element.Position.Y), 1, 2);
                    }

                    else
                        currentLayer.AddStaticSprite(texture, new Point(element.Position.X, element.Position.Y));
                }
            }
            return result;
        }

        public static LayerManager MakeTemp(GraphicsDevice graphicsDevice, ContentManager content)
        {
            LayerManager result = new LayerManager(graphicsDevice, content);
            //bottom right
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), 0, 0);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), 25, 25);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), 50, 50);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), 75, 75);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), 125, 125);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), 150, 150);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), 175, 175);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), 200, 200);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), 250, 250);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), 300, 300);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), 350, 350);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), 400, 400);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), 450, 450);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), 500, 500);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), 550, 550);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), 600, 600);
            //top right
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), 0, 0);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), 25, -25);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), 50, -50);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), 75, -75);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), 125, -125);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), 150, -150);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), 175, -175);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), 200, -200);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), 250, -250);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), 300, -300);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), 350, -350);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), 400, -400);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), 450, -450);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), 500, -500);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), 550, -550);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), 600, -600);
            //bottom left
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), 0, 0);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), -25, 25);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), -50, 50);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), -75, 75);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), -125, 125);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), -150, 150);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), -175, 175);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), -200, 200);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), -250, 250);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), -300, 300);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), -350, 350);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), -400, 400);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), -450, 450);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), -500, 500);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), -550, 550);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), -600, 600);
            //top left
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), 0, 0);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), -25, -25);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), -50, -50);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), -75, -75);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), -125, -125);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), -150, -150);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), -175, -175);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), -200, -200);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), -250, -250);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), -300, -300);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), -350, -350);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), -400, -400);
            result.GetLayer(1).AddStaticSprite(content.Load<Texture2D>("Layer1"), -450, -450);
            result.GetLayer(2).AddStaticSprite(content.Load<Texture2D>("Layer2"), -500, -500);
            result.GetLayer(0).AddStaticSprite(content.Load<Texture2D>("Layer0"), -550, -550);
            result.GetLayer(-1).AddStaticSprite(content.Load<Texture2D>("Layer-1"), -600, -600);
            return result;
        }
    }
}