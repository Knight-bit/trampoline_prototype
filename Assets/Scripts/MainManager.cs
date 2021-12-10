using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;
public class MainManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public static int GivePoints(player player)
    {
        int points = 0;
        for(int x = 0; x < PlaneObject.Planes.GetLength(0); x++)
        {
            for(int y = 0; y < PlaneObject.Planes.GetLength(1); y++)
            {
                bool check = PlaneObject.Planes[x, y].GetComponent<PlaneBehavior>().Point(player);
                if(check)
                {
                    PlaneObject.Planes[x, y].GetComponent<PlaneBehavior>().SetDefault();
                    points++;
                }
            }
        }
        return points;
    }
}
