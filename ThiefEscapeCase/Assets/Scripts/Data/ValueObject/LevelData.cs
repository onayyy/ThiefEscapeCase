using System;
using System.Collections.Generic;

namespace Data.ValueObject
{
    [Serializable]
    public class LevelData
    {
        public List<ThiefData> ThiefData = new List<ThiefData>();
    }
}