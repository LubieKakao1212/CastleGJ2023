using Coherence;
using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorityLayerChanger : MonoBehaviour
{
    [SerializeField]
    private CoherenceSync sync;

    [SerializeField]
    private int authorityLayer;
    [SerializeField]
    private int defaultLayer;

    private void Start()
    {
        if (sync.AuthorityType == AuthorityType.Full)
        {
            gameObject.layer = authorityLayer;
        }
        else
        {
            gameObject.layer = defaultLayer;
        }
    }
}
