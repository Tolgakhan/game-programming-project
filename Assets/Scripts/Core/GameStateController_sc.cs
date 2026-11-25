using UnityEngine;

public class GameStateController_sc
{
    private static bool isGamePaused = true;
    private static float playerHealth = 100f;
    private static float enemyHealth = 100f;
    private static float playerPower = 0f;
    private static float enemyPower = 0f;

    
    private static GamePhase.gamePhase currentGamePhase;

    #region gamePhaseFunctions
    public static GamePhase.gamePhase getGamePhase() //gamephase getter fonksiyonu
    {
        return currentGamePhase;
    }
    public static void setGamePhase(GamePhase.gamePhase nextGamePhase)// gamephase setter fonksiyonu
    {
        currentGamePhase = nextGamePhase;
    }
    public static void nextGamePhase() // sıradaki gamephase geçme fonksiyonu
    {
        currentGamePhase = currentGamePhase == GamePhase.gamePhase.playerDefence ? GamePhase.gamePhase.playerAttack : currentGamePhase + 1;
    }
    #endregion

    #region playerHealthFunctions
    public static float getPlayerHealth() // playerHealth getter fonksiyonu
    {
        return playerHealth;
    }
    public static void setPlayerHealth(float health) // playerHealth setter fonksiyonu
    {
        playerHealth = health;
    }
    public static void decrementPlayerHealth(float dec) // playerHealth azaltma fonksiyonu
    {
        playerHealth -= dec;
    }

    #endregion 

    #region playerPowerFunctions
    public static float getPlayerPower() // playerPower getter fonksiyonu
    {
        return playerPower;
    }
    public static void setPlayerPower(float power) // playerPower setter fonksiyonu
    {
        playerPower = power;
    }
    public static void incrementPlayerPower(float inc) // playerPower arttırma fonksiyonu
    {
        playerPower += inc;
    }
    #endregion



    #region enemyHealthFunctions
    public static float getEnemyHealth()// enemyHealth getter fonksiyonu
    {
        return enemyHealth;
    }
    public static void setEnemyHealth(float health)// enemyHealth setter fonksiyonu
    {
        enemyHealth = health;
    }
    public static void decrementEnemyHealth(float dec)// enemyHealth azaltma fonksiyonu
    {
        enemyHealth -= dec;
    }

    #endregion

    #region enemyPowerFunctions
    public static float getEnemyPower()// enemyPower getter fonksiyonu
    {
        return enemyPower;
    }
    public static void setEnemyPower(float power)// enemyPower setter fonksiyonu
    {
        enemyPower = power;
    }
    public static void incrementEnemyPower(float inc)// enemyPower arttırma fonksiyonu
    {
        enemyPower += inc;
    }
    #endregion

    #region gamePauseFunctions
    public static bool getGamePaused() // gamePaused getter fonksiyonu
    {
        return isGamePaused;
    }
    public static void setGamePaused(bool gamePaused)// gamePaused setter fonksiyonu
    {
        isGamePaused = gamePaused;
    }
    #endregion

}
