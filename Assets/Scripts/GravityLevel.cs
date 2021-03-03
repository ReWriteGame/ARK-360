using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLevel : MonoBehaviour
{
    [SerializeField] private Vector2 vectorGravity = Vector2.down;
    [SerializeField] private GameObject target;

    [SerializeField] private float g = 9.81f;

    private Vector2 lastVectorGravity;

    public Vector2 LastVectorGravity { get => lastVectorGravity; }
    public Vector2 VectorGravity { get => vectorGravity; }



    public delegate void nullSign();
    public event nullSign randomGravity;
    private void Start()
    {
        //
    }



    public void up()
    {
        if (vectorGravity == Vector2.up) return;
        lastVectorGravity = vectorGravity;
        vectorGravity = Vector2.up;
        Physics2D.gravity = vectorGravity * g;
        randomGravity?.Invoke();
    }

    public void down()
    {
        if (vectorGravity == Vector2.down) return;
        lastVectorGravity = vectorGravity;
        vectorGravity = Vector2.down;
        Physics2D.gravity = vectorGravity * g;
        randomGravity?.Invoke();
    }

    public void right()
    {
        if (vectorGravity == Vector2.right) return;
        lastVectorGravity = vectorGravity;
        vectorGravity = Vector2.right;
        Physics2D.gravity = vectorGravity * g;
        randomGravity?.Invoke();
    }

    public void left()
    {
        if (vectorGravity == Vector2.left) return;
        lastVectorGravity = vectorGravity;
        vectorGravity = Vector2.left;
        Physics2D.gravity = vectorGravity * g;
        randomGravity?.Invoke();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow)) up();
        if (Input.GetKey(KeyCode.DownArrow)) down();
        if (Input.GetKey(KeyCode.LeftArrow)) left();
        if (Input.GetKey(KeyCode.RightArrow)) right();

        if (Input.GetKeyDown(KeyCode.Z)) StartCoroutine(randomGravityCor());
    }


    private IEnumerator randomGravityCor()
    {

        yield return new WaitForSeconds(Random.Range(1, 3));
        switch (Random.Range(0, 4))
        {
            case 0:
                up();
                break;
            case 1:
                down();
                break;
            case 2:
                left();
                break;
            case 3:
                right();
                break;
        }

        randomGravity?.Invoke();

    yield break;

    }




}
// наследовать функцию и дополнять ее 
// сделать массив функций 