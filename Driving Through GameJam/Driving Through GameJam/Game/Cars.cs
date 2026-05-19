using SFML.Graphics;

namespace Driving_Through_GameJam.Game
{
    public class Cars : StaticActor
    {
        public Cars()
        {
            Layer = ELayer.Middle;
            Sprite = new Sprite(new Texture("Data/Textures/car.png"));

            Center();
        }
    }
}