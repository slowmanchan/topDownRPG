
using UnityEngine;
using UnityEngine.UI;
public class CharacterMenu : MonoBehaviour
{
  // Text fields
  public Text levelText, hitpointText, pesosText, upgradedCostText, xpText;

  // Logic
  private int currentCharacterSelection = 0;

  public Image characterSelectionSprite;
  public Image weaponSprite;
  public RectTransform xpBar;

  // Character selection
  public void OnArrowClick(bool right)
  {
    if (right)
    {
      currentCharacterSelection++;
      if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
        currentCharacterSelection = 0;

      OnSelectionChanged();
    }
    else
    {
      currentCharacterSelection--;
      if (currentCharacterSelection < 0)
        currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;

      OnSelectionChanged();
    }
  }

  private void OnSelectionChanged()
  {
    GameManager.instance.player.GetComponent<SpriteRenderer>().sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
  }

  public void OnUpgradeClick()
  {

  }

  public void UpdateMenu()
  {
    // Weapon
    weaponSprite.sprite = GameManager.instance.weaponSprites[0];
    upgradedCostText.text = "NOT IMPLEMENTED";

    // Meta
    levelText.text = "NOT IMPLEMENTED";
    hitpointText.text = GameManager.instance.player.hitpoint.ToString();
    pesosText.text = GameManager.instance.pesos.ToString();

    // xp bar
    xpText.text = "NOT IMPLEMENTED";
    xpBar.localScale = new Vector3(0.5f, 0, 0);
  }
}
