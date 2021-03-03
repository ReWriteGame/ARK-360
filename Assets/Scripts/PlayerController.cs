using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Move), typeof(Collider2D))]

public class PlayerController : MonoBehaviour
{
    private Move move;

    private IEnumerator Start()
    {
        move = GetComponent<Move>();

        //move.button += doAction;
        yield break;
    }

    void FixedUpdate()
    {

        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W)) move.upMove();
            else if (Input.GetKey(KeyCode.S)) move.downMove();

            if (Input.GetKey(KeyCode.A)) move.leftMove();
            else if (Input.GetKey(KeyCode.D)) move.rightMove();
        }
        else move.stopMove();

    }

    private void doAction()
    {
        print("action:1");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.gameObject.GetComponent<Collider2D>() != null) move.CanJump = true;
    }
}