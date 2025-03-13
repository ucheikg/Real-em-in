using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;

public class fishing : MonoBehaviour
{
    [SerializeField] private GameObject minigame;
    [SerializeField] private Fish_Marker fishMarker;
    [SerializeField] private rodScript rod;
    [SerializeField] private Slider progressBar;
    
    [SerializeField] private float progress = 50.0f;
    [SerializeField] private float gainProgressSpeed = 10f;
    [SerializeField] private float lossProgressSpeed = 10f;
    [SerializeField] private float playerSpeed = 100f;

    [SerializeField] private GameplaySettings gameplaySettings;

    [SerializeField] private bool onFish = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = progress;


        if (onFish == true) 
        {
            if (progress < 100f)
            {
                progress += gainProgressSpeed * Time.deltaTime;
            }
            else
            {
                // Caught fish
                gameplaySettings.addScoreToPlayer();
                progress = 100f;
                
                onFish = false;
                Debug.Log("caught");
                minigame.SetActive(false);
                fishMarker.canMove = false;
                rod.canCharge = true;
                rod.lockBait = true;
                progress = 50;
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
                // Lost fish
                progress = 0.0f;
                
                onFish = false;
                Debug.Log("Lost");
                minigame.SetActive(false);
                fishMarker.canMove = false;
                rod.canCharge = true;
                rod.lockBait = true;
                progress = 50;
            }
        }

        

        
        

        if (Input.GetKey(KeyCode.Space))
        {
            if (transform.localPosition.y < 146)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + (playerSpeed * Time.deltaTime), transform.localPosition.z);
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 145, transform.localPosition.z);
            }
        }
        else
        {
            if(transform.localPosition.y > -149)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - (playerSpeed * Time.deltaTime), transform.localPosition.z);
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, -148, transform.localPosition.z);
            }
            
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
