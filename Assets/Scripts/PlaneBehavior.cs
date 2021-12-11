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
        bomb.gameObject.transform.position = transform.position;
        //Debug.Log("Material color: " + material.color);
        //Debug.Log("Material shader: " + material.shader.name);
    }
    public void SetDefault()
    {
        hash = player.NOONE;
        bomb.Play();
        material.SetColor("_Color", default_color);
    }
    public void BelongsTo(Color color, player hash)
    {

        this.hash = hash;
        //bomb.GetComponent<ParticleSystemRenderer>().sharedMaterial.SetColor("_Color", color);
        //this.bomb = particles;
        //bomb.transform.position = this.transform.position;
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
