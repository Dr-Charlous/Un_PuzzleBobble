using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bobbles = collision.GetComponentInParent<Bobble>();

        if (bobbles != null && bobbles != GameManager.Instance.ActualBobble && bobbles != GameManager.Instance.Chara.ActualBobble)
            GameManager.Instance.KillPalyer();
    }
}
