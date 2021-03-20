using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private GameObject picture;
    [SerializeField] private int numberOfLife;// current num of lifes


    private GameObject[] array;

    public int NumberOfLife { get => numberOfLife; private set => numberOfLife = value; }

    void Start()
    {
        array = new GameObject[numberOfLife];
        for (int i = 0; i < array.Length; i++)// max num of lifes
            array[i] = Instantiate(picture, transform.position + Vector3.right * i * 0.3f, transform.rotation);// сделать дочерними?
    }



    public void addLife()
    {
        if (numberOfLife >= array.Length) return;

        array[numberOfLife] = Instantiate(picture, transform.position + Vector3.right * numberOfLife * 0.3f, transform.rotation);
        numberOfLife++;
    }

    public void removeLife()
    {
        if (numberOfLife <= 0) return;

        Destroy(array[--numberOfLife]);
    } 
}
