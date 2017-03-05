using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteSwap : MonoBehaviour {

	public Image img;
	public  Sprite Sp;
	private Sprite old;
	public void swap()
	{
		old = img.sprite;
		img.sprite = Sp;
		Sp = old;
	}
}
