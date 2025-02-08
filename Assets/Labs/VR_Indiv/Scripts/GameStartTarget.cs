using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class GameStartTarget : MonoBehaviour
{
    public UnityEvent onTargetShot;

    private Collider col;
    private AudioSource targetAudioSource;
    private Animator animator;

    [SerializeField] AudioManager AudioManager;
    [SerializeField] AudioClip gunHitClip;
    private void Awake()
    {
        targetAudioSource = GetComponent<AudioSource>();
        col = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }

    public void TargetShot()
    {
        col.enabled = false;
        onTargetShot.Invoke();
        PlayAudio();
        PlayAnimation();
    }

    public void PlayAnimation() => animator.Play("StartTargetAnim");

    public void PlayAudio() => AudioManager.PlaySFX(gunHitClip);

    public void Deactivate() => this.gameObject.SetActive(false);

}
