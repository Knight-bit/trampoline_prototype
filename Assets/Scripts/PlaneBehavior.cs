using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehavior : MonoBehaviour
{
    Material material;
    private bool used = false;
    private void Start()
    { 

        material = GetComponent<MeshRenderer>().material;
        //Debug.Log("Material color: " + material.color);
        //Debug.Log("Material shader: " + material.shader.name);
    }
    public void changeColor(Color color)
    {
        material.SetColor("_Color", color);
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
