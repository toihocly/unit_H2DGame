using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGenerate : MonoBehaviour {
    

    public GameObject[] players;
    GameObject gamePlayer;
    #region  Thay Doi NV
    public static string namePlayerWantGenarete = "Player1";

    public static Image object1;
    public static Sprite Normal1;
    public static Image object2;

    //private static bool isCheckChange = false;
    //public static void setNamePlayerWantGenarete(string _name)
    //{
    //    if (namePlayerWantGenarete != _name)
    //    {
    //        isCheckChange = true;
    //        namePlayerWantGenarete = _name;
    //    }

    //}
    //public static string getNamePlayerWantGenarete()
    //{
    //    return namePlayerWantGenarete;
    //}
    //public static bool getStatusNamePlayerWantGenarete()
    //{
    //    return isCheckChange;
    //}
    #endregion


    private GameObject getBuilding()
    {
        return players[Random.Range(0, players.Length - 1)];
    }
    void Start () {
      
        Vector3 respawnPoint = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0f);

        switch (namePlayerWantGenarete)
        {
            case "Player1":
                gamePlayer = Instantiate(players[0], respawnPoint, Quaternion.identity);
                break;
            case "Player2":
                gamePlayer = Instantiate(players[1], respawnPoint, Quaternion.identity);
                break;
            case "Player3":
                gamePlayer = Instantiate(players[2], respawnPoint, Quaternion.identity);
                break;
            case "Player4":
                gamePlayer = Instantiate(players[3], respawnPoint, Quaternion.identity);
                break;
            case "Player5":
                gamePlayer = Instantiate(players[4], respawnPoint, Quaternion.identity);
                break;
            default:
                gamePlayer = Instantiate(getBuilding(), respawnPoint, Quaternion.identity);
                break;
        }
        
        gamePlayer.name = "Player";
	}
	
	void Update () {
		
	}
}
