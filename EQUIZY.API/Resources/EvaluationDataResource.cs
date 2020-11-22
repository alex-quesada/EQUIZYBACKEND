using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class EvaluationDataResource
    {
        public List<TypeEvaluationResource> TypesEvaluation { get; set; }
        public List<CategoryEvaluationResource> CategoriesEvaluation { get; set; }
        public List<TopicEvaluationResource> TopicsEvaluation { get; set; }
        public List<EvaluationResource> Evaluations { get; set; }
    }
}
