using System.Collections.Generic;
using Godot;
using Newtonsoft.Json;

public class Globals : Node
{
  public static Globals Instance;

  public bool isMultiplayer = false;
  public List<List<int>> cameraLimits = new List<List<int>>();

  // list of player ids that have completed the level
  public List<int> playersCompleted = new List<int>();

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

    cameraLimits = new()
    {
      new() { 1920, 1080 },
      new() { 2600, 1080 },
      new() { 3500, 1080 },
      new() { 1920, 1920 },
    };

    currentLevel = Enums.Levels.Level0;

    levels = new Dictionary<Enums.Levels, PackedScene>()
        {
          { Enums.Levels.Level0, GD.Load<PackedScene>("res://src/levels/Level0.tscn") },
          { Enums.Levels.Level1, GD.Load<PackedScene>("res://src/levels/Level1.tscn") },
          { Enums.Levels.Level2, GD.Load<PackedScene>("res://src/levels/Level2.tscn") },
          { Enums.Levels.Level3, GD.Load<PackedScene>("res://src/levels/Level3.tscn") }
        };

    // load high scores from file
    File scoresFile = new File();
    if (scoresFile.FileExists("user://highscores.save"))
    {
      scoresFile.Open("user://highscores.save", File.ModeFlags.Read);
      string json = scoresFile.GetAsText();
      highScores = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
      scoresFile.Close();
    }
  }
}
