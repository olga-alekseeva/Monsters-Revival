using Abstractions.Basics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstractions.Arrow
{
    internal interface IArrowModel : IArrowModelSettings, IMoveModel, IDamage
    {
       public IArrowModelSettings ArrowModelSettings { get; }
    }
}
