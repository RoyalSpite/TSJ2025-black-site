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

    [SerializeField] private float countDownWeapon = 0;

    [SerializeField] private float carSpeed = 15f;

    [SerializeField] private float countDownPowerUp = 0;

    [SerializeField] private ItemType itemType = ItemType.None;

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
            countDownWeapon += Time.deltaTime;
            // if get weapon power up , decrease weapon cooldown from 0.75 to 0.5
            if(countDownWeapon >= (timePerShot - (itemType == ItemType.Weapon? 0.25f : 0f))){
                canShoot = true;
                countDownWeapon = 0;
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

        // fuel
        if(itemType == ItemType.Weapon){
            countDownWeapon += Time.deltaTime;
            if(countDownWeapon >= 2.5){
                itemType = ItemType.None;
                countDownWeapon = 0;
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

    private void OnCollisionEnter2D(Collision2D collider){
 
        if(collider.gameObject.CompareTag("Item")){
            itemType =  collider.gameObject.GetComponent<Item>().type;
            // collider.gameObject.GetComponent<Item>().GetPowerUp();

            if(itemType == ItemType.Fuel){
                health = Mathf.Min(30, health + 7);
                itemType = ItemType.None;
            }

            Destroy(collider.gameObject);
        }
    }
}