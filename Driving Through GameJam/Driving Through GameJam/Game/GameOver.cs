using SFML.Graphics;
using SFML.System;

namespace Driving_Through_GameJam.Game
{
    public class GameOver : StaticActor
    {
        private Text textGameOver;
        private Text textPuntosFinales;
        private Font fuente;
        private RenderTexture lienzo;

        public GameOver()
        {
            Layer = ELayer.Middle; 
            fuente = new Font("Data/guru.otf");

            textGameOver = new Text("GAME OVER", fuente, 45);
            textGameOver.Style = Text.Styles.Bold;
            textGameOver.FillColor = Color.Red;
            textGameOver.Position = new Vector2f(75f, 30f); 

            int puntuacionFinal = MyGame.Get.points;
            textPuntosFinales = new Text("Puntuacion Final: " + puntuacionFinal, fuente, 25);
            textPuntosFinales.Style = Text.Styles.Bold;
            textPuntosFinales.FillColor = Color.White;
            textPuntosFinales.Position = new Vector2f(85f, 110f);

            lienzo = new RenderTexture(400, 200);
            Sprite = new Sprite(lienzo.Texture);
            
            Sprite.Origin = new Vector2f(200f, 100f); 

            FloatRect limitesFondo = MyGame.Get.background.Sprite.GetGlobalBounds();
            Position = new Vector2f(limitesFondo.Width / 2f, limitesFondo.Height / 2f);

            DibujarLienzo();
        }

        private void DibujarLienzo()
        {
            lienzo.Clear(new Color(0, 0, 0, 180)); 
    
            lienzo.Draw(textGameOver);
            lienzo.Draw(textPuntosFinales);
            lienzo.Display();
        }
    }
}