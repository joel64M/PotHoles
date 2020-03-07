using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace potholes
{
    public class SpawnNextScript : MonoBehaviour
    {
        #region Variables
        public tags tag;
        #endregion

        #region Builtin Methods
        private void OnBecameInvisible()
        {
            SpawnerScript.instance.SpawnNext(tag);
        }
        #endregion

        #region Custom Methods

        #endregion
    }
}