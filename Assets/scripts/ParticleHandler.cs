using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    public GameObject ParticleToUse;

    public GameObject Parti1;
    public GameObject Parti2;
    public GameObject Parti3;

    public float particlesize;

    public amel Target;

    // Start is called before the first frame update
    void Start()
    {
        Target = FindObjectOfType<amel>();

        Parti1 = Instantiate(ParticleToUse);
        Parti2 = Instantiate(ParticleToUse);
        Parti3 = Instantiate(ParticleToUse);

        Parti1.transform.position = this.transform.position;
        Parti2.transform.position = this.transform.position;
        Parti3.transform.position = this.transform.position;

        Parti1.transform.up = Target.transform.position - Parti1.transform.position;
        Parti2.transform.up = Target.transform.position - Parti2.transform.position;
        Parti3.transform.up = Target.transform.position - Parti3.transform.position;

        Parti1.transform.rotation *= Quaternion.Euler(0, 0, Random.Range(-35f, 35f));
        Parti2.transform.rotation *= Quaternion.Euler(0, 0, Random.Range(-35f, 35f));
        Parti3.transform.rotation *= Quaternion.Euler(0, 0, Random.Range(-35f, 35f));

        particlesize = Parti1.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float paritculeredux = 0.2f * Time.deltaTime;

        Parti1.transform.position -= Parti1.transform.up * Time.deltaTime *8;
        Parti2.transform.position -= Parti2.transform.up * Time.deltaTime *8;
        Parti3.transform.position -= Parti3.transform.up * Time.deltaTime *8;

        Parti1.transform.localScale -= new Vector3(paritculeredux, paritculeredux, paritculeredux);
        Parti2.transform.localScale -= new Vector3(paritculeredux, paritculeredux, paritculeredux);
        Parti3.transform.localScale -= new Vector3(paritculeredux, paritculeredux, paritculeredux);

        particlesize = Parti1.transform.localScale.x;

        if (particlesize <= 0)
        {
            Destroy(Parti1);
            Destroy(Parti2);
            Destroy(Parti3);

            Destroy(gameObject);
        }
    }
}
