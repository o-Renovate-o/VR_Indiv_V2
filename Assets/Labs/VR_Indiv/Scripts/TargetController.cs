using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class TargetController : MonoBehaviour, ITargetInterface
{
    [SerializeField] float targetScoreValue;
    [SerializeField] AudioManager AudioManager;
    [SerializeField] AudioClip gunHitClip;

    [Header("Score Components")]
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] float canvasYOffset = 0.15f;
    private TextMeshProUGUI scoreText;

    [SerializeField] GameObject gameStart;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void TargetShot(Vector3 hitpoint)
    {
        var accuracy = CalculateAccuracy(hitpoint);
        var score = 100f * accuracy;

        Debug.Log($"Accuracy: <color=green>{accuracy}</color> | Score: <color=blue>{score}</color>");
        GameManager.Instance.PlayerScored(score);

        PlayAudio();
        PlayAnimation();
        Destroy(gameObject);


        GameManager.Instance.PlayerScored(targetScoreValue);

        // display score canvas
        Vector3 canvasPosition = new Vector3(transform.position.x, transform.position.y + canvasYOffset, transform.position.z);
        var createdCanvas = Instantiate(scoreCanvas, canvasPosition, Quaternion.identity);
        createdCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+" + score.ToString("0");
    }

    private float CalculateAccuracy(Vector3 hitpoint)
    {
        var maxdistance = .5f;

        var distanceFromTarget = Vector3.Distance(transform.position, hitpoint);

        var percenttagAccuracy = (distanceFromTarget / maxdistance * 100f);

        var percentInversion = 100f - percenttagAccuracy;

        return percentInversion;
    }

    public void PlayAnimation()
    {

    }

    public void PlayAudio() => AudioManager.PlaySFX(gunHitClip);
}
