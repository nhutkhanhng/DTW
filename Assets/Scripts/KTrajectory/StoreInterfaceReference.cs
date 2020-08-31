using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MyInterface
{
    void Do();
}


public class StoreInterfaceReference : MonoBehaviour, MyInterface
{
    public void Do()
    {
    }
}
