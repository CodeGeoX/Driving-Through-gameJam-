using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System;

namespace Driving_Through_GameJam.Game
{
    public class Player : StaticActor
    {
        private bool wAnterior = false;
        private bool sAnterior = false;
        private bool aAnterior = false;
        private bool dAnterior = false;
        private float Velocity = 300;
        
        public bool GameOver { get; private set; } = false;
        public bool Victoria { get; private set; } = false; 

        private RenderTexture lienzoCartel; 
        private Font fuente;
        private Text textMensaje;

        public Player()
        {
            Layer = ELayer.Middle;
            Sprite = new Sprite(new Texture("Data/Textures/Player_normal.png"));
            Center();
            ResetearPosicion();
            
            Forward = new Vector2f(0, -1);
        }

        private void ResetearPosicion()
        {
            FloatRect limitesFondo = MyGame.Get.background.Sprite.GetGlobalBounds();

            float x = limitesFondo.Width / 2f;
            float y = limitesFondo.Height - (Sprite.GetGlobalBounds().Height / 2f);
            
            Position = new Vector2f(x, y);
        }

        private bool CheckCollision()
        {
            if (GameOver || Victoria) return true;

            FloatRect limitesReales = GetGlobalBounds();
            // hitbox del personaje
            float nuevoAncho = limitesReales.Width * 0.15f;
            float nuevoAlto = limitesReales.Height * 0.15f;

            float nuevaX = limitesReales.Left + (limitesReales.Width - nuevoAncho) / 2f;
            float nuevaY = limitesReales.Top + (limitesReales.Height - nuevoAlto) / 2f;

            FloatRect hitboxReducida = new FloatRect(nuevaX, nuevaY, nuevoAncho, nuevoAlto);

            foreach (Cars cars in Engine.Get.Scene.GetAll<Cars>())
            {
                if (hitboxReducida.Intersects(cars.GetGlobalBounds()))
                {
                    ActivarGameOver();
                    return true;
                }
            }
            return false;
        }

        public void ActivarGameOver()
        {
            GameOver = true;
            ConfigurarCartelFin("GAME OVER", Color.Red);
        }

        public void ActivarVictoria()
        {
            Victoria = true;
            ConfigurarCartelFin("HAS GANADO!", new Color(255, 215, 0)); 
        }

        private void ConfigurarCartelFin(string titulo, Color colorTexto)
        {
            FloatRect limitesFondo = MyGame.Get.background.Sprite.GetGlobalBounds();
            Position = new Vector2f(limitesFondo.Width / 2f, limitesFondo.Height / 2f);

            lienzoCartel = new RenderTexture(400, 150);
            fuente = new Font("Data/guru.otf");
            
            string mensajeFinal = titulo + "\nPuntos: " + MyGame.Get.points;

            textMensaje = new Text(mensajeFinal, fuente, 35);
            textMensaje.Style = Text.Styles.Bold;
            textMensaje.FillColor = colorTexto;
            textMensaje.Position = new Vector2f(85f, 20f); 

            lienzoCartel.Clear(new Color(0, 0, 0, 220)); 
            lienzoCartel.Draw(textMensaje);
            lienzoCartel.Display();

            Sprite = new Sprite(lienzoCartel.Texture);
            Sprite.Origin = new Vector2f(200f, 75f);
            
            var actors = Engine.Get.Scene.GetAll<Cars>();
            actors.ForEach(x => x.Destroy());
        }

        public override void Update(float dt)
        {
            if (GameOver || Victoria) return;
            if (CheckCollision()) return;

            bool wAhora = Keyboard.IsKeyPressed(Keyboard.Key.W);
            bool sAhora = Keyboard.IsKeyPressed(Keyboard.Key.S);
            bool aAhora = Keyboard.IsKeyPressed(Keyboard.Key.A);
            bool dAhora = Keyboard.IsKeyPressed(Keyboard.Key.D);

            base.Update(dt);
            if (wAnterior && !wAhora)
            {
                Forward = new Vector2f(0, -1);
                Position = Position + Forward * Velocity * dt;
                MyGame.Get.points++;
            }
            if (sAnterior && !sAhora)
            {
                Forward = new Vector2f(0, 1);
                Position = Position + Forward * Velocity * dt;
                MyGame.Get.points--;
            }
            if (aAnterior && !aAhora)
            {
                Forward = new Vector2f(-1, 0);
                Position = Position + Forward * Velocity * dt;
            }
            if (dAnterior && !dAhora)
            {
                Forward = new Vector2f(1, 0);
                Position = Position + Forward * Velocity * dt;
            }
            wAnterior = wAhora;
            sAnterior = sAhora;
            aAnterior = aAhora;
            dAnterior = dAhora;
            
            if (Position.Y <= 0)
            { 
                if (MyGame.Get.lastlevel)
                {
                    ActivarVictoria();
                }
                else 
                {
                    ResetearPosicion();
                    MyGame.Get.AvanzarNivel();
                }
            }
        }
    }
}