﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    void Move(Vector3 direction, float speed);

    void CheckBounds();
}
