using System.Collections.Generic;
using System.Linq;
using Godot;

public class EndPortal : Area2D
{
  CollisionShape2D collisionShape;

  public override void _Ready()
  {
    base._Ready();

    // Note: by default, portal is b&w and the hitbox is disabled
    collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
    Events.coinCollected += OnCoinCollected;
  }

  public override void _ExitTree()
  {
    base._ExitTree();
    Events.coinCollected -= OnCoinCollected;
  }

  void OnCoinCollected(BaseCoin coin, int id)
  {
    // TODO: play a different animation when it unlocks
    // Re-enable hitbox, give it color again
    if (LevelInfo.Instance.coinsCollected[id] >= LevelInfo.Instance.coinsRequired)
    {
      collisionShape.SetDeferred("disabled", false);
      GetNode<Sprite>("Sprite").Material = null;
    }
  }


  void OnEndPortalBodyEntered(Node body)
  {
    if (!(body is Player)) return;
    var player = (Player)body;

    LevelInfo.Instance.resetCoinsCollected(player.id);

    // get a list of all the levels in the enum
    // and then get the index of the current level and increment
    List<Enums.Levels> levelsList = Enums.Levels.GetValues(typeof(Enums.Levels)).Cast<Enums.Levels>().ToList();
    int currentLevelIndex = levelsList.IndexOf(Globals.Instance.currentLevel);
    int nextLevelIndex = currentLevelIndex + 1;

    if (nextLevelIndex >= levelsList.Count)
    {
      SceneChanger.Instance.GoToScene("res://src/GUI/EndScreen.tscn");
    }
    else
    {
      Globals.Instance.currentLevel = (Enums.Levels)nextLevelIndex;
      SceneChanger.Instance.GoToScene("res://src/GUI/LevelEndScreen.tscn");
    }
  }
}