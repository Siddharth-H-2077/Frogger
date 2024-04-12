using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Gamemanager : MonoBehaviour
{
    public Player player;
    [SerializeField]private int life;
    private int reachedHome = 0;
    [SerializeField]private float Totaltime=180f;
    [SerializeField] private Text remainingTime;
    [SerializeField] private Text Win;
    [SerializeField] private Text Lose;
    [SerializeField] private Text remainingLife;
    [SerializeField] private GameObject btn;
    //Start game
    private void Start()
    {
        StartGame();
    }
    private void StartGame()
    {
        btn.SetActive ( false);
        Lose.enabled = false;
        Win.enabled = false;
        remainingLife.text = string.Format("{0} {1}", new string("X"), life.ToString());
        remainingTime.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(Totaltime / 60), Mathf.FloorToInt(Totaltime % 60));
    }
    
    //Timer and condition check
    private void Update()
    {
        Totaltime = Totaltime - Time.deltaTime;
        remainingTime.text = string.Format("{0:00}:{1:00}",Mathf.FloorToInt(Totaltime/60),Mathf.FloorToInt(Totaltime%60));

        if (player.dead)
        {
            deadCheck();
        }
        if (player.reached)
        {
            reachedHome++;
            respawnPlayer();
            win(); 
        }
        if (Totaltime<=0)
        {
            lose();
        }
    }

    //all lose conditions
    private void lose() 
    {
        if(life<=0||Totaltime<=0)
        {
            Debug.Log("LOST");
            Time.timeScale = 0;
            Lose.enabled = true;
            btn.SetActive(true);
        }
    }

    //player instantly wins on reaching home once
    private void win() 
    {
        player.reached = false;
        if(reachedHome==2)
        {
            Debug.Log("WIN");
            Time.timeScale = 0;
            Win.enabled = true;
            btn.SetActive(true);
        }
    }
    
    //dead conditions
    private void deadCheck()
    {
        if ( life != 0)
        {
            life -= 1;
            remainingLife.text = string.Format("{0} {1}",new string("X"),life.ToString());
            lose();
            player.dead = false;
            respawnPlayer();
        }
        else
            lose();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }

    //if player dead respawn
    private void respawnPlayer() 
    {
        player.respawn();
    }

}
