using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [System.Serializable]
    public class PlayerStatus
    {
        public float Health = 100f;
    }

    public PlayerStatus playerStatus = new PlayerStatus();


    public void DamagePlayer(int dmg)
    {
        playerStatus.Health -= dmg;
        if(playerStatus.Health <= 0)
        {
            Debug.Log("KILL PLAYER");
            GameMaster.KillPlayer(this);
        }
    }


}
