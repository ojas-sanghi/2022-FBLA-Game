using System.Threading.Tasks;
using Godot;

public class MPBase : Node
{
  Viewport viewport1;
  Viewport viewport2;

  PackedScene level;
  int levelNum;

  public override void _Ready()
  {
    viewport1 = GetNode<Viewport>("Viewports/ViewportContainer/Viewport");
    viewport2 = GetNode<Viewport>("Viewports/ViewportContainer2/Viewport");

    // TODO: employ logic in EndPortal.cs and globals.currentlevel; maybe move endportal stuff to globals so that i can use it here? maybe not? we'll see how the level progression logic works
    levelNum = 0;
    level = GD.Load<PackedScene>("res://src/levels/Level1.tscn");
    level.ResourceLocalToScene = true;

    loadPlayer1();
    loadPlayer2();

    Events.playerDied += OnPlayerDied;
  }

  public override void _ExitTree()
  {
    base._ExitTree();
    Events.playerDied -= OnPlayerDied;
  }

  async void OnPlayerDied(int playerId)
  {
    if (!Globals.Instance.isMultiplayer) return;

    if (playerId == 1)
    {
      await viewport1.GetChild(0).GetNode<Player>("Player").OnPlayerDied(playerId);
      viewport1.GetChild(0).QueueFree();
      loadPlayer1();
    }
    else if (playerId == 2)
    {
      await viewport2.GetChild(0).GetNode<Player>("Player").OnPlayerDied(playerId);
      viewport2.GetChild(0).QueueFree();
      loadPlayer2();
    }
  }

  void loadPlayer1()
  {
    // add level to viewport
    var newLevelNode = level.Instance();
    IndividualLevelInfo lvl = (IndividualLevelInfo)newLevelNode;
    lvl.id = 1;
    viewport1.AddChild(newLevelNode);

    // find player
    var player = newLevelNode.GetNode<Player>("Player");

    // create camera and add to player
    var cam1 = createCamera(this.levelNum);
    player.AddChild(cam1);
  }

  void loadPlayer2()
  {
    // add level to viewport
    var newLevelNode = level.Instance();
    IndividualLevelInfo lvl = (IndividualLevelInfo)newLevelNode;
    lvl.id = 2;
    viewport2.AddChild(newLevelNode);

    // find player, set its id
    var player = newLevelNode.GetNode<Player>("Player");
    player.id = 2;

    // create camera and add to player
    var cam2 = createCamera(this.levelNum);
    player.AddChild(cam2);
  }

  MPCamera createCamera(int levelNum)
  {
    MPCamera cam = new MPCamera();
    cam.Current = true;
    cam.LimitLeft = 0;
    cam.LimitTop = 0;
    cam.LimitRight = Globals.Instance.cameraLimits[levelNum][0];
    cam.LimitBottom = Globals.Instance.cameraLimits[levelNum][1];
    cam.SmoothingEnabled = true;
    cam.SmoothingSpeed = 2.5f;
    return cam;
  }
}
