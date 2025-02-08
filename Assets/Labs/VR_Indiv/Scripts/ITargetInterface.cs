using UnityEngine;

public interface ITargetInterface
{
    void TargetShot(Vector3 hitpoint);

    void PlayAnimation();

    void PlayAudio();
}