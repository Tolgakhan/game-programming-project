using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_sc : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject infoMenuPanel;

   public void exitGame()
    {
        Application.Quit();
    }

    public void showInfo()
    {
       mainMenuPanel.SetActive(false);
       infoMenuPanel.SetActive(true);
    }
    public void showMainMenu()
    {
        mainMenuPanel.SetActive(true);
        infoMenuPanel.SetActive(false);
    }


    public void loadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void loadTrainedAI()
    {
        SceneManager.LoadScene("GameTrainedAI");
    }

    public void loadNewGame()
    {
        SceneManager.LoadScene("GameUnTrainedAI");
    }
  
}
