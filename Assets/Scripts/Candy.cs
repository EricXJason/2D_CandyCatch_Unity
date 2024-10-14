using UnityEngine;

public class Candy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerController>().PlaySFX();
            GameManager.Instance.IncreaseScore();
            Destroy(gameObject);
        }
        else if (collider.CompareTag("Boundary"))
        {
            GameManager.Instance.DecreaseLives();
            Destroy(gameObject);
        }
    }
}
