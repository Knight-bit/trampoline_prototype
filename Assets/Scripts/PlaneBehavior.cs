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
    ParticleSystem bomb;
    private void Start()
    { 

        material = GetComponent<MeshRenderer>().material;
        default_color = GetComponent<MeshRenderer>().materials[0].color;
        bomb = GetComponent<ParticleSystem>();
    }
    public void SetDefault()
    {
        Debug.Log(bomb);
        hash = player.NOONE;
        bomb.Play();
        material.SetColor("_Color", default_color);
        bomb.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", default_color);
    }
    public void BelongsTo(Color color, player hash)
    {

        this.hash = hash;
        bomb.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", color);
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
