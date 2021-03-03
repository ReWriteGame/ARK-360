using UnityEngine;
using System.Collections;// для корутин

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private float speed;
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
        rb.AddForce(direction, ForceMode2D.Impulse);
    }


    private void FixedUpdate()
    {


    }

    /*
        public float accelerationSpeed = 10;// скорость 
        [Range(0, 20)]
        public float jumpForce = 1;
        [Range(0, 5)]
        public float jumpBoost = 0;// ВО сколько раз  удлинниться прыжок (0 - зависит только от скорости )

        #region events, properties and fields
        // могу ли я прыгать
        private bool canMove = true;
        private bool canJump = false;
        // действую ли я
        private bool isMoving = false;
        private bool isJumping = false;

        //private float speed;
        private Rigidbody2D rb;

        #endregion

        public bool IsMoving { get => isMoving; }
        public bool IsJumping { get => isJumping; }
        public bool CanMove { get => canMove; set => canMove = value; }
        public bool CanJump { get => canJump; set => canJump = value; }
        public float Speed { get => speed; }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }



        public void rightMove()
        {
            speed = accelerationSpeed;
            isMoving = true;
        }
        public void leftMove()
        {
            speed = -accelerationSpeed;
            isMoving = true;
        }
        public void stopMove()
        {
            speed = 0;
            isMoving = false;
        }


        public void jump()
        {
            isJumping = true;
        }
        public void stopJump()
        {
            isJumping = false;
        }

        void moveLogic()
        {
            if (canMove)
            {
                float xVelocity, yVelocity;// параметры для вектора движения
                xVelocity = speed;
                yVelocity = rb.velocity.y;

Yarik Bard, [03.03.21 23:01]
Vector2 force = new Vector2(xVelocity, yVelocity);
                rb.AddForce(rb.mass * force);// нужно проверить нужгно ли умнажать на массу
            }
        }
        void jumpLogic()// если метод вызываеться значит прыгаем 
        {
            if (canJump && isJumping)
            {
                Vector2 force = new Vector2(rb.velocity.x * jumpBoost, jumpForce);// вектор прыжка 
                rb.AddForce(rb.mass * force, ForceMode2D.Impulse);// rb.mass убираем влияние массы на силу прыжка
            }
        }


        private void FixedUpdate()
        {
            jumpLogic();
            moveLogic();
        }*/
}
// использовать вместе с drageForce