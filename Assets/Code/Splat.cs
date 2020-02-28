using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splat : MonoBehaviour
{
    public TextMesh nameText;
    public Animator anim;
    public AudioSource audio;
    public AudioClip audioClip;
    private SpriteRenderer spriteRenderer;
    public List<Color> splatColours = new List<Color>();
    public bool shouldSetColour = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetName(string name)
    {
        nameText.text = name;
        if (shouldSetColour)
            spriteRenderer.color = splatColours[Random.Range(0, splatColours.Count - 1)];
        anim.SetTrigger("Splat");
        audio.PlayOneShot(audioClip);
    }

    public void clear()
    {
        anim.SetTrigger("End");
    }
}
