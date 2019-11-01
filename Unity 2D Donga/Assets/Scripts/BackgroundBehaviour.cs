using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameBackground;
    private SpriteRenderer gameBackgroundSpriteRenderer;
    void Start()
    {
        gameBackgroundSpriteRenderer = gameBackground.GetComponent<SpriteRenderer>(); // 초기화
        StartCoroutine(FadeOut(gameBackgroundSpriteRenderer, 0.005f)); //프레임마다 0.005씩 프레임아웃 치수형값을 넣을때 f필요

    }


    IEnumerator FadeOut(SpriteRenderer spriteRenderer, float amount)
    {
        Color color = spriteRenderer.color;
        while (color.a > 0.0f)
        {
            color.a -= amount;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(amount);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
