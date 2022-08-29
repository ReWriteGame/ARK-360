using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;// установим объект слежения 

    private Transform posCam;
    private Camera cam;


    public float dumping = 1f;// плавная остановка камеры
    public Vector3 offset = new Vector2(2f, 1f);// смещение камеры относительно персонажа 
    public bool isLeft;// баг вылазит за границу камеры offset


    private int lastX;


    // Границы для камеры 
    [SerializeField]
    public float leftBorder;
    [SerializeField]
    public float rightBorder;
    [SerializeField]
    public float upperBorder;
    [SerializeField]
    public float bottomBorder;
    




    void Start()
    {
        posCam = GetComponent<Transform>();
        cam = GetComponent<Camera>();

        if (cam == null)// debug проверка 
        {
            Debug.Log("камера не найдена");
            return;
        }

        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        lastX = Mathf.RoundToInt(player.position.x);
        transform.position = shiftCamera(isLeft);
    }

    private Vector3 shiftCamera(bool playerIsLeft)
    {
        Vector3 target;
        
        if (isLeft) target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, posCam.position.z);
        else        target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, posCam.position.z);

        return target;
    }

    void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) isLeft = false;
            else if (currentX < lastX) isLeft = true;

            Vector3 target = shiftCamera(isLeft);

            Vector3 currentPosition = Vector3.Lerp(posCam.position, target, dumping * Time.deltaTime);
            posCam.position = currentPosition;
            //posCam.Translate(currentPosition);
            lastX = currentX;// запоминаем последнюю сторону игрока (прав/лев)
        }

        //Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);


        // Граници для камеры
        transform.position = new Vector3
        (   // Mathf - метем вычисление Clamp - работа в определенном диапазоне (кущая пoзиция, 1й лимит,2й лимит)
        Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
        Mathf.Clamp(transform.position.y, bottomBorder, upperBorder),
        transform.position.z// z оставляем неизменной игра 2D ))
        );
    }


    // Отрисовка видимой зоны для движения камеры
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;// все линии будут красные
        // Gizmos.DrawLine(xy первой точки, xy второй точки) - рисует линию от точки к точке
        Gizmos.DrawLine(new Vector2(leftBorder, upperBorder), new Vector2(rightBorder, upperBorder));// верх
        Gizmos.DrawLine(new Vector2(leftBorder, bottomBorder), new Vector2(rightBorder, bottomBorder));// низ 
        Gizmos.DrawLine(new Vector2(rightBorder, upperBorder), new Vector2(rightBorder, bottomBorder));// право
        Gizmos.DrawLine(new Vector2(leftBorder, upperBorder), new Vector2(leftBorder, bottomBorder));// лево
    }
}


