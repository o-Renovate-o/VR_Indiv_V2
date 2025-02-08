using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameStartUIController : MonoBehaviour
{
    private Animator animator;
    private Canvas canvasStartText;

    [SerializeField] AudioManager AudioManager;
    [SerializeField] AudioClip gunHitClip;
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI gameStartText;

    public void TargetHit()
    {
        gameStartText.text = "Get Ready!";
        PlayAudio();
        StartCoroutine("GameStartDelay");
    }

    IEnumerator GameStartDelay()
    {
        canvasStartText = gameStartText.canvas;

        yield return new WaitForSeconds(1);
        gameStartText.text = "3";
        yield return new WaitForSeconds(1);
        gameStartText.text = "2";
        yield return new WaitForSeconds(1);
        gameStartText.text = "1";
        yield return new WaitForSeconds(1);
        gameStartText.text = "GO!";
        yield return new WaitForSeconds(1);

        GameObject.FindGameObjectWithTag("Player").GetComponent<XR_Stopwatch>().StartTimer();
        Destroy(gameObject);
        Destroy(panel);
        StartGame();
    }
    void StartGame()
    {
        GameManager.Instance.GameStart();
        this.gameObject.SetActive(false);
    }

    public void PlayAnimation() => animator.Play("StartTargetAnim");

    public void PlayAudio() => AudioManager.PlaySFX(gunHitClip);

    public void Deactivate() => this.gameObject.SetActive(false);
}
