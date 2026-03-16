using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;
    [SerializeField] public AudioClip[] gruntSoundClips;

    public float jumpForce = 8f;
    public float gravity = 9.81f * 2f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
       
    }

    private void Update()
    {
        direction += gravity * Time.deltaTime * Vector3.down;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump")) {
                direction = Vector3.up * jumpForce;
                //SoundManager.instance.PlaySoundFXClip(gruntSoundClip, transform, 1f);
                SoundManager.instance.PlayRandomSoundFXClips(gruntSoundClips, transform, 1f);
            
            }

        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            SoundManager.instance.PlayRandomSoundFXClips(gruntSoundClips, transform, 1f);
            GameManager.Instance.GameOver();
        }
    }

}
