using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Teams:IEntity
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}
