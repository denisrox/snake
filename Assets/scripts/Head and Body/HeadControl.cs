using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //сейчас использую для вывода промежуточный инфы, чтобы дебажить. К релизу в этом классе не должно быть этого

public class HeadControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float beginMovementSpeed;
    public float movementSpeed;
    public float rotationSpeed;
    public KeyCode left;
    public KeyCode right;
    public KeyCode boostSpeed;
    private GameManager manager;
    private OnEatFood onEatFood;
    public Queue<Vector3> pointsTrajectory=new Queue<Vector3>();
    public List<GameObject> buffs = new List<GameObject>();//вроде не нужно)
    public float  stamina;
    public float staminaCurrent;
    public float powerBoost;
    public Text textTest;
    private bool testCurrent = false;
    private bool testPrevious = false;
    //удалить, ибо эта хрень вообще не нужна.

    //Крч, для нового движения
    //public Vector3 previousMotionVector;
    //public Vector3[] ArrayPointsTrajectory;
    //public int cointPoints = 0;
    void Start()
    {
        //ArrayPointsTrajectory = new Vector3[10000];
        //previousMotionVector = transform.forward;
        staminaCurrent =stamina;
        movementSpeed = beginMovementSpeed;
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        onEatFood = gameObject.GetComponent<OnEatFood>();
    }

    // Update is called once per frame
    void Update()
    {
        textTest.text = ""+movementSpeed;

        Vector3 moveDirection = transform.TransformDirection(Vector3.forward + Vector3.down) * movementSpeed * Time.deltaTime;
        GetComponent<CharacterController>().Move(moveDirection);

        //transform.Translate(Vector3.forward * Time.deltaTime*movementSpeed); //движение вперед. Т.к. змея двигается всегда вперед - то будет выполняться каждый кадр.
        //GetComponent<CharacterController>().velocity.sqrMagnitude; скорось в квадрате

        if (Input.GetKey(left))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);// * movementSpeed);//поворот налево
        }
        if(Input.GetKey(right))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);// * movementSpeed);//поворот направо
        }
        if (Input.GetKeyDown(boostSpeed))
        {
            BoostSpeedByShift comp= gameObject.AddComponent<BoostSpeedByShift>();
            comp.powerBoost = powerBoost;
        }
        if (Input.GetKeyUp(boostSpeed))
        {
            if (GetComponent<BoostSpeedByShift>())
                GetComponent<BoostSpeedByShift>().deleteBuff();
        }
        //управление для телефона
        if (Input.touchCount > 0)
        {
            //text.text = "касаний: " + Input.touchCount;
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                    transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
                else
                    transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

                testCurrent = false;
            }
            else
            {
                testCurrent = true;
                
            }
            
        }

        if (testCurrent!=testPrevious)
        {
            if (testCurrent)
            {
                BoostSpeedByShift comp = gameObject.AddComponent<BoostSpeedByShift>();
                comp.powerBoost = powerBoost;
            }
            else
            {
                if (GetComponent<BoostSpeedByShift>())
                    GetComponent<BoostSpeedByShift>().deleteBuff();
            }

        }
        testPrevious = testCurrent;

    }
    public void turnHead(int directionToTurn)
    {
        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime* directionToTurn);
    }


}
