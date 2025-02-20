using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{

    [SerializeField] private Transform cam;
    [SerializeField] private GameObject hook;
    [SerializeField] private GameObject reticle;
    [SerializeField] private KeyCode castKey = KeyCode.Mouse0;
    [SerializeField] private float throwforce;
    [SerializeField] private float throwUpForce;
    [SerializeField] GameObject Hook;

    bool canthrow;
    bool canreturn;
    fishing Cast;

    [SerializeField] private Camera maincamera;

    public void Start()
    {
        canthrow = true;
    }

    private void Update()
    {
        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycasthit))
        {
            reticle.transform.position = raycasthit.point;

        }

        if (Input.GetKeyDown(castKey) && canthrow)
        {
            Throw();
        }

        if (Input.GetKeyDown(KeyCode.R) && canreturn)
        {
            canthrow = true;
            Destroy(Hook);
        }

    }

    void Throw()
    {
        canthrow = false;
        canreturn = true;

        Hook.transform.position = reticle.transform.position;

        //Rigidbody HookRB = Hook.GetComponent<Rigidbody>();

        //Vector3 forceToAdd = reticle.transform.forward * throwforce + transform.up * throwUpForce;

        //HookRB.AddForce(forceToAdd, ForceMode.Impulse);
    }
}
