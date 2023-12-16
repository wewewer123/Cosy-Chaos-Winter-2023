using System.Collections;
using UnityEngine;

public class Burn : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement; // Reference to Player script
    [SerializeField] float timeInterval = 2f; // Time between each ball burned

    private IEnumerator BurnTimer()
    {
        // While player has balls burn them
        while (playerMovement.PickUpList.Count > 0)
        {
            playerMovement.RemoveBall();
            yield return new WaitForSeconds(timeInterval);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")) StartCoroutine(BurnTimer());
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")) StopAllCoroutines();
    }
}
