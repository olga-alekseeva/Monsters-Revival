using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstractions.Bow
{
    internal interface IBowInfo 
    {
        bool IsPreset { get; }
        IBowModel BowModel { get; }
        IBowView BowView { get; }
        void Destroyed(IBowModel model, IBowView bowView);
        void Instantiated(IBowModel model, IBowView bowView);


    }
}
