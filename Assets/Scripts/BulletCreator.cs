using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private GameObject buletPrefab;
    [SerializeField, Range(2f, 40f)] private float bulletVelocity = 10f;
    [SerializeField, Range(0.2f, 2f)] private float maxTime = 1f;
    [SerializeField] private Transform lookAtMe;

    private float currentTime;
    private AudioSource audioSource;

    private void Start()
    {
       currentTime = maxTime;
       audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
       CreatBullet();

    }
    private void Update()
    {
        transform.LookAt(lookAtMe);
    }
    private void CreatBullet()
    {
        currentTime -= Time.fixedDeltaTime;

        if (currentTime <= 0)
        {
            GameObject newBullet = Instantiate(buletPrefab, transform.position, transform.rotation);

            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletVelocity;

            audioSource.Play();

            Destroy(newBullet, 3);

            currentTime = maxTime;
        }
    }


    //private void FixedUpdate()
    //{
    //    StartCoroutine(Timer());
    //}

    //private IEnumerator Timer()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        yield return new WaitForSecondsRealtime(1);

    //        GameObject newBullet = Instantiate(buletPrefab, transform.position, transform.rotation);

    //        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletVelocity;
    //    }
    //}

    //private async void FixedUpdate()
    //{
    //    await CreatBulletAsync();
    //}

    //private async Task CreatBulletAsync()
    //{
    //    await Task.Delay(500);

    //    GameObject newBullet = Instantiate(buletPrefab, transform.position, transform.rotation);

    //    newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletVelocity;

    //    await Task.Delay(500);

    //    yield return new WaitForSecondsRealtime(1);
    //}
}
