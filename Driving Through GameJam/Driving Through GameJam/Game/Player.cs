using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System;

namespace Driving_Through_GameJam.Game
{
    public class Player : StaticActor
    {
        Random alea = new Random();
        Vector2f Target;
        private float coolDown = 3;
        public Player()
        {
      
            Layer = ELayer.Middle;
      
            
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