using UnityEngine;
using System.Collections;
using System.Linq;

namespace Scripts
{
    public class HighlightController : MonoBehaviour
    {
        [SerializeField]
        private Material normal;
        [SerializeField]
        private Material highlight;

        public void Highlight()
        {
            ChangeRenderesMaterial(highlight);
        }

        public void Normal()
        {
            ChangeRenderesMaterial(normal);
        }

        private void ChangeRenderesMaterial(Material mat)
        {
            var renderers = GetComponentsInChildren<Renderer>().ToList();

            var renderer = GetComponent<Renderer>();
            if (renderer)
                renderers.Add(renderer);

            foreach (var r in renderers)
                r.material = mat;
        }
    }
}