using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  // instance makes the class instantiable from anywhere
  public static GameManager instance;
  private void Awake()
  {
    if (GameManager.instance != null)
    {
      Destroy(gameObject);
      return;
    }
    // we set instance to this to make it a singleton
    instance = this;
    SceneManager.sceneLoaded += LoadState;
    DontDestroyOnLoad(gameObject);
  }

  // resources
  public List<Sprite> playerSprites;
  public List<Sprite> weaponSprites;
  public List<int> weaponPrices;
  public List<int> xpTable;

  // references
  public Player player;
  public FloatingTextManager floatingTextManager;

  // logic
  public int pesos;
  public int experience;

  // floating text
  public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
  {
    floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
  }

  // save state
  public void SaveState()
  {
    string s = "";

    s += "0" + "|";
    s += pesos.ToString() + "|";
    s += experience.ToString() + "|";
    s += "0";

    PlayerPrefs.SetString("SaveState", s);
    Debug.Log("save state");
  }

  public void LoadState(Scene s, LoadSceneMode mode)
  {
    if (!PlayerPrefs.HasKey("SaveState"))
      return;

    string[] data = PlayerPrefs.GetString("SaveState").Split('|');
    pesos = int.Parse(data[1]);
    experience = int.Parse(data[2]);
    Debug.Log("load state");
  }
}
