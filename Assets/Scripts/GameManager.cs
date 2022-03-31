using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject combat;
    public GameObject dungeon;
    
    public TextMeshProUGUI pauseMenu; 
    // Start is called before the first frame update
    void Start()
    {
        combat.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BattleMode(GameObject player, GameObject enemy)
    {
        player.GetComponent<PlayerBehaviour>().ChangeCombat();
        enemy.GetComponent<EnemyBehaviour>().ChangeCombat();
        
        dungeon.SetActive(false);
        // add transition here
        combat.SetActive(true);

        combat.GetComponent<CombatManager>().setFighters(player, enemy);
    }
}
