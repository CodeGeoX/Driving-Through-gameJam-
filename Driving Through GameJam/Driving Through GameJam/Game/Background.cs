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

        // Cuando pasamos de nivel se pasa el nuevo path
        public void CambiarTextura(string nuevoPath)
        {
            Sprite.Texture = new Texture(nuevoPath);
        }

        public override void Update(float dt)
        {
        }
    }
}