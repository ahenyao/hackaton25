using UnityEngine;
using UnityEngine.InputSystem;

public class Collectable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.CompareTag("Player"))
        {
            ItemCounter.instance.AddItem();
            Destroy(gameObject);
        }
    }

  
    }
