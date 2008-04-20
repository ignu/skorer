using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{
    public class EntityUpdatedEventArgs<T> : EventArgs
    {
        public T UpdatedEntity { get; set; }
        public EntityUpdatedEventArgs(T entity)
        {
            UpdatedEntity = entity;
        }
    }
}