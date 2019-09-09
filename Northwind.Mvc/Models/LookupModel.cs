using System.Collections.Generic;

namespace EasyLOB.Mvc
{
    public class LookupModel
    {
        public ZOperationResult OperationResult { get; }

        public ZActivityOperations ActivityOperations { get; }

        public string Text { get; }

        public string ValueId { get; }

        public bool Required { get; }

        public List<LookupModelElement> Elements { get; }

        public string Query { get; }

        public LookupModel(ZActivityOperations activityOperations, string text, string valueId,
            bool? required = null, List<LookupModelElement> elements = null, string query = null)
        {
            OperationResult = new ZOperationResult();

            ActivityOperations = activityOperations;
            Text = text ?? "";
            ValueId = valueId ?? "";
            Required = required ?? false;
            Elements = elements ?? new List<LookupModelElement>();
            Query = query ?? "";
        }
    }

    public class LookupModelElement
    {
        public string Id { get; set; }

        public string Property { get; set; }

        public LookupModelElement()
        {
        }

        public LookupModelElement(string id, string property)
        {
            Id = id;
            Property = property;
        }
    }
}