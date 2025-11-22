using UnityEngine;
using UnityEngine.UI;

public class BrickPull : MonoBehaviour
{
    [Header("Settings")]
    public KeyCode interactKey = KeyCode.E;
    public float pullSpeed = 0.5f;
    public float fallbackSpeed = 0.2f;
    public float requiredProgress = 1f;

    [Header("UI")]
    public Slider progressSlider;
    public GameObject uiPanel;

    [Header("Brick Object")]
    public Transform brick;
    public Vector3 endOffset = new Vector3(2f, 0, 0);

    private float currentProgress = 0f;
    private bool playerInRange = false;
    private Vector3 startLocalPos;


    private void Start()
    {
        if (brick == null)
        {
            Debug.LogError("Brick nie przypisany!");
            return;
        }

        startLocalPos = brick.localPosition;
        progressSlider.value = 0;
        uiPanel.SetActive(false);
    }

    private void Update()
    {
       
        if (!playerInRange || ItemCounter.instance.GetCount() != 3) return;

        if (Input.GetKey(interactKey))
            currentProgress += pullSpeed * Time.deltaTime;
        else
            currentProgress -= fallbackSpeed * Time.deltaTime;

        currentProgress = Mathf.Clamp01(currentProgress);
        progressSlider.value = currentProgress;


        brick.localPosition = startLocalPos + endOffset * currentProgress;

        if (currentProgress >= requiredProgress)
            OnBrickPulledOut();
    }
    

    private void OnBrickPulledOut()
    {
        Debug.Log("Ceg³a wysuniêta!");
        uiPanel.SetActive(false);
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && ItemCounter.instance.GetCount() == 3)
        {
            playerInRange = true;
            uiPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            uiPanel.SetActive(false);
        }
    }
}
