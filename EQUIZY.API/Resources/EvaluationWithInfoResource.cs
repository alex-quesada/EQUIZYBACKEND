using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class EvaluationWithInfoResource
    {
        public EvaluationResource Evaluation { get; set; }
        public List<CategoryQuestionResource> Categories { get; set; }
        public List<TopicQuestionResource> Topics { get; set; }
        public List<TypeQuestionResource> Types { get; set; }
    }
}
