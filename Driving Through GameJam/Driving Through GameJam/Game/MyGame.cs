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
        private int nivel;
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

            CarSpawner spawner = Engine.Get.Scene.Create<CarSpawner>();
            switch (nivel)
            {
                case 1:
                    spawner.TexturaCoche = "Data/Textures/Coche.png";
                    break;
                case 2:
                    spawner.TexturaCoche = "Data/Textures/Coche.png";
                    break;
                case 3:
                    spawner.TexturaCoche = "Data/Textures/Coche.png";
                    break;
                case 4:
                    spawner.TexturaCoche = "Data/Textures/Coche.png";
                    break;
                case 5:
                    spawner.TexturaCoche = "Data/Textures/Coche.png";
                    break;
                default:
                    spawner.TexturaCoche = "Data/Textures/Coche.png";
                    break;
            }
            spawner.SetCarriles(new List<CarSpawner.Carril>
            {
                new (){ Y = 80f,  ToTheRight = true,  Speed = 70f, Interval = 2.5f },
                new(){ Y = 120f, ToTheRight = false,  Speed = 90f, Interval = 2.0f },
                new () { Y = 160f, ToTheRight = true,  Speed = 60f, Interval = 3.0f },
            });
      
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