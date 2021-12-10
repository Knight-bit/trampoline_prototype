using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerScript>().Buff();
        ObjectsGenerator.RestItem();
        //player.Buff();
        Destroy(gameObject);
    }
}
