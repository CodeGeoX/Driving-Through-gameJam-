using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Driving_Through_GameJam.Game
{
    public class Background : StaticActor
    {
        private Texture texturaActual;

        public Background()
        {
            Layer = ELayer.Background;
            
            texturaActual = new Texture("Data/Textures/Mapa.png");
            Sprite = new Sprite(texturaActual);
        }

        public void CambiarTextura(string nuevoPath)
        {
            if (texturaActual != null)
            {
                texturaActual.Dispose();
            }

            texturaActual = new Texture(nuevoPath);
            
            Sprite.Texture = texturaActual;
        }

        public override void Update(float dt)
        {
        }
    }
}