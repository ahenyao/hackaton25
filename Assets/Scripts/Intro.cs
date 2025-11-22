using UnityEngine;
using System.Collections;

public class FreezeXExample : MonoBehaviour
{
    private Rigidbody2D graczRb;
    private Rigidbody2D straznikRb;
    public GameObject d1;
    public GameObject d2;

    void Start()
    {
        // Find the objects
        GameObject gracz = GameObject.Find("gracz_1");
        GameObject straznik = GameObject.Find("straznik1");

        // Get their Rigidbody2D
        if (gracz != null)
            graczRb = gracz.GetComponent<Rigidbody2D>();

        if (straznik != null)
            straznikRb = straznik.GetComponent<Rigidbody2D>();

        // Freeze rotation on player immediately
        if (graczRb != null)
            graczRb.constraints |= RigidbodyConstraints2D.FreezeRotation;

        // Flip the straznik
        if (straznik != null)
            straznik.GetComponent<Straznik>().Flip();

        StartCoroutine(ShowFirstDialog());
    }

    IEnumerator ShowFirstDialog()
    {
        yield return new WaitForSeconds(1f);
		
        yield return new WaitForSeconds(1f);
        d1.SetActive(true);
        yield return new WaitForSeconds(1f);
        d2.SetActive(true);
        yield return new WaitForSeconds(3f);
        d1.SetActive(false);
        d2.SetActive(false);
    }
}
