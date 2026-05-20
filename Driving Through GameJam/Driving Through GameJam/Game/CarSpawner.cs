using SFML.System;
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

    public void SetCarriles(List<Carril> carriles)//añade carriles en una lista
    {
        _carriles.Clear();
        foreach (var c in carriles)
            _carriles.Add((c, 0f));
    }

    public override void Update(float dt)//update del spwan de cars: spawneda cars en bucle en un intervalo segun un timer
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
    
    private void SpawnCar(Carril carril)//spawneo de cars. depede de la direccion del carril van derecha o izquierda a cierta velocidad
    {
        Cars car = Engine.Get.Scene.Create<Cars>();
        car.SetTexture(TexturaCoche);
        Vector2u windowSize = Engine.Get.Window.Size;

        if (carril.ToTheRight)
        {
            car.Position = new Vector2f(-SpawnOffset, carril.Y);
            car.Forward = new Vector2f(1, 0);
        }
        else
        {
            car.Position = new Vector2f(windowSize.X + SpawnOffset, carril.Y);
            car.Forward = new Vector2f(-1, 0);
        }

        car.Speed = carril.Speed; 
    }
}