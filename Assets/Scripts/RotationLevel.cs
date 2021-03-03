using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GravityLevel))]
public class RotationLevel : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;


    private Transform obj;

    private GravityLevel gravity;
    void Start()
    {
        gravity = GetComponent<GravityLevel>();
        gravity.randomGravity += rotateAsVector;
        obj = GetComponent<Transform>();
    }


    void Update()
    {
        //if(Input.GetKey(KeyCode.V)) StartCoroutine(PerformRotation2());
        /*if (Input.GetKeyDown(KeyCode.S))
        {

            if (gravity.VectorGravity != Vector2.down)// bugfix
            {
                transform.RotateAround(target.transform.position, Vector3.forward, Vector3.Angle(Vector2.down, gravity.VectorGravity) * Mathf.Sign(gravity.VectorGravity.x));
                gravity.down();
            }
        }*/

        //if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
        //   StartCoroutine(PerformRotation(transform.rotation * Quaternion.Euler(0, 0, Vector3.Angle(gravity.LastVectorGravity, gravity.VectorGravity) * Mathf.Sign(gravity.VectorGravity.x))));// умножение не коммутативно при умножении получаем положение 1го повернутое на положение 2го

        //print(Vector3.Angle(gravity.LastVectorGravity, gravity.VectorGravity) * Mathf.Sign(gravity.VectorGravity.x));
        //Mathf.SmoothStep(0, 90, Time.deltaTime * 2)

        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(PerformRotation(transform.rotation * Quaternion.Euler(0, 0, 90)));// умножение не коммутативно при умножении получаем положение 1го повернутое на положение 2го
        }*/
        //print(transform.rotation.z);//transform.rotation.z отображаеться не в градусах а в значении -1 : 1
    }
    private void rotateAsVector()
    {
        /*float angle = AngleBetweenVector2(gravity.VectorGravity, gravity.LastVectorGravity);
        angle =  Vector2.Angle(gravity.LastVectorGravity, gravity.VectorGravity);


        Vector2 angle2 = gravity.VectorGravity - Vector2.right;

      

        //if (gravity.VectorGravity == Vector2.up) angle = 90;

        // Vector3.Angle(gravity.LastVectorGravity, gravity.VectorGravity) * Mathf.Sign(gravity.VectorGravity.x);*/
        float degrees = Mathf.Atan2(gravity.VectorGravity.y, gravity.VectorGravity.x) * (180 / Mathf.PI);


        if (gravity.VectorGravity == Vector2.up) degrees = 180;
        if (gravity.VectorGravity == Vector2.down) degrees = 0;
        if (gravity.VectorGravity == Vector2.right) degrees = 90;
        if (gravity.VectorGravity == Vector2.left) degrees = -90;

        StartCoroutine(performRotationCor(Quaternion.Euler(0, 0, degrees), .3f));// умножение не коммутативно при умножении получаем положение 1го повернутое на положение 2го
        print("cor");

    }

    private IEnumerator adeCor(Quaternion targetRotation, float playTimeSeconds = 0, float delayTime = 0)
    {
        yield return new WaitForSeconds(delayTime);

        for (float timer = playTimeSeconds; timer > 0; timer -= Time.deltaTime)
        {
            float progress = 1 - (timer / playTimeSeconds);// 0 - 1
            obj.rotation = Quaternion.Lerp(obj.rotation, targetRotation, progress);
            yield return null;
        }

        yield break;
    }
    private IEnumerator performRotationCor(Quaternion targetRotation, float delayTime = 0)// есть какой-то баг если быстро использовать и если скорость < 1
    {
        //yield return new WaitForSeconds(delayTime);
        float progress = 0f;



        while (progress < 1f)
        {
            obj.rotation = Quaternion.Lerp(obj.rotation, targetRotation, progress);

            progress += (Time.deltaTime * speed);// 
            print(progress);
            yield return null;
            
        }
        yield break;
    }

}
