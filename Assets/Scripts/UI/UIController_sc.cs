using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController_sc : MonoBehaviour
{
    [SerializeField] RectTransform powerBar;
    private Vector2 powerBarAttackPhasePos = new Vector2(0, -131);
    private Vector2 powerBarDefencePhasePos = new Vector2(0,-280);
    private Vector2 powerBarPos;
    [SerializeField] RectTransform attacks;
    private Vector2 attacksAttackPhasePos = new Vector2(0, -225);
    private Vector2 attacksDefencePhasePos = new Vector2(0,-374);
    private Vector2 attacksPos;

    [SerializeField] float speed = 5f;

    bool temp = true; // gameStateController phase kontrolüyle deðiþecek


    [SerializeField] RectTransform EnemyHealth;
    [SerializeField] RectTransform PlayerHealth;

    public float enemyHealth = 100; //temp
    public float playerHealth = 100; //temp



    [SerializeField] GameObject gameUIElements;
    [SerializeField] GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
        powerBarPos = powerBarAttackPhasePos;
        attacksPos = attacksAttackPhasePos;
    }

    public void OnSubmit() //temp phase change fonksiyonu
    {
        SwitchPhase();
    }
    public void OnCancel() // temp hasar verme
    {
        enemyHealth -= 1;
        playerHealth -= 1;
        UpdatePlayerHealthBar();
        UpdateEnemyHealthBar();
    }

    public void SwitchPhase()// phase deðiþikliðinde çaðýrýlacak
    {
        if (temp /*gameStateController.getGamePhase == gamePhase.playerDefence */)
        {
            powerBarPos = powerBarDefencePhasePos;
            attacksPos = attacksDefencePhasePos;
        }
        else
        {
            powerBarPos = powerBarAttackPhasePos;
            attacksPos = attacksAttackPhasePos;
        }
        temp = !temp;

    }
    private void Update()
    {
        MovePanels();

    }

    private void MovePanels()
    {
        powerBar.anchoredPosition = Vector2.MoveTowards(powerBar.anchoredPosition, powerBarPos, speed * Time.deltaTime);
        attacks.anchoredPosition = Vector2.MoveTowards(attacks.anchoredPosition, attacksPos, speed * Time.deltaTime);
    }


    #region health
    public void UpdatePlayerHealthBar()
    {
        PlayerHealth.localScale = new Vector3(playerHealth/100, 1, 1); // gameStateController.getPLayerHealth()
    }
    public void UpdateEnemyHealthBar() 
    {
        EnemyHealth.localScale = new Vector3(enemyHealth/100 , 1 , 1); // gameStateController.getEnemyHealth()

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
        //gameStateController.setGamePaused(true); //gameStateController ile birleþtiðinde açýlacak
    }
    public void unPauseGame()
    {
        gameUIElements.SetActive(true);
        pauseMenu.SetActive(false);
        //gameStateController.setGamePaused(false); //gameStateController ile birleþtiðinde açýlacak
    }
    public void swapGamePaused()
    {
        if (pauseMenu.activeSelf)//if'in içi temp  //gameStateController.getGamePaused()//gameStateController ile birleþtiðinde if'e yerleþtirilecek
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
        //SceneManager.LoadScene("MainMenu"); //ana menu açýlacak oyuncuyo emin misin diye sorulacak
        Debug.Log("Ana menü");
    }

    #endregion

}
