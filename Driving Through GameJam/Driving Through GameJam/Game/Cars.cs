
using SFML.Graphics;
using SFML.System;

namespace Driving_Through_GameJam.Game;

public class Cars: StaticActor
{
    private const float SpawnOffset = 20f;
 
    // Tiempo de fade-in en segundos (0 = sin fade)
    private float _fadeDuration = 0.4f;
    private float _fadeTimer = 0f;
    private bool _isFadingIn = true;
    public Cars()
    {
        Layer = ELayer.Middle;
        Sprite = new Sprite();
        Center();
 
        
        Sprite.Color = new Color(255, 255, 255, 0);//color transparente
        
    }
    public override void Update(float dt)
    {
        base.Update(dt); //mueve el coche según forward y speed
 
       
        if (_isFadingIn) //fade-in o algo asi,el efecto para que los coches aparezcan por la banda de la pantalla(si no queda rarete)
        {
            _fadeTimer += dt;
            float t = Math.Min(_fadeTimer / _fadeDuration, 1f);
            byte alpha = (byte)(t * 255);
            Sprite.Color = new Color(255, 255, 255, alpha);
            if (t >= 1f) _isFadingIn = false;
        }
        
        Vector2u windowSize = Engine.Get.Window.Size;
        float x = Position.X;
        float y = Position.Y;

        if (x < -SpawnOffset * 2 || x > windowSize.X + SpawnOffset * 2 || y < -SpawnOffset * 2 || y > windowSize.Y + SpawnOffset * 2)
        {
            Destroy();
        }
    }
    public void SetTexture(string texturePath)
    {
        Sprite.Texture = new Texture(texturePath);
        Center();
    }
    
    
}