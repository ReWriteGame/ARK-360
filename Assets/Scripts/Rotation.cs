using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Range(0,10)][SerializeField] private float speed = 0;


    public void rotationRight()
    {
        transform.Rotate(0, 0, speed);
    }
    public void rotationLeft()
    {
        transform.Rotate(0, 0, -speed);
    }


    public void rotationVector(Vector2 targetDirection)
    {
        float angle = Vector2.Angle(Vector2.right, targetDirection);//угол между вектором от объекта к мыше и осью х
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < targetDirection.y ? angle : -angle);//немного магии на последок
    }




    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rotationLeft();

        if (Input.GetKey(KeyCode.RightArrow))
            rotationRight();
    }
}
