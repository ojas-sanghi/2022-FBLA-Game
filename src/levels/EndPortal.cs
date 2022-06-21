using System.Collections.Generic;
using System.Linq;
using Godot;

public class EndPortal : Area2D
{
  CollisionShape2D collisionShape;

  int id = 0;

  public override void _Ready()
  {
    GD.Print(((IndividualLevelInfo)GetParent()).id);
    this.id = ((IndividualLevelInfo)GetParent()).id;
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
    if (id != this.id) return;
    // Re-enable hitbox, give it color again
    if (LevelInfo.Instance.coinsCollected[id] >= LevelInfo.Instance.coinsRequired)
    {
      collisionShape.SetDeferred("disabled", false);
      GetNode<AnimatedSprite>("Sprite").Material = null;
      GetNode<AnimatedSprite>("Sprite").Playing = true;
    }
  }

  void OnEndPortalBodyEntered(Node body)
  {
    if (!(body is Player)) return;
    var player = (Player)body;

    Globals.Instance.playersCompleted.Add(player.id);
    Events.publishLevelPassed(player.id);

    // if MP, quit; MPBase.cs will pick up from here
    // otherwise, if SP, then go to next level
    if (Globals.Instance.isMultiplayer) return;

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