﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Entry_controller : MonoBehaviour
    {
        public abstract void Open();
        public abstract void Close();
    }
}
