using System.Collections;
using UnityEngine;

public class IDialogueCallBack : MonoBehaviour
{

    public void Run(int callbackNumber)
    {
        switch (callbackNumber)
        {
            case 0:
                StartCoroutine("CallBack_1");
                break;
            case 1:
                StartCoroutine("CallBack_2");
                break;
            case 2:
                StartCoroutine("CallBack_3");
                break;
            case 3:
                StartCoroutine("CallBack_4");
                break;
            default:

                break;
        }
    }

    public virtual IEnumerator CallBack_1()
    {
        Debug.Log("CallBack_1 Called");
        yield return new  WaitForSeconds(0.01f);
    }
    public virtual IEnumerator CallBack_2()
    {
        Debug.Log("CallBack_2 Called");
        yield return new WaitForSeconds(0.01f);

    }
    public virtual IEnumerator CallBack_3()
    {
        Debug.Log("CallBack_3 Called");
        yield return new WaitForSeconds(0.01f);

    }
    public virtual IEnumerator CallBack_4()
    {
        Debug.Log("CallBack_4 Called");
        yield return new WaitForSeconds(0.01f);

    }

}
