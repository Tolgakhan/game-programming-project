using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_sc : MonoBehaviour
{
    [SerializeField] GameObject[] mainMenuItems;
    [SerializeField] GameObject[] infoMenuItems;
    public enum AILevel//eðitilmiþ/eðitilmemiþ yz ayný sahne olursa
    {
        None,
        Trained
    }
   public void exitGame()
    {
        Application.Quit();
    }

    public void showInfo()
    {
        foreach (GameObject item in mainMenuItems)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in infoMenuItems)
        {
            item.SetActive(true);
        }
    }
    public void showMainMenu()
    {
        foreach(GameObject item in mainMenuItems)
        {
            item.SetActive(true);
        }
        foreach(GameObject item in infoMenuItems)
        {
            item.SetActive(false);
        }
    }
    public void loadTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void loadTrainedAI()//eðitilmiþ/eðitilmemiþ yz farklý sahne olursa
    {
      
    }
    public void loadNewGame()//eðitilmiþ/eðitilmemiþ yz farklý sahne olursa
    {

    }
    public void loadGame(AILevel level)//eðitilmiþ/eðitilmemiþ yz ayný sahne olursa
    {
        switch (level) 
        {
            case AILevel.None:
                break;
            case AILevel.Trained:
                break;
        }
    }
}
