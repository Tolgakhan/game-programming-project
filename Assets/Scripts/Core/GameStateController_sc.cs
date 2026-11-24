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
    public static GamePhase.gamePhase getGamePhase()
    {
        return currentGamePhase;
    }
    public static void setGamePhase(GamePhase.gamePhase nextGamePhase)
    {
        currentGamePhase = nextGamePhase;
    }
    public static void nextGamePhase()
    {
        currentGamePhase = currentGamePhase == GamePhase.gamePhase.playerDefence ? GamePhase.gamePhase.playerAttack : currentGamePhase + 1;
    }
    #endregion

    #region playerHealthFunctions
    public static float getPlayerHealth()
    {
        return playerHealth;
    }
    public static void setPlayerHealth(float health)
    {
        playerHealth = health;
    }
    public static void decrementPlayerHealth(float dec)
    {
        playerHealth -= dec;
    }

    #endregion 

    #region playerPowerFunctions
    public static float getPlayerPower()
    {
        return playerPower;
    }
    public static void setPlayerPower(float power)
    {
        playerPower = power;
    }
    public static void incrementPlayerPower(float inc)
    {
        playerPower -= inc;
    }
    #endregion



    #region enemyHealthFunctions
    public static float getEnemyHealth()
    {
        return enemyHealth;
    }
    public static void setEnemyHealth(float health)
    {
        enemyHealth = health;
    }
    public static void decrementEnemyHealth(float dec)
    {
        enemyHealth -= dec;
    }

    #endregion

    #region enemyPowerFunctions
    public static float getEnemyPower()
    {
        return enemyPower;
    }
    public static void setEnemyPower(float power)
    {
        enemyPower = power;
    }
    public static void incrementEnemyPower(float inc)
    {
        enemyPower -= inc;
    }
    #endregion

    #region gamePauseFunctions
    public static bool getGamePaused()
    {
        return isGamePaused;
    }
    public static void setGamePaused(bool gamePaused)
    {
        isGamePaused = gamePaused;
    }
    #endregion

}
public class GamePhase
{
    public enum gamePhase
    {
        playerAttack,
        inBetween,
        playerDefence
    }
}
