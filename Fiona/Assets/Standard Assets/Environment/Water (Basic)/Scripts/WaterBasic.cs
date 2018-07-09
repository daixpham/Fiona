using System;
using UnityEngine;

namespace UnityStandardAssets.Water
{
    [ExecuteInEditMode]

    public class WaterBasic : MonoBehaviour
    {
        bool mD = false;
        void Update()
        {
            Renderer r = GetComponent<Renderer>();
            if (!r)
            {
                return;
            }
            Material mat = r.sharedMaterial;
            if (!mat)
            {
                return;
            }

            Vector4 waveSpeed = mat.GetVector("WaveSpeed");
            float waveScale = mat.GetFloat("_WaveScale");
            float t = Time.time / 20.0f;

            Vector4 offset4 = waveSpeed * (t * waveScale);
            Vector4 offsetClamped = new Vector4(Mathf.Repeat(offset4.x, 1.0f), Mathf.Repeat(offset4.y, 1.0f),
                Mathf.Repeat(offset4.z, 1.0f), Mathf.Repeat(offset4.w, 1.0f));
            mat.SetVector("_WaveOffset", offsetClamped);
            if (mD)
            {
                moveDown();
            }
        }
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Player")
                mD = true;
                
        }
        private void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.tag == "Player")
                mD = false;

        }
        private void moveDown()
        {
            this.transform.position -= new Vector3(0, 0.06f, 0);
        }
    }

}