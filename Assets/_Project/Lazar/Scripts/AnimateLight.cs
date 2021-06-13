using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimateLight : MonoBehaviour
{
    public Light[] lights;
    public AnimateLightState _state=AnimateLightState.NormalState;
    public bool isAlert;

    private void Awake()
    {
        lights = FindObjectsOfType<Light>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeLight(AnimateLightState.RedAlertState);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ChangeLight(AnimateLightState.NormalState);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeLight(AnimateLightState.GameWinState);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeLight(AnimateLightState.GameLoseState);
        }
    }
    public void StartAlert()
    {
        ChangeLight(AnimateLightState.RedAlertState);
    }
    public void StartNormal()
    {
        ChangeLight(AnimateLightState.NormalState);
    }
    public void StartWin()
    {
        ChangeLight(AnimateLightState.GameWinState);
    }
    public void StartLose()
    {
        ChangeLight(AnimateLightState.GameLoseState);
    }
    private void ChangeLight(AnimateLightState state)
    {
        var newColor = new Color();
        if(state== AnimateLightState.RedAlertState)
        {
            isAlert = true;
        }
        else if (state == AnimateLightState.NormalState)
        {
            newColor = new Color(0.87f, 0.65f, 0.64f, 1);
            isAlert = false;
        }
        else if(state==AnimateLightState.GameWinState)
        {
            newColor = new Color(0.87f, 0.98f, 0.87f, 1);
            isAlert = false;
        }
        else if(state==AnimateLightState.GameLoseState)
        {
            newColor = new Color(0.9f, 0.53f, 0.51f, 1);
            isAlert = false;
        }
        _state = state;
        foreach (var light in lights)
        {
            LerpColor(light, newColor);
            if (state == AnimateLightState.RedAlertState)
            {
                var coroutine = AlertCorutine(light);
                StartCoroutine(coroutine);
            }
        }
    }
    private IEnumerator AlertCorutine(Light light)
    {
        while(isAlert)
        {
            if (light.color == new Color(0.9f, 0.53f, 0.51f, 1))
                LerpColor(light, new Color(0.87f, 0.65f, 0.64f, 1));
            else
                LerpColor(light, new Color(0.9f, 0.53f, 0.51f, 1));
            yield return new WaitForSeconds(1f);
        }
    }
    private void LerpColor(Light light, Color newColor)
    {
        DOTween.To(() => light.color, x => light.color = x, newColor, 1f).SetEase(Ease.OutCirc);
    }

}
public enum AnimateLightState
{
    NormalState,
    RedAlertState,
    GameWinState,
    GameLoseState
}