using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController_sc : MonoBehaviour
{


    [SerializeField] RectTransform PlayerPanel;
    private Vector2 PlayerPanelAttackPhasePos = new Vector2(0, -204);
    private Vector2 PlayerPanelDefencePhasePos = new Vector2(0,-356);
    private Vector2 PlayerPanelPos; 


    [SerializeField] float speed = 5f;

   


    [SerializeField] RectTransform EnemyHealth;
    [SerializeField] RectTransform PlayerHealth;

 


    [SerializeField] GameObject gameUIElements;
    [SerializeField] GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
        PlayerPanelPos = PlayerPanelAttackPhasePos;
    }

    public void OnSubmit()
    {
        SwitchPhase();
    }


    public void SwitchPhase()// phase deðiþikliðinde çaðýrýlacak
    {
        if (GameStateController_sc.getGamePhase() == GamePhase.gamePhase.playerDefence )
        {
            PlayerPanelPos = PlayerPanelAttackPhasePos;
            GameStateController_sc.setGamePhase(GamePhase.gamePhase.playerAttack);// temp
        }
        else
        {
            PlayerPanelPos = PlayerPanelDefencePhasePos;
            GameStateController_sc.setGamePhase(GamePhase.gamePhase.playerDefence);// temp
        }
        

    }
    private void Update()
    {
        MovePanels();

    }

    private void MovePanels()
    {
        PlayerPanel.anchoredPosition = Vector2.MoveTowards(PlayerPanel.anchoredPosition, PlayerPanelPos, speed * Time.deltaTime);

    }


    #region health
    public void UpdatePlayerHealthBar()
    {
        PlayerHealth.localScale = new Vector3(GameStateController_sc.getPlayerHealth() / 100, 1, 1); 
    }
    public void UpdateEnemyHealthBar() 
    {
        EnemyHealth.localScale = new Vector3(GameStateController_sc.getEnemyHealth() / 100 , 1 , 1);  

    }
    #endregion


    #region pauseMenu
    public void OnPause()
    {
        swapGamePaused();
    }
 
    public void pauseGame()
    {
        gameUIElements.SetActive(false);
        pauseMenu.SetActive(true);
        GameStateController_sc.setGamePaused(true);
    }
    public void unPauseGame()
    {
        gameUIElements.SetActive(true);
        pauseMenu.SetActive(false);
        GameStateController_sc.setGamePaused(false);
    }
    public void swapGamePaused()
    {
        if (GameStateController_sc.getGamePaused())
        {
            unPauseGame();
        }
        else
        {
            pauseGame();
        }
    }
    public void exitGame() // oyuncuya emin misin diye sorma olacak
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); //ana menu açýlacak oyuncuya emin misin diye sorulacak
        Debug.Log("Ana menü");
    }

    #endregion

}
