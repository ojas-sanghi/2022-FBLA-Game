using System.Collections.Generic;
using System.Linq;
using Godot;

public class InfoHUD : Control
{
  [Export] bool isMPHUD = false;

  public override void _Ready()
  {
    if (Globals.Instance.isMultiplayer)
    {
      GetNode<Control>("SPHUDs").Hide();
      GetNode<Control>("MPHUDs").Show();
    }
    else
    {
      GetNode<Control>("SPHUDs").Show();
      GetNode<Control>("MPHUDs").Hide();
    }

    // disable timer nodes based off a) MP or SP, and b) if this speicfic InfoHUD should be on or not
    if (Globals.Instance.isMultiplayer)
    {
      // disable all SP timers in MP
      foreach (TimeLeftLabel l in GetTree().GetNodesInGroup("SPTimeLeft"))
        l.disabled = true;

      // go thru all MP timers; if their InfoHUD isn't MP, then disable it
      foreach (TimeLeftLabel l in GetTree().GetNodesInGroup("MPTimeLeft"))
      {
        InfoHUD infoHud = (InfoHUD)(l.GetParent().GetParent().GetParent());
        if (!infoHud.isMPHUD)
          l.disabled = true;
      }
    }

    if (!Globals.Instance.isMultiplayer)
    {
      // disable all SP timers in MP
      foreach (TimeLeftLabel l in GetTree().GetNodesInGroup("MPTimeLeft"))
        l.disabled = true;

      // go thru all SP timers; if their InfoHUD is MP, then disable it
      foreach (TimeLeftLabel l in GetTree().GetNodesInGroup("SPTimeLeft"))
      {
        InfoHUD infoHud = (InfoHUD)(l.GetParent().GetParent().GetParent());
        if (infoHud.isMPHUD)
          l.disabled = true;
      }
    }
  }
}
