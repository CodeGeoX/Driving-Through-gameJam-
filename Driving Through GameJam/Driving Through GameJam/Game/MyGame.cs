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

        private int nivelActual = 0;
        
        private List<string> rutasMapas = new List<string>()
        {
            "Data/Textures/Mapa.png",
            "Data/Textures/Player_jump.png", 
            "Data/Textures/Mapa3.png"
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
        }

        private void DestroyAll<T>() where T : Actor
        {
            var actors = Engine.Get.Scene.GetAll<T>();
            actors.ForEach(x => x.Destroy());
        }
    }
}