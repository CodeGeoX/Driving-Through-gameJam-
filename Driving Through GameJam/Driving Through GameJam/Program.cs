using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
class MainClass
{
    public static void Main(string[] args)
    {
        VideoMode v = new VideoMode(640, 480);
        RenderWindow rw = new RenderWindow(v, "Minimal SFML");

        int points  = 0;
        int stepLength = 5;
        int position = 0;
        int maxPoint = 0;
        
        CircleShape sh = new CircleShape();
        sh.Radius = 20f;
		sh.Position = new Vector2f(320, 450);
        sh.FillColor = Color.White;

        Font f = new Font("Data/guru.otf");
		Text tx = new Text("Distance: "+points, f);
        tx.Style = Text.Styles.Bold;
        tx.FillColor = Color.White;

        Clock clock = new Clock();
        float moveCooldown = 0.15f;
        float timeSinceMove = 0f;

        while (rw.IsOpen)
        {
            float dt = clock.Restart().AsSeconds();
            timeSinceMove += dt;

            rw.DispatchEvents();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                rw.Close();
            } else if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && timeSinceMove >= moveCooldown)
            {
                position += stepLength;
                sh.Position = new Vector2f(320, 450-position);
                timeSinceMove = 0f;

                 if (position > maxPoint)
                {
                    maxPoint = position;
                    points++;
                    tx.DisplayedString = "Distance: " + points;
                }

                tx = new Text("Distance: "+points, f);

            } else if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && timeSinceMove >= moveCooldown)
            {   
                position -= stepLength;
                sh.Position = new Vector2f(320, (450-position)+stepLength);
                timeSinceMove = 0f;
            }

            rw.Clear();
            rw.Draw(sh);
            rw.Draw(tx);
            rw.Display();
        }
    }
}