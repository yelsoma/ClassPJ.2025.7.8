using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject objPlayer;
    public float moveSpeed;

    public Animator anir;

    public KeyCode kcUp;
    public KeyCode kcDown;
    public KeyCode kcLeft;
    public KeyCode kcRight;
    public KeyCode kcAtk;

    void Start()
    {
        anir = objPlayer.transform.GetComponent<Animator>();
    }

    
    void Update()
    {
        float x = 0;
        float y = 0;
        if (Input.GetKey(kcLeft) || Input.GetKey(kcRight))
        {
            x = Input.GetAxis("Horizontal");
        }
        if (Input.GetKey(kcUp) || Input.GetKey(kcDown))
        {
            y = Input.GetAxis("Vertical");
        }
        //Debug.Log(x + ", " + y);

        /*§ðÀ»¤£²¾°Ê*/
        //Debug.Log(anir.GetCurrentAnimatorStateInfo(0).IsName("Atk"));
        //if (!anir.GetCurrentAnimatorStateInfo(0).IsName("Atk"))
        //{
        //    MoveEvent(x, y);
        //}

        MoveEvent(x, y);
        AnimationEvent(x, y);
        AttackEvent(kcAtk);
    }

    void MoveEvent(float x, float y)
    {
       
        if (x != 0 || y != 0)
        {
            if (x > 0)
            {
                objPlayer.transform.eulerAngles = new Vector3(0, 90, 0);
            }
            else if (x < 0)
            {
                objPlayer.transform.eulerAngles = new Vector3(0, 270, 0);
            }

            if (y > 0)
            {
                objPlayer.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (y < 0)
            {
                objPlayer.transform.eulerAngles = new Vector3(0, 180, 0);
            }

            if (x > 0 && y > 0)
            {
                objPlayer.transform.eulerAngles = new Vector3(0, 45, 0);
            }
            else if (x > 0 && y < 0)
            {
                objPlayer.transform.eulerAngles = new Vector3(0, 135, 0);
            }

            if (x < 0 && y > 0)
            {
                objPlayer.transform.eulerAngles = new Vector3(0, 315, 0);
            }
            else if (x < 0 && y < 0)
            {
                objPlayer.transform.eulerAngles = new Vector3(0, 225, 0);
            }

            objPlayer.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    void AnimationEvent(float x, float y)
    {
        if (x != 0 || y != 0)
        {
            anir.SetBool("Run", true);
        }
        else
        {
            anir.SetBool("Run", false);
        }
    }

    void AttackEvent(KeyCode kc)
    {
        if (Input.GetKeyDown(kc))
        {
            anir.SetTrigger("Atk");
        }
    }
}
