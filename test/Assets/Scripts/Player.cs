using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int health = 30;
    // [SerializeField] private float chargeTimePerShot = 1f;
    [SerializeField] private float timePerShot = 0.75f;

    // [SerializeField] private const int maxShot = 10;
    [SerializeField] private float range = 5;
    [SerializeField] private GameObject point;

    [SerializeField] private bool canShoot = true;

    [SerializeField] private float countDown = 0;

    [SerializeField] private float carSpeed = 10f;

    public Vector3 target = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        // fire
        Vector3 mousePosScreen = Input.mousePosition;
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosScreen);
        mousePosWorld.z = 0;

        point.gameObject.transform.position = mousePosWorld;

        // else if(Input.GetMouseButtonUp(0)){
        //     point.SetActive(false);
        // }

        // countdown
        if(!canShoot){
            countDown += Time.deltaTime;
            if(countDown >= timePerShot){
                canShoot = true;
                countDown = 0;
            }
        }

        // move
        if(target != Vector3.zero){

            float step =  carSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, target) < 0.001f){
                // Swap the position of the cylinder.
                target = Vector3.zero;
            }

        }
        
        
    }

    public void Fire(){

        if(canShoot){
            if(Vector2.Distance(transform.position, point.transform.position) <= range){
                Debug.Log("Fire");
                canShoot = false;
            }
        }

    }
}