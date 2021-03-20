using UnityEngine;
using System.Collections;// для корутин

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private float speed;// мин макс
    [Range(0, 10)] [SerializeField] private float impulseForce;


    // pattern: observer
    public delegate void ButtonDown();
    public event ButtonDown button;


    private Vector2 direction = Vector2.zero;
    private Rigidbody2D rb;

    #region events, properties and fields
    // могу ли я прыгать
    private bool canMove = true;
    private bool canJump = false;
    // действую ли я
    private bool isMoving = false;
    private bool isJumping = false;


    #endregion

    public bool IsMoving { get => isMoving; }
    public bool IsJumping { get => isJumping; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public bool CanJump { get => canJump; set => canJump = value; }
    public float Speed { get => speed; private set => speed = value; }
    public Rigidbody2D Rigidbody2D { get => rb; private set => rb = value; }// возможно получить доступ к другим компонентам ?

    private IEnumerator Start()
    {
        rb = GetComponent<Rigidbody2D>();

        yield break;
    }
    public void rightMove()
    {
        direction += Vector2.right;
        rb.AddForce(rb.mass * direction.normalized * speed);
        button?.Invoke();
    }
    public void leftMove()
    {
        direction += Vector2.left;
        rb.AddForce(rb.mass * direction.normalized * speed);
        button?.Invoke();
    }
    public void upMove()
    {
        direction += Vector2.up;
        rb.AddForce(rb.mass * direction.normalized * speed);
        button?.Invoke();
    }
    public void downMove()
    {
        direction += Vector2.down;
        rb.AddForce(rb.mass * direction.normalized * speed);
        button?.Invoke();
    }
    public void stopMove()
    {
        direction = Vector2.zero;
        rb.AddForce(rb.mass * direction * speed);
    }




    public void impulseMove(Vector2 direction)
    {
        rb.AddForce(direction.normalized * impulseForce, ForceMode2D.Impulse);
    }


   
}
