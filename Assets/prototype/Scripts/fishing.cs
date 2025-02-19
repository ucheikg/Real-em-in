using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fishing : MonoBehaviour
{

    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool atTop;
    [SerializeField] private float targetTime = 4.0f;
    [SerializeField] private float savedTargetTime;
    [SerializeField] private GameObject minigame;
    [SerializeField] private Slider progressBar;
    
    [SerializeField] private float progress = 50.0f;
    [SerializeField] private float gainProgressSpeed = 10f;
    [SerializeField] private float lossProgressSpeed = 10f;


    [SerializeField] private GameObject fish;
    [SerializeField] private GameObject realFish;
    [SerializeField] private Transform Respawn;

    [SerializeField] private bool onFish;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onFish == true) 
        {
            if (progress < 0f)
            {
                progress += gainProgressSpeed * Time.deltaTime;
            }
            else
            {
                progress = 100f;
            }
        }
        else 
        {
            if(progress > 0)
            {
                progress -= lossProgressSpeed * Time.deltaTime;
            }
            else
            {
                progress = 0.0f;
            }
        }

        progressBar.value = progress;

        if (targetTime <= 0.0f)
        {
            transform.localPosition = new Vector3(42, 37.81873f, 0);
            onFish = false;
            targetTime = 4.0f;
            Debug.Log("Lost");
            minigame.SetActive(false);
            realFish.transform.position = Respawn.transform.position;
            realFish.SetActive(true);
        }
        if (targetTime >= 8.0f)
        {
            transform.localPosition = new Vector3(42, 37.81873f, 0);
            onFish = false;
            targetTime = 4.0f;
            Debug.Log("caught");
            minigame.SetActive(false);
            realFish.transform.position = Respawn.transform.position;
            realFish.SetActive(true);
        }
        

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fish"))
        {
            onFish = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fish"))
        {
            onFish = false;
        }
    }

}
