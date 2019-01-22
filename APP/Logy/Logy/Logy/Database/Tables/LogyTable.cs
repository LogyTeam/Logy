using System;
using System.Collections.Generic;
using System.Text;

namespace Logy.Database.Tables
{
    public abstract class LogyTable<T>
    {
        public abstract T CreateObject();
    }
}
