using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly float YBorder = 5f;
    private bool isUp = true;
    [SerializeField] private float speed = 11f;

    // Update is called once per frame
    void Update()
    {
        
        //Move
        Vector3 newPos = new Vector3();

        int dir = isUp? 1 : -1;
        newPos.y = dir * (Time.deltaTime * speed);

        if(Mathf.Abs(newPos.y + transform.position.y) >= YBorder){
            isUp = !isUp;
            transform.position = new Vector3(
                transform.position.x,
                dir * YBorder
            );
        }
        else transform.position += newPos;

    }

}