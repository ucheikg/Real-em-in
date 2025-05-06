using System.Collections;
using UnityEngine;

public class baitScript : MonoBehaviour
{
    
    [SerializeField] private GameplaySettings gameplaySettings;
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 4)
        {
            float t = UnityEngine.Random.Range(5,10);
            
            StartCoroutine(waitForFish(t));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 4)
        {

            StopAllCoroutines();
        }
    }

    IEnumerator waitForFish(float time)
    {
        yield return new WaitForSeconds(time);
        // Fish bites
        gameplaySettings.fishBitesLine();
    }

}
