using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
public class BallMoveController : MonoBehaviour
{
    [SerializeField] private GameObject border;

    private Move move;

    [Range(0, 90)][SerializeField] private int rightAngle;
    [Range(0, -90)][SerializeField] private int leftAngle;
    [SerializeField] private LifeBar lifeBar;



    private int angle;
    private Vector2 directionMove;

    IEnumerator Start()
    {
        move = GetComponent<Move>();

        angle = Random.Range(leftAngle, rightAngle);
        directionMove = Quaternion.Euler(0, 0, 90 - angle) * Vector2.right;

        yield return new WaitForSeconds(3);
        move.impulseMove(directionMove);

        yield break;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) move.impulseMove(directionMove);
        keyboardController();


        if (move.Rigidbody2D.velocity.magnitude != move.Speed)
            move.vector2Move(move.Rigidbody2D.velocity.normalized * move.Speed);
    }





    void keyboardController()
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


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CompositeCollider2D>() == border.GetComponent<CompositeCollider2D>())
        {
            transform.position = new Vector3(0, -2);
            move.impulseMove(directionMove);
            lifeBar.removeLife();
        }
        
    }
}
