using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Targets;
    [SerializeField] Animator doorAnimator;
    [SerializeField] Animator door2Animator;
    [SerializeField] GameObject PistolLock;

    #region Singleton
    static GameManager instance;

    public static GameManager Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
    }
    #endregion

    private void Update()
    {
        if (Targets.transform.childCount == 0)
        {
            door2Animator.SetTrigger("Open");
        }

    }

    private static float score;
    public float Score { get { return score; } }

    private bool shouldCreateHitGraphic = false;
    public bool ShouldCreateHitGraphic
    {
        get { return shouldCreateHitGraphic; }
    }

    public void PlayerScored(float targetValue)
    {
        score = score + targetValue;

        //Debug.Log(score);
    }

    public void GameStart()
    {
        //Debug.Log("<color>=greem>Game Started</color>");

        //StartGame();
        shouldCreateHitGraphic = true;
    }
}
