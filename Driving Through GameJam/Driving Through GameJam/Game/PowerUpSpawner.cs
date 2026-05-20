namespace Driving_Through_GameJam.Game;

public class PowerUpSpawner : Actor
{
    private float timer = 0;
    private float intervalo = 5f; 
    private int maxPowerUps = 1;

    public override void Update(float dt)
    {
        base.Update(dt);

        timer += dt;

        if (timer >= intervalo)
        {
            timer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        int cantidadActual = Engine.Get.Scene.GetAll<PowerUp>().Count();

        if (cantidadActual < maxPowerUps)
        {
            Engine.Get.Scene.Create<PowerUp>();
        }
    }
}