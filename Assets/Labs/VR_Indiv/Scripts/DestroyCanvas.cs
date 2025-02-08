using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCanvas : MonoBehaviour
{
    [SerializeField] float DestroyTime;

    private void Start() => Destroy(this.gameObject, DestroyTime);

}
