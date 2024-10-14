using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public bool CanMove { get; set; } = true;

    [Header("Player")]
    [SerializeField] 
    private float _moveSpeed = 25f;
    [SerializeField] 
    private float _maxPosition = 7.5f;

    [Header("Audio")]
    private AudioSource _audioSource;
    [SerializeField] 
    private AudioClip _chewClip;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("AudioSource component is missing or not assigned!");
        }
    }

    private void Update()
    {
        if (CanMove)
        {
            Move();
        }
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(inputX * _moveSpeed * Time.deltaTime, 0f, 0f);
        transform.Translate(moveDirection);

        // Clamp the X position to prevent player from going beyond the boundaries
        float clampedX = Mathf.Clamp(transform.position.x, -_maxPosition, _maxPosition);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    public void PlaySFX()
    {
        _audioSource.PlayOneShot(_chewClip);
    }
}