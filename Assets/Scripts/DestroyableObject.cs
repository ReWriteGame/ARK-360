using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DestroyableObject : MonoBehaviour
{
    [SerializeField] private Collider2D target;

    private void Start()
    {
        if (target == null)
            Debug.Log("Block target error 404");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>() == target)
            destroyThisObject();
    }


    private void destroyThisObject()
    {
        Destroy(gameObject);
    }
}
