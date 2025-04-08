using UnityEngine;
using System.Collections;

public class PSDestroy : MonoBehaviour {
	// Use this for initialization
	void Start () {

        StartCoroutine(returnObjectAfterDelay());
    }
    IEnumerator returnObjectAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        PoolingManager.instance.ReturnObjectToPool(this.gameObject);
    }
}
