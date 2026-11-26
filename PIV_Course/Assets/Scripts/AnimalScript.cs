using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    [SerializeField] Collider player;
    [SerializeField] float speed = 1f;
    [SerializeField] float moveTimer = 10f;
    float timeCounter = 0;
    [SerializeField] float maxXDistance = 5f;
    [SerializeField] float maxZDistance = 5f;
    [SerializeField, Range(0f, 20f)] float randomSoundDelay = 5f;
    float soundDelay;
    AudioSource audioSource;
    float soundTimer = 0f;
    Vector3 ray;
    Vector3 animalVector;
    bool moveAnimal = true;
    float startX;
    float startZ;
    float startY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ray = new Vector3(transform.position.x, transform.position.y+1f, transform.position.z);
        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;
        transform.position = RandomLocationInPen();
        audioSource = GetComponent<AudioSource>();
        soundDelay = Random.Range(audioSource.clip.length, randomSoundDelay + audioSource.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(ray, transform.forward*10, Color.blue);
        ray = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

        if (Physics.Raycast(ray, transform.forward*10, out hit))
        {
            if (hit.collider == player)
            {
                moveAnimal = false;
                Vector3 playerLocation = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, playerLocation, speed);
                timeCounter = 0;
            }
            else if (timeCounter >= moveTimer && hit.collider != player)
            {
                animalVector = RandomLocationInPen();
                timeCounter = 0;
                transform.LookAt(animalVector);
                moveAnimal = true;
            }
        }
        timeCounter += Time.fixedDeltaTime * Time.timeScale;
        if (moveAnimal)
        {
            transform.position = Vector3.MoveTowards(transform.position, animalVector, speed);
        }

        if (transform.position.z > startZ+maxZDistance || transform.position.y != startY)
        {
            transform.position = new Vector3(startX, startY, startZ);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        soundTimer += Time.fixedDeltaTime * Time.timeScale;
        if (soundTimer >= soundDelay)
        {
            audioSource.Play();
            soundTimer = 0;
            soundDelay = Random.Range(audioSource.clip.length, randomSoundDelay + audioSource.clip.length);
        }
    }

    Vector3 RandomLocationInPen()
    {
        float randomX = Random.Range(-maxXDistance, maxXDistance) + startX;
        float randomZ = Random.Range(-maxZDistance, maxZDistance) + startZ;
        Vector3 randomPosition = new Vector3(randomX, transform.position.y, randomZ);
        return randomPosition;
    }
}
