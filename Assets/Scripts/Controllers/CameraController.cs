using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 farePosition;
    Vector2 geciciPosition;

    public float hassasiyet = 5.0f;
    public float yumusaklik = 2.0f;

    GameObject oyuncu;
    // Start is called before the first frame update
    void Start()
    {
        // kameranin bagli oldugu game obajecti yani karakterimizi atadik.
        oyuncu = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // mouse degerlerini aldik.
        Vector2 mouseDirections = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        // aldigimiz degerleri daha yumusak bir hareket saglamak icin genisletiyoruz.
        mouseDirections = Vector2.Scale(mouseDirections, new Vector2(hassasiyet * yumusaklik,hassasiyet*yumusaklik));
        geciciPosition.x = Mathf.Lerp(geciciPosition.x, mouseDirections.x, 1f / yumusaklik);
        geciciPosition.y = Mathf.Lerp(geciciPosition.y, mouseDirections.y, 1f / yumusaklik);
        farePosition += geciciPosition;

        transform.localRotation = Quaternion.AngleAxis(-farePosition.y, Vector3.right);
        oyuncu.transform.localRotation= Quaternion.AngleAxis(farePosition.x, oyuncu.transform.up);
    }
}
