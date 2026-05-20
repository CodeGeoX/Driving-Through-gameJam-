using SFML.Graphics;
using SFML.System;
using System;

namespace Driving_Through_GameJam.Game;

public class Cars : StaticActor
{
    private const float SpawnOffset = 20f;

    private float _fadeDuration = 0.4f;
    private float _fadeTimer = 0f;
    private bool _isFadingIn = true;
    private bool GameOver = false;
    
    private Texture _texturaPropia;

    public Cars()
    {
        Layer = ELayer.Middle;
        Sprite = new Sprite();
        Center();

        Sprite.Color = new Color(255, 255, 255, 0);
    }

    public override void Update(float dt)
    {
        base.Update(dt); 

        if (_isFadingIn) 
        {
            _fadeTimer += dt;
            float t = Math.Min(_fadeTimer / _fadeDuration, 1f);
            byte alpha = (byte)(t * 255);
            Sprite.Color = new Color(255, 255, 255, alpha);
            if (t >= 1f) _isFadingIn = false;
        }

        FloatRect limitesFondo = MyGame.Get.background.Sprite.GetGlobalBounds();
        float anchoMapa = limitesFondo.Width;
        float altoMapa = limitesFondo.Height;

        float x = Position.X;
        float y = Position.Y;

        if (x < -SpawnOffset * 4 || x > anchoMapa + SpawnOffset * 4 ||
            y < -SpawnOffset * 4 || y > altoMapa + SpawnOffset * 4)
        {
            Destroy();
        }
        
        CheckCollision();
    }

    private void CheckCollision()
    {
        foreach (Player player in Engine.Get.Scene.GetAll<Player>())
        {
            if (GetGlobalBounds().Intersects(player.GetGlobalBounds()))
            {
                if (!GameOver) 
                {
                    Console.WriteLine("DERROTA");
                    GameOver = true;
                }
            }
        }
    }
    
    public void SetTexture(string texturePath)
    {
        if (_texturaPropia != null)
        {
            _texturaPropia.Dispose();
        }

        _texturaPropia = new Texture(texturePath);
        Sprite.Texture = _texturaPropia;
        Center();
    }
}