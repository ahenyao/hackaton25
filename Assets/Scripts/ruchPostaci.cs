#pragma warning disable 0618
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RuchPostaci : MonoBehaviour {
    private Rigidbody2D rbBody;
    private Animator anim;
    private BoxCollider2D col;
	
	public GameObject zad1;
	public GameObject zad2;
	public GameObject zad3;
	public GameObject zad1_help;
	public GameObject zad1_help_text;

    public float silaSkoku = 500;
    public float szybkosc = 3;
	public bool aktywna=true;

    private bool facingLeft;
    private float startX, startY, startZ;
	private RigidbodyConstraints2D c;
	private bool first = true;
	


    void Start() {
        rbBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
		c = rbBody.constraints;

        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;
		StartCoroutine(DelayedAction());
		IEnumerator DelayedAction() {
			yield return new WaitForSeconds(6f);
			first=false;
		}
    }

    void Update() {
		if (aktywna && !first) {


			float ruchPoziomy = Input.GetAxis("Horizontal");

			rbBody.velocity = new Vector2(ruchPoziomy * szybkosc, rbBody.velocity.y);

			// DOWN
			if (Input.GetKey(KeyCode.DownArrow)) {
				anim.SetInteger("stan", 3);
				rbBody.constraints = RigidbodyConstraints2D.FreezeAll;

				Vector2 s = col.size;
				s.y = 0.53f;
				col.size = s;
			} 
			else {
				rbBody.constraints = c;
				Vector2 s = col.size;
				s.y = 0.65625f;
				col.size = s;

				if (rbBody.velocity.y != 0) {
					anim.SetInteger("stan", 2);
				}

				if (ruchPoziomy == 0 && rbBody.velocity.y == 0) {
					anim.SetInteger("stan", 0);
				}

				if (ruchPoziomy != 0 && rbBody.velocity.y == 0) {
					anim.SetInteger("stan", 1);
				}

				if (Input.GetKeyDown(KeyCode.UpArrow) && rbBody.velocity.y == 0) {
					rbBody.AddForce(new Vector2(0, silaSkoku));
				}
			}

			// Flip
			if ((ruchPoziomy > 0 && facingLeft) || (ruchPoziomy < 0 && !facingLeft)) {
				FlipPlayer();
			}
		}
		if (Input.GetKeyDown(KeyCode.Tab)) {
			aktywna=!aktywna;
		}
    }

    void FlipPlayer() {
        facingLeft = !facingLeft;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Kill() {
        rbBody.velocity = Vector2.zero;
        transform.position = new Vector3(startX, startY, startZ);
    }
	
	void OnTriggerEnter2D(Collider2D col) {
		
	
		
		if (col.gameObject.name == "zad1_trigger")
			ActivateZad(zad1, col);

		if (col.gameObject.name == "zad2_trigger")
			ActivateZad(zad2, col);

		if (col.gameObject.name == "zad3_trigger")
			ActivateZad(zad3, col);

		void ActivateZad(GameObject zad, Collider2D trigger)
		{
			zad.SetActive(true);
			Time.timeScale = 0f;
			kabelki_manager.Instance.liczba = 0;
			kabelki_manager.Instance.HideIfNeeded();
			trigger.enabled = false;
		}

		
		if (col.gameObject.name == "zad1_help_trigger") {
			zad1_help_text.SetActive(true);
		}
		
		bool touchingStraznik = col.gameObject.name.StartsWith("straznik");
		if (touchingStraznik && !(anim.GetInteger("stan") == 3)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		if (col.gameObject.name == "reflektor" || col.gameObject.name == "betonowy_jez_0") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		
		if(col.gameObject.name == "border_prawo") {
			SceneManager.LoadScene("SecondScene");
		}

	}

}
