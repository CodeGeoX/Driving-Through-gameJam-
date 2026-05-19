using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System;

namespace TcGame
{
    public class Player : StaticActor
    {
        Random alea = new Random();
        Vector2f Target;
        private float coolDown = 3;
        public Player()
        {
      
            Layer = ELayer.Middle;
      
            int skin = alea.Next(1, 4);
      
            switch (skin)
            {
                case 1:
                    Sprite = new Sprite(new Texture("Data/Textures/rui1.png"));
                    break;
                case 2:
                    Sprite = new Sprite(new Texture("Data/Textures/rui2.png"));
                    break;
                case 3:
                    Sprite = new Sprite(new Texture("Data/Textures/rui3.png"));
                    break;
                default:
                    break;
            }
            Center();
            Position = new Vector2f(780.0f, 350.0f);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            Forward = (Engine.Get.MousePos - Position).Normal();
            Rotation = (float) Math.Atan2(Forward.Y, Forward.X) * MathUtil.RAD2DEG;
      
            
      
      
        }
    
    }
}