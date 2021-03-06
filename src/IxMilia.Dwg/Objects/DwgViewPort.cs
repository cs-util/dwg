﻿using System;

namespace IxMilia.Dwg.Objects
{
    public partial class DwgViewPort
    {
        public DwgViewPort(string name)
            : this()
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name cannot be null.");
            }

            Name = name;
        }

        internal override DwgHandleReferenceCode ExpectedNullHandleCode => DwgHandleReferenceCode.SoftOwner;

        internal override void OnAfterObjectRead(BitReader reader, DwgObjectCache objectCache)
        {
            if (ViewPortControlHandleReference.Code != DwgHandleReferenceCode.HardPointer)
            {
                throw new DwgReadException("Incorrect view port control object parent handle code.");
            }
        }

        internal static DwgViewPort GetActiveViewPort()
        {
            return new DwgViewPort()
            {
                Name = "*ACTIVE",
            };
        }
    }
}
