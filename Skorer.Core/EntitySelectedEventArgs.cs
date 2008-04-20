using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{
    public delegate void EntitySelectedEventHander<T>(object o, EntitySelectedEventArgs<T> e);

    public class EntitySelectedEventArgs<T> : EventArgs
    {
        public T SelectedEntity { get; set; }
        public EntitySelectedEventArgs(T entity)
        {
            SelectedEntity = entity;
        }
    }
}
