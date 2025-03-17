using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rodScript : MonoBehaviour
{

    [SerializeField] private GameObject fishingRod;
    [SerializeField] private GameObject bait;
    [SerializeField] private Transform baitOrigin;
    [SerializeField] private GameObject powerGauge;
    private Rigidbody baitRb;
    private Animator animator;

    [SerializeField] private float charge = 0f;
    [SerializeField] private float maxCharge = 10f;
    [SerializeField] private float chargeSpeed = 10f;
    private fishingRodState charging = fishingRodState.Idle;
    public bool canCharge = true;
    public bool lockBait = true;


    // Start is called before the first frame update
    void Start()
    {
        animator = fishingRod.GetComponent<Animator>();
        baitRb = bait.GetComponent<Rigidbody>();
        powerGauge.GetComponent<Slider>().maxValue = maxCharge;
    }

    // Update is called once per frame
    void Update()
    {


        // Fishing Rod Controls
        if (Input.GetButtonDown("Fire1") && canCharge)
        {
            lockBait = true;
            charge = 0f;
            bait.transform.position = baitOrigin.position;
            charging = fishingRodState.Charging;
            animator.SetTrigger("Charge");
            canCharge = false;

        }

        if (Input.GetButtonUp("Fire1") && charging == fishingRodState.Charging)
        {
            charging = fishingRodState.Throwing;
            canCharge = true;
        }

        if(charge >= maxCharge && charging == fishingRodState.Charging)
        {
            charging = fishingRodState.Throwing;
        }

        if (charging == fishingRodState.Charging)
        {
            charge += chargeSpeed * Time.deltaTime;
            powerGauge.SetActive(true);
            powerGauge.GetComponent<Slider>().value = charge;
        }
        else
        {
            powerGauge.SetActive(false);
        }

        if (charging == fishingRodState.Throwing)
        {
            animator.SetTrigger("Throw");
            animator.ResetTrigger("Charge");
            charging = fishingRodState.Thrown;
            StartCoroutine(ThrowLine());
            
        }

        if(lockBait)
        {
            bait.transform.position = baitOrigin.position;
        }



    }

    private void ThrowBait()
    {

        lockBait = false;
        Vector3 dir = new Vector3(0, 1f * charge, 2f * charge);
        baitRb.AddForce(dir, ForceMode.Impulse);
    }

    IEnumerator ThrowLine()
    {
        yield return new WaitForSeconds(0.5f);
        animator.ResetTrigger("Throw");
        ThrowBait();
    }

    enum fishingRodState
    {
        Idle,
        Charging,
        Throwing,
        Thrown
    }
}
