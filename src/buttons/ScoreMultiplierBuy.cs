using Godot;

public class ScoreMultiplierBuy : Button
{
  public override void _Ready()
  {
    base._Ready();

    checkIfEnoughMoney();
  }

  void checkIfEnoughMoney()
  {
    int cost = ShopInfo.Instance.shopItems["x2 Score Multiplier"];

    if (PlayerInfo.gold <= cost)
    {
      Disabled = true;
    }
    else
    {
      Disabled = false;
    }
  }

  void OnScoreMultiplierBuyPressed()
  {
    int cost = ShopInfo.Instance.shopItems["x2 Score Multiplier"];

    if (PlayerInfo.gold >= cost)
    {
      PlayerInfo.gold -= cost;
      checkIfEnoughMoney();
      Events.publishGoldChanged();
      Events.publishScoreMultiplierBought(2);
    }
  }
}


// todo
// singleton for the music so its smooth
// continue to play the music in the powerup shop
// collection vfx for coins