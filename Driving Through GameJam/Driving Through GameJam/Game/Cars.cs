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
    
    // CORRECCIÓN: Guardamos la referencia aquí para que no se destruya
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

        Vector2u windowSize = Engine.Get.Window.Size;
        float x = Position.X;
        float y = Position.Y;

        if (x < -SpawnOffset * 2  || x > windowSize.X + SpawnOffset * 2 ||
            y < -SpawnOffset * 2 || y > windowSize.Y + SpawnOffset * 2)
        {
            Destroy();
        }
    }

    public void SetTexture(string texturePath)
    {
        // Liberamos la textura anterior si existía
        if (_texturaPropia != null)
        {
            _texturaPropia.Dispose();
        }

        // Anclamos la nueva textura a la variable de clase
        _texturaPropia = new Texture(texturePath);
        Sprite.Texture = _texturaPropia;
        Center();
    }
}