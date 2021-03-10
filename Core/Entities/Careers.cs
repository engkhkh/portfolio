using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
  public  class Career : EntityBase
    {
        public string CareerName { get; set; }
        public string CareerDescription { get; set; }
        public string CareerImageUrl { get; set; }
        public string CareervedioUrl { get; set; }
    }
}
