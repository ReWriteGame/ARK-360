using UnityEngine;


public class InputTouch : MonoBehaviour
{
    [SerializeField] private Rotation rotation;


    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);// перевод из координат экрана в координаты игры 
                rotation.rotationVector(cursorPos);
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);// перевод из координат экрана в координаты игры 
            rotation.rotationVector(cursorPos);
        }
    }
}

