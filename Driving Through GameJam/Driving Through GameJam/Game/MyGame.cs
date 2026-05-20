using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Driving_Through_GameJam.Game
{
    public class MyGame : Game
    {
        public Hud hud { private set; get; }
        public Background background { get;  private set;}
        private static MyGame Instance;
        public int nivel;
        public int nivelActual;
        private CarSpawner spawner;
        
        private List<string> rutasMapas = new List<string>()
        {
            "Data/Textures/Map1.png",
            "Data/Textures/Map2.png", 
            "Data/Textures/Map3.png",
            "Data/Textures/Map4.png",
            "Data/Textures/Map5.png"
        };

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
            
            spawner = Engine.Get.Scene.Create<CarSpawner>();
            
            ActualizarTexturaSpawner();

            spawner.SetCarriles(new List<CarSpawner.Carril>
            {
                new (){ Y = 80f,  ToTheRight = true,  Speed = 70f, Interval = 2.5f },
                new(){ Y = 120f, ToTheRight = false,  Speed = 90f, Interval = 2.0f },
                new () { Y = 160f, ToTheRight = true,  Speed = 60f, Interval = 3.0f },
            });
        }
        
        private void ActualizarTexturaSpawner()
        {
            if (spawner == null) return;

            switch (nivelActual)
            {
                case 0:
                    spawner.TexturaCoche = "Data/Textures/Coche.png";
                    break;
                case 1:
                    spawner.TexturaCoche = "Data/Textures/Crab.png";
                    break;
                case 2:
                    spawner.TexturaCoche = "Data/Textures/Ship.png";
                    break;
                case 3:
                    spawner.TexturaCoche = "Data/Textures/Tractor.png";
                    break;
                case 4:
                    spawner.TexturaCoche = "Data/Textures/Rock.png";
                    break;
                default:
                    spawner.TexturaCoche = "Data/Textures/Coche.png";
                    break;
            }
        }
       
        public void DeInit()
        {
            
        }

        public void Update(float dt)
        {
            
        }
        public void AvanzarNivel()
        {
            nivelActual++;
            if (nivelActual >= rutasMapas.Count)
            {
                nivelActual = 0; 
            }

            background.CambiarTextura(rutasMapas[nivelActual]);
    
            DestroyAll<Cars>();
            
            ActualizarTexturaSpawner();
            
            spawner.SetCarriles(new List<CarSpawner.Carril>
            {
                new (){ Y = 80f,  ToTheRight = true,  Speed = 70f, Interval = 2.5f },
                new(){ Y = 120f, ToTheRight = false,  Speed = 90f, Interval = 2.0f },
                new () { Y = 160f, ToTheRight = true,  Speed = 60f, Interval = 3.0f },
            });
        }

        private void DestroyAll<T>() where T : Actor
        {
            var actors = Engine.Get.Scene.GetAll<T>();
            actors.ForEach(x => x.Destroy());
        }
    }
}