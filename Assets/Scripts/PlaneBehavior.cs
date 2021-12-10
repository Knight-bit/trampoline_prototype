using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;
public class PlaneBehavior : MonoBehaviour
{
    Material material;
    private bool used = false;
    player hash;
    Color default_color;
    private void Start()
    { 

        material = GetComponent<MeshRenderer>().material;
        default_color = GetComponent<MeshRenderer>().materials[0].color;
        //Debug.Log("Material color: " + material.color);
        //Debug.Log("Material shader: " + material.shader.name);
    }
    public void SetDefault()
    {
        hash = player.NOONE;
        material.SetColor("_Color", default_color);
    }
    public void BelongsTo(Color color, player hash)
    {
        this.hash = hash;
        material.SetColor("_Color", color);
    }
    public bool Point(player player)
    {
        return player == this.hash; 
    }
    public bool isUsed()
    {
        return used;
    }
    public void vacate()
    {
        used = false;
    }
    public void use()
    {
        used = true;
    }
}
