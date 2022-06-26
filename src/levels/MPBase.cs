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

    goToGlobalsCurrentLevel();

    Events.timeOver += OnTimeOver;
    Events.playerDied += OnPlayerDied;
    Events.levelPassed += OnLevelPassed;
    Events.mpNextLevel += goToGlobalsCurrentLevel;
  }

  public override void _ExitTree()
  {
    base._ExitTree();
    Events.timeOver -= OnTimeOver;
    Events.playerDied -= OnPlayerDied;
    Events.levelPassed -= OnLevelPassed;
    Events.mpNextLevel -= goToGlobalsCurrentLevel;
  }

  async void OnTimeOver()
  {
    if (!Globals.Instance.isMultiplayer) return;

    // on time over, reload all the playres which have not completed the level yet
    if (!Globals.Instance.playersCompleted.Contains(1))
    {
      if (!Globals.Instance.playersCompleted.Contains(2))
      {
        // if both players need to be reset, then start the 1st, start 2nd, and await the 2nd
        // this way they happen concurrently
        // otherwise, the 2nd one waits for the first one, which takes 2x as long and looks weird
        reloadPlayer1();
        await reloadPlayer2();
      }
      else
      {
        await reloadPlayer1();
      }
    }
    else if (!Globals.Instance.playersCompleted.Contains(2))
    {
      await reloadPlayer2();
    }
    GetNode<TimeLeftLabel>("InfoHUD/MPHUDs/MPHUDBoth/TimeLeftLabel").resetAndStartTimer();
  }

  async void OnPlayerDied(int playerId)
  {
    if (!Globals.Instance.isMultiplayer) return;

    if (playerId == 1)
    {
      await reloadPlayer1();
    }
    else if (playerId == 2)
    {
      await reloadPlayer2();
    }
  }

  async Task reloadPlayer1()
  {
    await viewport1.GetChild(0).GetNode<Player>("Player").OnPlayerDied(1);
    viewport1.GetChild(0).Free();
    loadPlayer1();
  }

  async Task reloadPlayer2()
  {
    await viewport2.GetChild(0).GetNode<Player>("Player").OnPlayerDied(2);
    viewport2.GetChild(0).Free();
    loadPlayer2();
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
    cam.LimitRight = Globals.Instance.cameraLimits[levelNum - 1][0];
    cam.LimitBottom = Globals.Instance.cameraLimits[levelNum - 1][1];
    cam.SmoothingEnabled = true;
    cam.SmoothingSpeed = 2.5f;
    cam.Zoom = new Vector2(0.75f, 0.75f);
    return cam;
  }

  void OnLevelPassed(int playerId)
  {
    if (!Globals.Instance.isMultiplayer) return;

    if (playerId == 1)
    {
      viewport1.GetChild(0).QueueFree();
      var endScreenPacked = GD.Load<PackedScene>("res://src/GUI/LevelEndScreen.tscn");
      var endScreen = endScreenPacked.Instance();
      viewport1.AddChild(endScreen);
    }
    else if (playerId == 2)
    {
      viewport2.GetChild(0).QueueFree();
      var endScreenPacked = GD.Load<PackedScene>("res://src/GUI/LevelEndScreen.tscn");
      var endScreen = endScreenPacked.Instance();
      viewport2.AddChild(endScreen);
    }
  }

  public void goToGlobalsCurrentLevel()
  {
    this.levelNum = (int)Globals.Instance.currentLevel + 1;
    level = GD.Load<PackedScene>("res://src/levels/Level" + this.levelNum + ".tscn");
    level.ResourceLocalToScene = true;

    loadPlayer1();
    loadPlayer2();
  }
}
