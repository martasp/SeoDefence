using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteSwap : MonoBehaviour {

	public Image img;
	public  Sprite Sp;
	private Sprite old;
    public Text text;
    public AudioSource music;

	public void swap()
	{
		old = img.sprite;
		img.sprite = Sp;
		Sp = old;
        text.enabled = !text.enabled;
        music.mute = !music.mute;
	}
}
