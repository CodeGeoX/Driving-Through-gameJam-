using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Driving_Through_GameJam.Game
{
    public class MyGame : Game
    {
        public Hud hud { private set; get; }
        public Background background { get;  private set;}
        private static MyGame Instance;
        public static MyGame Get
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new MyGame();
                }

                return Instance;
            }
        }
        private MyGame()
        {
        }
        public void Init()
        {
            background = Engine.Get.Scene.Create<Background>();
            Player p = Engine.Get.Scene.Create<Player>();
      
        }
       
        public void DeInit()
        {
            Player p = Engine.Get.Scene.Create<Player>();
        }
        public void Update(float dt)
        {
      
        }
        private void DestroyAll<T>() where T : Actor
        {
            var actors = Engine.Get.Scene.GetAll<T>();
            actors.ForEach(x => x.Destroy());
        }
    }
}