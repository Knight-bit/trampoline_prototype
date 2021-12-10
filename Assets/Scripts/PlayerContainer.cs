using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;
using TMPro;
public class PlayerContainer : MonoBehaviour
{
    public GameObject playerPrefab;
    private void Start()
    {
        StartCoroutine(WaitPlatform());
        //Instantiate(player, PlaneObject.Planes[index_x, index_y].transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
    }
    IEnumerator WaitPlatform()
    {
        yield return new WaitUntil(() => PlaneObject.loaded_platform == false);
        //string Players = "Players";
        //Transform player_holder = new GameObject(Players).transform;

        int limit = PlaneObject.Planes.GetLength(0);
        Debug.Log("Limit is equal to : " + limit);
        PlayerScript player = Object.Instantiate(playerPrefab, PlaneObject.PositionPlaform(0, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f)).GetComponent<PlayerScript>();
        player.Initialize(0, 0, limit - 1, "Naruto", Color.red, Quaternion.Euler(0.0f, 0.0f, 0.0f), Variables.player.ONE);
        player.gameObject.transform.parent = gameObject.transform;

        PlayerScript player2 = Object.Instantiate(playerPrefab, PlaneObject.PositionPlaform(limit - 1, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f)).GetComponent<PlayerScript>();
        player2.Initialize(limit - 1 , 0, limit- 1, "Ohaiho", Color.white, Quaternion.Euler(0.0f, 180.0f, 0.0f), Variables.player.TWO);
        player2.gameObject.transform.parent = gameObject.transform;

        PlayerScript player3 = Object.Instantiate(playerPrefab, PlaneObject.PositionPlaform(0, limit -1 ), Quaternion.Euler(0.0f, 0.0f, 0.0f)).GetComponent<PlayerScript>();
        player3.Initialize(0, limit - 1, limit - 1, "Gaspi", Color.green, Quaternion.Euler(0.0f, 0.0f, 0.0f), Variables.player.THREE);
        player3.gameObject.transform.parent = gameObject.transform;

        PlayerScript player4 = Object.Instantiate(playerPrefab, PlaneObject.PositionPlaform(limit - 1, limit - 1), Quaternion.Euler(0.0f, 0.0f, 0.0f)).GetComponent<PlayerScript>();
        player4.Initialize(limit - 1, limit - 1, limit - 1, "Sasuke", Color.blue, Quaternion.Euler(0.0f, 180.0f, 0.0f), Variables.player.FOUR);
        player4.gameObject.transform.parent = gameObject.transform;

    }
   
}
