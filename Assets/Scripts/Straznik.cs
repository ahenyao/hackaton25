using UnityEngine;
using System.Collections;

public class Straznik : MonoBehaviour
{
    public float areaLeft = 1;
    public float areaRight = 2;
    public float speed = 3f;
	private Animator anim;
    private float startX;
    private Rigidbody2D rb;
    public bool kierunekWPrawo = true;
	private bool first = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        startX = transform.position.x;
		StartCoroutine(DelayedAction());
		IEnumerator DelayedAction() {
			yield return new WaitForSeconds(6f);
			first=false;
		}
    }

    void Update()
    {
		if(!first) {
			Patrol();
		}
    }

    void Patrol()
    {
		anim.SetInteger("stan", 1);
        float posX = transform.position.x;

        if (kierunekWPrawo)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

            if (posX >= startX + areaRight)
                Flip();
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);

            if (posX <= startX - areaLeft)
                Flip();
        }
    }

    public void Flip()
    {
        kierunekWPrawo = !kierunekWPrawo;

        Vector3 s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}
