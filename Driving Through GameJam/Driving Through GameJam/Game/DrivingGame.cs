namespace Driving_Through_GameJam.Game;

public class DrivingGame: Game
{
    public Hud hud { private set; get; }
    public Background background { get;  private set;}
    private static DrivingGame instance;
    public static DrivingGame Get
    {
        get
        {
            if (instance == null)
            {
                instance = new DrivingGame();
            }

            return instance;
        }
    }
    private DrivingGame()
    {
    }
    public void Init()
    {
        background = Engine.Get.Scene.Create<Background>();
        Engine.Get.Scene.Create<Plane>();  
    }
       
    public void DeInit()
    {
    }
    public void Update(float dt)
    {
      
    }
}