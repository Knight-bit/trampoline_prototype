using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    // Update is called once per frame
    int index_x, index_y, limit, movement_random;

    float time_start, player_movement, stun;
    
    Color color;
    
    bool stay = false;
    
    string player_name;
    
    Quaternion rotation;
    public void Initialize(int index_x, int index_y, int limit, string name, Color color, Quaternion rotation)
    {
        this.index_x        = index_x;
        this.index_y        = index_y;
        this.limit          = limit;
        this.color          = color;
        this.player_name    = name;
        this.rotation = rotation;
        this.GetComponent<MeshRenderer>().material.SetColor("_Color", color); 
    }
    private void Start()
    {
        time_start = Time.time;
        transform.Rotate(rotation.eulerAngles);
        player_movement = 0.5f;
        stun = 0.0f;


    }
    enum movement { RIGHT, LEFT, UP, DOWN}

    void FixedUpdate()
    {
        time_start += Time.deltaTime;
        movement_random = ((int)Random.Range(0, 4));
        if(time_start > player_movement + stun)
        {
            //Debug.Log("Player Movement " + movement_random);
            switch (movement_random)
            {
                case 0:
                    if (canMove(movement.RIGHT))
                    {
                        //transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                        //transform.Rotate(Vector3.up, 90.0f, Space.World);
                        //Moving();
                        move(movement.RIGHT);
                        stay = false;
                        
                    } 
                    break;
                case 1:
                    if (canMove(movement.LEFT))
                    {
                        //transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), 0);
                        //transform.rotation = Quaternion.Euler(0.0f,90.0f, 0.0f);
                        //transform.Rotate(Vector3.up, -90.0f, Space.World);
                        //Moving();
                        move(movement.LEFT);
                        stay = false;
                        
                    }
                    break;
                case 2:
                    if (canMove(movement.DOWN))
                    {
                        //transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 180.0f, 0.0f), 0);
                        //transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                        //Moving();
                        stay = false;
                        move(movement.DOWN); 
                    }
                    break;
                case 3:
                    if (canMove(movement.UP))
                    {
                        //transform.rotation = Quaternion.Euler(0.0f, .0f, 0.0f);
                        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), 0);
                        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                        //transform.Rotate(Vector3.up, 180.0f, Space.World);
                        //Moving();
                        stay = false;
                        move(movement.UP);
                        
                    }    
                    break;
            }
            if(stay)
            {
                //Moving();
                PlaneObject.Planes[index_x, index_y].GetComponent<PlaneBehavior>().changeColor(color);
                PlaneObject.Planes[index_x, index_y].GetComponent<PlaneBehavior>().use();
                
            }
            time_start = 0.0f;
            stay = true;
        }
        /*
        mensaje = "Stun equals {0} time {1}";
        string msj = string.Format(mensaje, stun, time_start);
        Debug.Log(msj);
        */

    }
    
    private void move(movement DIRECTION)
    {
        time_start = 0.0f;
        stun = 0.0f;
        switch (DIRECTION)
        {
            case movement.DOWN:
                PlaneObject.Planes[index_x, index_y].GetComponent<PlaneBehavior>().changeColor(color);
                transform.LookAt(PlaneObject.PositionPlaform(index_x, index_y));
                transform.position = PlaneObject.PositionPlaform(index_x, index_y);
                
                break;
            case movement.UP:
                PlaneObject.Planes[index_x, index_y].GetComponent<PlaneBehavior>().changeColor(color);
                transform.LookAt(PlaneObject.PositionPlaform(index_x, index_y));
                transform.position = PlaneObject.PositionPlaform(index_x, index_y);
                
                break;
            case movement.RIGHT:
                PlaneObject.Planes[index_x, index_y].GetComponent<PlaneBehavior>().changeColor(color);
                transform.LookAt(PlaneObject.PositionPlaform(index_x, index_y));
                transform.position = PlaneObject.PositionPlaform(index_x, index_y);
                
                break;
            case movement.LEFT:
                PlaneObject.Planes[index_x, index_y].GetComponent<PlaneBehavior>().changeColor(color);
                transform.LookAt(PlaneObject.PositionPlaform(index_x, index_y));
                transform.position = PlaneObject.PositionPlaform(index_x, index_y);
                break;
            default:
                Debug.Log("Error en la función move");
                break;
        }
    }
    private bool canMove(movement DIRECTION)
    {
        bool flag = false;
        //Debug.Log("Activated canMove Function");
        //string mensaje = "Flag is {0} in movement {1}, INDEX_X {2}, INDEX_Y {3} LIMIT {4}";


        //Logica para mover comprobar si puede moverse, si puede desocupar plataforma//
        int save_x = index_x; int save_y = index_y;
        switch (DIRECTION)
        {
            
            case movement.RIGHT:
                flag = index_x < limit && !PlaneObject.Planes[index_x + 1, index_y ].GetComponent<PlaneBehavior>().isUsed();
                if (flag)
                    index_x++;
                break;

            case movement.LEFT:
                flag = index_x != 0 && !PlaneObject.Planes[index_x - 1, index_y].GetComponent<PlaneBehavior>().isUsed();
                if (flag)
                    index_x--;
                break;

            case movement.UP:
                flag = index_y < limit && !PlaneObject.Planes[index_x , index_y + 1].GetComponent<PlaneBehavior>().isUsed();
                if (flag)
                    index_y++;
                break;

            case movement.DOWN:
                flag = index_y != 0 && !PlaneObject.Planes[index_x, index_y - 1].GetComponent<PlaneBehavior>().isUsed();
                if (flag)
                    index_y--;
                break;
        }
        if(flag)
        {
            PlaneObject.Planes[save_x, save_y].GetComponent<PlaneBehavior>().vacate();
            PlaneObject.Planes[index_x, index_y].GetComponent<PlaneBehavior>().use();
        }

        //Debug.Log(string.Format(mensaje, flag, DIRECTION, index_x, index_y, limit));
        return flag;
    }
    public void Moving()
    {
        string msj = "Player {0} is moving in ({1}, {2}) ";
        Debug.Log(string.Format(msj, player_name, index_x, index_y));
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with other object");
        PlaneObject.limit -= 1;
        Destroy(other.gameObject);
    }
}

/*
IEnumerator stunPlayer()
{
    while(true)
    {
        if(stun)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (canMove(movement.RIGHT))
                    move(movement.RIGHT);
                stun = false;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (canMove(movement.LEFT))
                    move(movement.LEFT);
                stun = false;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (canMove(movement.UP))
                    move(movement.UP);
                stun = false;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (canMove(movement.DOWN))
                    move(movement.DOWN);
                stun = false;
            }
        }
        if(!stun)
        {
            mensaje = "Stun equals {0} time {1}";
            string msj = string.Format(mensaje, stun, Time.deltaTime);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
}
*/