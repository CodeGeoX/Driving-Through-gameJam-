using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;
using System;
namespace Driving_Through_GameJam.Game;

public class PowerUp : StaticActor
{
    private float timer = 0;
    private float maxTime = 3f;
    private bool activo = false;

    public PowerUp()
    {
        Layer = ELayer.Middle;
        Sprite = new Sprite(new Texture("Data/Textures/PowerUp.png"));
        PositionPU();
    }

    public override void Update(float dt)
    {
        base.Update(dt);

        if (CheckCollisionPU() && !activo)
        {
            activo = true;
            SlowCars();
            Sprite.Color = new Color(255, 255, 255, 0);

        }

        if (activo)
        {
            timer += dt;

            if (timer >= maxTime)
            {
                activo = false;
                timer = 0;
                RestoreCarSpeed();
                PositionPU();

            }
        }
    }

    private void SlowCars()
    {
        foreach (Cars car in Engine.Get.Scene.GetAll<Cars>())
        {
            car.Speed = 20f; 
        }
    }

    private void RestoreCarSpeed()
    {
        foreach (Cars car in Engine.Get.Scene.GetAll<Cars>())
        {
            car.Speed = 80f; 
        }
    }


    public bool CheckCollisionPU()
    {
        foreach (Player player in Engine.Get.Scene.GetAll<Player>())
        {
            if (GetGlobalBounds().Intersects(player.GetGlobalBounds()))
            {
                return true;
            }
        }
        return false;
    }

    public void PositionPU()
    {
        Random rnd = new Random();

        FloatRect limitesFondo = MyGame.Get.background.Sprite.GetGlobalBounds();

        float sizeX = rnd.Next(0, (int)limitesFondo.Width - 20);
        float sizeY = rnd.Next(0, (int)(limitesFondo.Height / 2) - 20);
        
        Position = new Vector2f(sizeX, sizeY);
        Sprite.Color = new Color(255, 255, 255, 255);
    }

}