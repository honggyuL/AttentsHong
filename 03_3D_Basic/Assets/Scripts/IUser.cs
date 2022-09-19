using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IUser
{
    Action onObjctUse { get; set; }     // Action타입의 프로퍼티
}
