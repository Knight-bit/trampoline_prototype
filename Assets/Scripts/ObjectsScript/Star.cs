using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        ObjectsGenerator.RestStar();
        other.gameObject.GetComponent<PlayerScript>().points += MainManager.GivePoints(other.gameObject.GetComponent<PlayerScript>().hash);
        other.gameObject.GetComponent<PlayerScript>().resetText();
        Destroy(gameObject);
    }
}
