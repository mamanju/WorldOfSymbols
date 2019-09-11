using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFade : MonoBehaviour
{
    public void OnEnable()
    {
        StartCoroutine(StartEffect(gameObject));
    }

    public void SetEndEffect()
    {
        StartCoroutine(EndEffect(gameObject));
    }

    IEnumerator StartEffect(GameObject target)
    {
        float loopCount = 5;

        float waitSecond = 0.05f;

        float offsetScale = 1.0f / loopCount;

        float updateScale = 0;

        target.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);

        for (int loop = 0; loop < loopCount; loop++)
        {
            updateScale += offsetScale;
            waitSecond -= 0.01f;
            target.transform.localScale = new Vector3(updateScale, updateScale, updateScale);
            yield return new WaitForSeconds(waitSecond);
        }

        target.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    IEnumerator EndEffect(GameObject target)
    {
        float loopCount = 5;

        float waitSecond = 0.05f;

        float offsetScale = 1.0f / loopCount;

        float updateScale = 1;

        target.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        for (int loop = 0; loop < loopCount; loop++)
        {
            updateScale -= offsetScale;
            waitSecond -= 0.01f;
            target.transform.localScale = new Vector3(updateScale, updateScale, updateScale);
            yield return new WaitForSeconds(waitSecond);
        }

        target.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        target.SetActive(false);
    }
}
