using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen;
    public bool isLocked;

    public void OpenClose()
    {
        if (isOpen)
        {
            this.transform.position = new Vector3(0, 5.5f, 0);
            this.transform.localScale = new Vector3(1, 10, 10);
        }
        else
        {
            this.transform.position = new Vector3(5, 5.5f, 5);
            this.transform.localScale = new Vector3(10, 10, 1);
        }
        isOpen = !isOpen;
    }

    public void LockUnlock()
    {
        isLocked = !isLocked;
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public bool IsLocked()
    {
        return isLocked;
    }
}
