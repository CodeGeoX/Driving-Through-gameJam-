using SFML.Graphics;
using SFML.System;
using System;

namespace Driving_Through_GameJam.Game
{
    public class Hud : StaticActor
    {
        private Text textContador;
        private Text textPuntuacion; 
        private Font fuente;
        private float tiempoRestante = 80f;
        private RenderTexture lienzoTexto; 
        private float escalaHud = 0.5f; 

        public Hud()
        {
            Layer = ELayer.Middle;
            fuente = new Font("Data/guru.otf");
            
            textContador = new Text("Tiempo: 80", fuente);
            textContador.CharacterSize = 30;
            textContador.Style = Text.Styles.Bold;
            textContador.FillColor = Color.White;
            textContador.Position = new Vector2f(0f, 0f); 

            textPuntuacion = new Text("Puntos: 0", fuente);
            textPuntuacion.CharacterSize = 22; 
            textPuntuacion.Style = Text.Styles.Bold;
            textPuntuacion.FillColor = new Color(255, 215, 0); 
            textPuntuacion.Position = new Vector2f(0f, 40f);

            lienzoTexto = new RenderTexture(250, 90); 
            Sprite = new Sprite(lienzoTexto.Texture);
            Sprite.Scale = new Vector2f(escalaHud, escalaHud);

            Position = new Vector2f(20f, 20f);
            
            ActualizarLienzo();
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            var listaJugadores = Engine.Get.Scene.GetAll<Player>();
            if (listaJugadores.Count > 0)
            {
                Player jugador = listaJugadores[0];
                
                if (jugador.GameOver || jugador.Victoria) return;

                if (tiempoRestante > 0)
                {
                    tiempoRestante -= dt;
                    if (tiempoRestante <= 0)
                    {
                        tiempoRestante = 0;
                        jugador.ActivarGameOver();
                    }
                    
                    textContador.DisplayedString = "Tiempo: " + Math.Ceiling(tiempoRestante).ToString();
                }
            }

            textPuntuacion.DisplayedString = "Puntos: " + MyGame.Get.points.ToString();

            ActualizarLienzo();
        }

        private void ActualizarLienzo()
        {
            lienzoTexto.Clear(Color.Transparent); 
            
            lienzoTexto.Draw(textContador);       
            lienzoTexto.Draw(textPuntuacion); 
            
            lienzoTexto.Display();                
        }
    }
}