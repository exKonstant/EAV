using System;
using System.Collections.Generic;
using System.Text;
using EAV.DAL.EntityAttributeValue.Base;

namespace EAV.DAL.EntityAttributeValue
{
    public class Value : BaseEntity
    {
        public Entity Entity { get; set; }
        public int EntityId { get; set; }
        public Attributes Attribute { get; set; }
        public int AttributeId { get; set; }
    }
}
