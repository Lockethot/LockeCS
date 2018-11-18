using System;

namespace Lockethot.Collections.Generic
{
    public interface ICloneableCollection : ICloneable
    {
        object BaseData();
        object BaseDataClone();
    }
}
