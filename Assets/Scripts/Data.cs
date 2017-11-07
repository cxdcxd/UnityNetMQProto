using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace Roboland
{
    namespace Tools
    {
        namespace UnityNetwork
        {
            [Serializable]
            [ProtoContract]
            public class RVector3
            {
                [ProtoMember(1)]
                public float x = 0;
                [ProtoMember(2)]
                public float y = 0;
                [ProtoMember(3)]
                public float theta = 0;

                public RVector3(float a, float b, float c)
                {
                    x = a;
                    y = b;
                    theta = c;
                }

                public RVector3()
                {

                }
            }
        }
    }
}