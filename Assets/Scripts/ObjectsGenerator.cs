using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour
{
    private int limit; // El limite para posicionar cada objecto
    private static int stars = 0, items_limit = 0;
    public float item_respawn = 1.0f;
    public GameObject star;
    public GameObject[] items;
    private void Start()
    {

        StartCoroutine(WaitPlatform());
    }
    static public void RestItem()
    {
        items_limit -= 1;
    }
    static public void RestStar()
    {
        items_limit -= 1;
        stars -= 1;
    }
    void GenerateItems()
    {
        if(items_limit < 4)
        {
            int random_x = Random.Range(0, PlaneObject.Planes.GetLength(0));
            int random_y = Random.Range(0, PlaneObject.Planes.GetLength(1));
            if (stars == 0)
            {
                GenerateStar(random_x, random_y);
                
            }
            else if(stars == 2)
            {
                GenerateItems(random_x, random_y);
            }else
            {
                GenerateStar(random_x, random_y);
                int random_x2 = Random.Range(0, PlaneObject.Planes.GetLength(0));
                int random_y2 = Random.Range(0, PlaneObject.Planes.GetLength(0));
                if (random_x2 == random_x && random_y == random_y2)
                    random_x2 = random_x2 == (limit - 1) ? random_x2 - 1 : random_x2 + 1;
                GenerateItems(random_x2, random_y2);
            }
            
        }
    }
    private void GenerateStar(int x, int y)
    {

        GameObject start = Object.Instantiate(star, PlaneObject.PositionPlaform(x, y), star.gameObject.transform.rotation);
        
        stars++;
        items_limit++;
    }
    private void GenerateItems(int x, int y)
    {
        int random_item = Random.Range(0, items.Length);
        GameObject item = Object.Instantiate(items[random_item], PlaneObject.PositionPlaform(x, y), items[random_item].gameObject.transform.rotation);
        
        items_limit++;
    }
    IEnumerator WaitPlatform()
    {
        yield return new WaitUntil(() => PlaneObject.loaded_platform == false);
        limit = PlaneObject.Planes.GetLength(0);
        InvokeRepeating("GenerateItems", 0.0f, item_respawn);
    }
}
