using System;
using System.Collections;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cube:MonoBehaviour
{
    private Image _image;
    private TextMeshProUGUI _text;
    private ParticleSystem _system;

    public int Score { get; private set; }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _system = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        StartCoroutine(GrowRoutine());
    }

    public void SetStats(int score)
    {
        _image.color = CubeVariables.CubeData[score].Color;
        _text.text = CubeVariables.CubeData[score].Score.ToString();
        Score = score;
    }

    public void Die()
    {
        StartCoroutine(DieRoutine());
    }

    public void Move(Vector3 pos)
    {
        StartCoroutine(MoveRoutine(pos));
    }

    public void MoveEat(Vector3 pos)
    {
        Score *= 2;
        StartCoroutine(MoveEatRoutine(pos));
    }

    private IEnumerator MoveRoutine(Vector3 pos)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = pos;
        float t = 0;
        while (t<1)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t);
            t += Time.deltaTime * 8;
            yield return null;
        }

        transform.position = endPos;
    }

    private IEnumerator MoveEatRoutine(Vector3 pos)
    {
        yield return StartCoroutine(MoveRoutine(pos));

        SetStats(Score);

        ParticleSystem.MainModule main =_system.main;
        main.startColor = _image.color;
        _system.Play();
        
        float t = 0;

        Vector3 startScale = transform.localScale;
        Vector3 endScale = startScale * 0.8f;
        
        while (t<1)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            t += Time.deltaTime * 8;
            yield return null;
        }

        t = 0;

        while (t<1)
        {
            transform.localScale = Vector3.Lerp(endScale, startScale, t);
            t += Time.deltaTime * 8;
            yield return null;
        }

        transform.localScale = startScale;
        
    }

    private IEnumerator DieRoutine()
    {
        yield return new WaitForSeconds(0.125f);
        Destroy(gameObject);
    }

    private IEnumerator GrowRoutine()
    {
        Vector3 endScale = transform.localScale;
        Vector3 startScale = endScale / 10;

        float t = 0;
        while (t<1)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            t += Time.deltaTime * 8;
            yield return null;
        }

        transform.localScale = endScale;
    }
    
    
    
    
}