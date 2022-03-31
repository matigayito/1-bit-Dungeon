using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject actualPlayer;
    private PlayerBehaviour playerScript;
    public GameObject actualEnemy;
    private EnemyBehaviour enemyScript;

    public void setFighters(GameObject player, GameObject enemy)
    {
        actualEnemy = enemy;
        enemyScript = enemy.GetComponent<EnemyBehaviour>();
        actualPlayer = player;
        playerScript = player.GetComponent<PlayerBehaviour>();
    }
    
    public void PlayerAttack()
    {
        enemyScript.reciveDamage(playerScript.damage);

        if (enemyScript.health <= 0)
        {
            Debug.Log("enemy dead!");
            Destroy(actualEnemy);
        }
    }
}
