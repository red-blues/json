using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [Header("Movement Audio")]
    [SerializeField] private AudioSource movementAudioSource;
    [SerializeField] private AudioClip stepSound;
    [SerializeField] private float stepPitch;
    [SerializeField] private AudioClip jumpSound;
    [Header("Shoot Audio")]
    [SerializeField] private AudioSource shootAudioSource;
    [SerializeField] private Vector2 shootPitchRange;
    
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    private bool _isGrounded;
    private bool _isPlayingSteps;
    
    private readonly int _speedHash =  Animator.StringToHash("Speed");
    private readonly int _jumpHash =  Animator.StringToHash("Jump");

    private const float _defaultAudioPitch = 1f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        Shoot();
    }

    #region Actions

    private void Move()
    {
        _rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rb.linearVelocity.y);
        _animator.SetFloat(_speedHash, Mathf.Abs(_rb.linearVelocity.x));

        if (_rb.linearVelocity.x != 0)
        {
            FlipPlayer();
            RotateFirePoint();
            PlayStepSound();
        }
        else
        {
            StopStepSound();
        }
    }

    private void FlipPlayer()
    {
        _spriteRenderer.flipX = _rb.linearVelocity.x < 0;
    }

    private void RotateFirePoint()
    {
        float rotationZ = _rb.linearVelocity.x > 0 ? -90 : 90;
        Vector3 rotation = firePoint.rotation.eulerAngles;
        Quaternion newRotation = Quaternion.Euler(rotation.x, rotation.y, rotationZ);
        firePoint.rotation = newRotation;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetTrigger(_jumpHash);
            PlaySound(jumpSound);
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayShootSound();
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    #endregion

    private void PlaySound(AudioClip clip)
    {
        movementAudioSource.clip = clip;
        movementAudioSource.Play();
    }

    private void LoopAudioSource(bool isLooped) => movementAudioSource.loop = isLooped;

    private void StopAudio() => movementAudioSource.Stop();

    private void SetAudioPitch(float pitch) => movementAudioSource.pitch = pitch;

    private void PlayStepSound()
    {
        if (!_isPlayingSteps && _isGrounded)
        {
            LoopAudioSource(true);
            SetAudioPitch(stepPitch);
            _isPlayingSteps = true;
            PlaySound(stepSound);
        }
    }

    private void StopStepSound()
    {
        LoopAudioSource(false);
        SetAudioPitch(_defaultAudioPitch);
        _isPlayingSteps = false;
    }

    private void PlayShootSound()
    {
        float pitch = Random.Range(shootPitchRange.x, shootPitchRange.y);
        shootAudioSource.pitch = pitch;
        shootAudioSource.Play();
    }

    #region Collisions

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (ContainsLayer(groundLayer,  other.gameObject))
            _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (ContainsLayer(groundLayer,  other.gameObject))
            _isGrounded = false;
    }

    #endregion
    
    private bool ContainsLayer(LayerMask layerMask, GameObject gameObject) => 
        (layerMask.value & 1 << gameObject.layer) > 0;
}
