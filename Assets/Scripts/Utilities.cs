using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
namespace Utilities
{
    public static class Utilities
    {
        public static void Flip(GameObject gameObject)
        {
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }
}

