using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Driving_Through_GameJam.Game
{
    public class Background : StaticActor
    {
        public Background()
        {
            Layer = ELayer.Background;
            Sprite = new Sprite(new Texture("Data/Textures/Mapa.png"));
            
        }
        public override void Update(float dt)
        {
        }
  
    }
}