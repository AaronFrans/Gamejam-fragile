using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimEventHandler : MonoBehaviour
{
    [SerializeField] private Patch _footstep;
    [SerializeField] private Patch _goblinPunch;
    [SerializeField] private AudioClip _emoteJump;
    [SerializeField] private AudioSource _footSource;
    [SerializeField] private AudioSource _headSource;


    public static bool canHit = false;

    public void GoblinFootstep()
    {
        if(_footstep == null)
        {
            return;
        }
        if (_playerMovement._isOnGround)
        {
            _footstep.Play(_footSource);
        }
    }
    public void GoblinBeginPunch()
    {
        canHit = true;
        if(_goblinPunch == null)
        {
            return;
        }

        _goblinPunch.Play(_headSource);
    }

    public void GoblinJump()
    {
        if(_emoteJump == null)
        {
            return;
        }
        _headSource.clip = _emoteJump;
        _headSource.Play();
    }

    public void GoblinYawn()
    {

    }

    public void GoblinEndPunch()
    {

        canHit = false;
    }
}
