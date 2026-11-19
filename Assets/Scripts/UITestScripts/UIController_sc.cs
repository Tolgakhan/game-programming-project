using UnityEngine;
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

    public int enemyHealth = 100; //temp
    public int playerHealth = 100; //temp

    [SerializeField] Sprite[] defenceSprites;//yeniden yapýlacak
    private float defenceScale = 1.36f;//yeniden yapýlacak
    [SerializeField] Image blockCircle;//yeniden yapýlacak
    private bool defend = false; //yeniden yapýlacak

    private void Start()
    {
        powerBarPos = powerBarAttackPhasePos;
        attacksPos = attacksAttackPhasePos;
        blockCircle.SetEnabled(false);
    }

    public void OnSubmit() //temp phase change fonksiyonu
    {
        SwitchPhase();
    }
    public void OnCancel() // temp hasar verme
    {
        enemyHealth -= 1;
        playerHealth -= 1;
        ProcessEnemyHealth(enemyHealth);
        ProcessPlayerHealth(playerHealth);
    }

    public void SwitchPhase()// phase deðiþikliðinde çaðýrýlacak
    {
        if (temp)
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

    public void ProcessPlayerHealth(int health)// farklý yapýlabilir
    {
        PlayerHealth.localScale = new Vector3((float)health/100, 1, 1);
    }
    public void ProcessEnemyHealth(int health) // farklý yapýlabilir
    {
        EnemyHealth.localScale = new Vector3(((float)health/100) , 1 , 1);

    }

    public void ProcessBlock(float defenceTime)//yeniden yapýlacak
    {
        blockCircle.style.scale = new Vector3(defenceScale, defenceScale, defenceScale);
        blockCircle.sprite = defenceSprites[0];
        blockCircle.SetEnabled(true);
        defend = true;
    }
    public void ProcessDodge()//yeniden yapýlacak
    {

    }
}
