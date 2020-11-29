using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class AnswerResource
    {
        public int Id { get; set; }
        public string AnswerContent { get; set; }
        public byte Correct { get; set; }
    }
}
