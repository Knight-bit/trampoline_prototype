using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    // Update is called once per frame
    int index_x, index_y, limit, movement_random;
    public int points = 0;
    float time_start, stun;
    float player_movement;
    Color color;
    public static bool flag = false;
    bool stay = false;
    public player hash;
    string player_name;
    TMPro.TextMeshProUGUI text;
    Quaternion rotation;
    public void Initialize(int index_x, int index_y, int limit, string name, Color color, Quaternion rotation, Variables.player hash)
    {
        this.index_x = index_x;
        this.index_y = index_y;
        this.limit = limit;
        this.color = color;
        this.player_name = name;
        this.rotation = rotation;
        this.hash = hash;
        this.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
        Debug.Log("Hash of " + player_name + " is " + hash);
        setText(hash);
    }
    private void Start()
    {
        time_start = Time.time;
        transform.Rotate(rotation.eulerAngles);
        player_movement = 0.5f;
        stun = 0.0f;
    }

    public void resetText()
    {
        text.text = player_name + ":" + points.ToString();
    }
    private void setText(player hash)
    {
        switch(hash)
        {
            case player.ONE:
                text = GameObject.FindGameObjectWithTag("Player1").GetComponent<TextMeshProUGUI>();
                text.text = player_name + ":" + points.ToString();
                break;
            case player.TWO:
                text = GameObject.FindGameObjectWithTag("Player2").GetComponent<TextMeshProUGUI>();
                text.text = player_name + ":" + points.ToString();
                break;
            case player.THREE:
                text = GameObject.FindGameObjectWithTag("Player3").GetComponent<TextMeshProUGUI>();
                text.text = player_name + ":" + points.ToString();
                break;
            case player.FOUR:
                text = GameObject.FindGameObjectWithTag("Player4").GetComponent<TextMeshProUGUI>();
                text.text = player_name + ":" + points.ToString();
                break;
        }
    }
    void FixedUpdate()
    {
        time_start += Time.deltaTime;
        movement_random = ((int)Random.Range(0, 4));
        if (time_start > player_movement + stun)
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
                        move();
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
                        move();
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
                        move();
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
                        move();

                    }
                    break;
            }
            if (stay)
            {
                //Moving();
                PlaneObject.Planes[index_x, index_y].GetComponent<PlaneBehavior>().BelongsTo( color, hash);
                PlaneObject.Planes[index_x, index_y].GetComponent<PlaneBehavior>().use();

            }
            time_start = 0.0f;
            stay = true;
        }
    }
    
    private void move()
    {
        //Reset times variables
        time_start = 0.0f;
        stun = 0.0f;
        PlaneObject.Planes[index_x, index_y].GetComponent<PlaneBehavior>().BelongsTo(color, hash);
        transform.LookAt(PlaneObject.PositionPlaform(index_x, index_y));
        transform.position = PlaneObject.PositionPlaform(index_x, index_y);
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
                flag = index_x < limit && !PlaneObject.Planes[index_x + 1, index_y].GetComponent<PlaneBehavior>().isUsed();
                if (flag)
                    index_x++;
                break;

            case movement.LEFT:
                flag = index_x != 0 && !PlaneObject.Planes[index_x - 1, index_y].GetComponent<PlaneBehavior>().isUsed();
                if (flag)
                    index_x--;
                break;

            case movement.UP:
                flag = index_y < limit && !PlaneObject.Planes[index_x, index_y + 1].GetComponent<PlaneBehavior>().isUsed();
                if (flag)
                    index_y++;
                break;

            case movement.DOWN:
                flag = index_y != 0 && !PlaneObject.Planes[index_x, index_y - 1].GetComponent<PlaneBehavior>().isUsed();
                if (flag)
                    index_y--;
                break;
        }
        if (flag)
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
   public void Buff()
   {
        StartCoroutine(BuffSpeed());
   }
    IEnumerator BuffSpeed()
    {
        float first_speed = player_movement;
        player_movement = 0.25f;
        yield return new WaitForSeconds(5);
        player_movement = first_speed;
    }
}
