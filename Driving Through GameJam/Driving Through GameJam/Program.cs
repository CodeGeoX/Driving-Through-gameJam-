using Driving_Through_GameJam;

namespace TcGame

{
    using SFML.Graphics;
    using SFML.Window;
    using SFML.System;
    public class Program
    {
        public static void Main()
        {
            VideoMode v = new VideoMode(640*2, 480*2);
            RenderWindow rw = new RenderWindow(v, "Sprite Sample");
            
            Engine.Initialize();
            
            while (rw.IsOpen)
            {
                Engine.Get.Scene.Create<Player>();
            }
        }
    }
}