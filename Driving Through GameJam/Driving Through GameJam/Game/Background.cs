using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TcGame
{
    public class Background : StaticActor
    {
        public Background()
        {
            Layer = ELayer.Background;
            Sprite = new Sprite(new Texture("Data/Textures/mapa.png"));
        }
        public override void Update(float dt)
        {
        }
  
    }
}