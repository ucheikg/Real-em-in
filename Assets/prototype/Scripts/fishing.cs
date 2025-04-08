using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;
using GamesAcademy.SerialPackage;

public class fishing : MonoBehaviour
{
    InputAction miniGameControl = new InputAction("minigameControls", InputActionType.Button);
    


    [SerializeField] private GameObject minigame;
    [SerializeField] private Fish_Marker fishMarker;
    [SerializeField] private rodScript rod;
    [SerializeField] private Slider progressBar;
    [SerializeField] private Material barMaterial;
    [SerializeField] private Material progressMaterial;
    private int delay = 0;

    [SerializeField] private float progress = 50.0f;
    [SerializeField] private float gainProgressSpeed = 10f;
    [SerializeField] private float lossProgressSpeed = 10f;
    [SerializeField] private float playerSpeed = 100f;

    [SerializeField] private GameplaySettings gameplaySettings;

    [SerializeField] private bool onFish = false;

    void Start()
    {
        barMaterial.color = Color.green;
        progressMaterial.color = Color.red;

        miniGameControl.AddBinding("<Keyboard>/space", groups: "KeyboardMouse");
        miniGameControl.AddBinding("<Gamepad>/buttonSouth", groups: "Gamepad");
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = progress;


        if (onFish == true) 
        {
            progressMaterial.color = Color.green;
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
                gameplaySettings.clearFishCaught();
            }
        }
        else 
        {
            progressMaterial.color = Color.red;
            if (progress > 0)
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
                gameplaySettings.clearFishCaught();
            }
        }





        if (delay > 60)
        {
            delay++;
        }
        else
        {
            if (Input.GetButton("Fire1") || SerialComManager.instance.GetDataFromArduino("a") == "1")
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
                if (transform.localPosition.y > -149)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - (playerSpeed * Time.deltaTime), transform.localPosition.z);
                }
                else
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, -148, transform.localPosition.z);
                }

            }
        }

     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fish"))
        {
            onFish = true;
            barMaterial.color = Color.yellow;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fish"))
        {
            onFish = false;
            barMaterial.color = Color.green;
        }
    }

}
