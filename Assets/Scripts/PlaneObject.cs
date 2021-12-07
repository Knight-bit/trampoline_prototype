using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneObject : MonoBehaviour
{
    [Range(0, 100)]
    public int size = 0;
    [Range(0, 1)]
    public float margin = 0.0f;
    public static GameObject[,] Planes;
    public Transform planePrefab;
    public static bool loaded_platform = false;
    static Vector3 UP = new Vector3(0.0f, 0.25f, 0.0f);
    float time;
    public static int limit = 0;


    private void Start()
    {
        time = Time.time;
        Initializer();
    }

    public static Vector3 PositionPlaform(int x, int y)
    {
        return Planes[x, y].transform.position + UP;
    }
    public void Initializer()
    {
        string holderName = "GeneratedPlanes";
        if(transform.FindChild(holderName))
        {
            DestroyImmediate(transform.FindChild(holderName).gameObject);
            
        }
        Transform planeHolder = new GameObject(holderName).transform;
        planeHolder.parent = transform;
        Planes = new GameObject[size, size];
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Transform newQuad = Instantiate(planePrefab, new Vector3(y * 1, 0, x * 1), Quaternion.Euler(90, 0, 0)) as Transform;
                Planes[x, y] = newQuad.gameObject;
                newQuad.localScale -= newQuad.localScale * margin;
                newQuad.parent = planeHolder;
            }
        }
        loaded_platform = true;
    }
    
}

