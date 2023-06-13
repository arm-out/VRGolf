using UnityEngine;

public class SetArmSwing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (ChangeScene.armSwing == true)
        {
            GetComponent<SwingingArmMotion>().enabled = true;
        }
        else
        {
            GetComponent<SwingingArmMotion>().enabled = false;
        }
    }


}
