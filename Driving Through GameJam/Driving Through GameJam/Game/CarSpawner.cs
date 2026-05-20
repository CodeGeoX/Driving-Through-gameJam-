using SFML.System;
using SFML.Graphics; // Necesario para FloatRect
using System.Collections.Generic;

namespace Driving_Through_GameJam.Game;

public class CarSpawner : Actor
{
    private const float SpawnOffset = 16f;
    public string TexturaCoche { get; set; } = "Data/Textures/Coche.png";
    public struct Carril
    {
        public float Y;
        public bool ToTheRight;
        public float Speed;
        public float Interval;
    }

    private List<(Carril carril, float timer)> _carriles = new();

    public CarSpawner()
    {
        Layer = ELayer.Background;
    }

    public void SetCarriles(List<Carril> carriles)
    {
        _carriles.Clear();
        foreach (var c in carriles)
            _carriles.Add((c, 0f));
    }

    public override void Update(float dt)
    {
        for (int i = 0; i < _carriles.Count; i++)
        {
            Carril carril = _carriles[i].Item1;
            float timer = _carriles[i].Item2;
            timer += dt;

            if (timer >= carril.Interval)
            {
                timer = 0f;
                SpawnCar(carril);
            }
            _carriles[i] = (carril, timer);
        }
    }
    
    private void SpawnCar(Carril carril)
    {
        Cars car = Engine.Get.Scene.Create<Cars>();
        car.SetTexture(TexturaCoche);

        if (carril.ToTheRight)
        {
            car.Position = new Vector2f(-SpawnOffset, carril.Y);
            car.Forward = new Vector2f(1, 0);
        }
        else
        { 
            FloatRect limitesFondo = MyGame.Get.background.Sprite.GetGlobalBounds();
            float anchoMapa = limitesFondo.Width;
            car.Position = new Vector2f(anchoMapa + SpawnOffset, carril.Y);
            car.Forward = new Vector2f(-1, 0);
        }

        car.Speed = carril.Speed; 
    }
}