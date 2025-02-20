using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fishing : MonoBehaviour
{
    [SerializeField] private float savedTargetTime;
    [SerializeField] private GameObject minigame;
    [SerializeField] private Slider progressBar;
    
    [SerializeField] private float progress = 50.0f;
    [SerializeField] private float gainProgressSpeed = 10f;
    [SerializeField] private float lossProgressSpeed = 10f;
    [SerializeField] private float playerSpeed = 100f;


    [SerializeField] private GameObject fish;
    [SerializeField] private GameObject realFish;
    [SerializeField] private Transform Respawn;

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

        

        //if (progress <= 0.0f)
        //{
        //    //transform.localPosition = new Vector3(42, 37.81873f, 0);
        //    onFish = false;
        //    targetTime = 4.0f;
        //    Debug.Log("Lost");
        //    minigame.SetActive(false);
        //    realFish.transform.position = Respawn.transform.position;
        //    realFish.SetActive(true);
        //}
        //if (progress >= 100.0f)
        //{
        //    //transform.localPosition = new Vector3(42, 37.81873f, 0);
        //    onFish = false;
        //    targetTime = 4.0f;
        //    Debug.Log("caught");
        //    minigame.SetActive(false);
        //    realFish.transform.position = Respawn.transform.position;
        //    realFish.SetActive(true);
        //}
        

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
