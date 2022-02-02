using System.Linq;
using System.Collections.Generic;
using Godot;
using Newtonsoft.Json;

public class Globals : Node
{
  public static Globals Instance;

  public Enums.Levels currentLevel;
  public Dictionary<Enums.Levels, PackedScene> levels;

  public Dictionary<string, int> highScores = new Dictionary<string, int>();

  public Globals()
  {
    Instance = this;
  }

  public override void _Ready()
  {
    Instance = this;

    currentLevel = Enums.Levels.Level1;

    levels = new Dictionary<Enums.Levels, PackedScene>()
        {
          { Enums.Levels.Level1, GD.Load<PackedScene>("res://src/levels/Level1.tscn") },
          { Enums.Levels.Level2, GD.Load<PackedScene>("res://src/levels/Level2.tscn") }
        };

    File scoresFile = new File();
    scoresFile.Open("user://highscores.save", File.ModeFlags.Read);
    highScores = JsonConvert.DeserializeObject<Dictionary<string, int>>(scoresFile.GetAsText());
    scoresFile.Close();
  }
}
