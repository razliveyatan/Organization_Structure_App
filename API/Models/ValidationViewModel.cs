using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Models
{
    [Serializable]
    public class ValidationViewModel
    {
        public bool IsValid { get; set; } = true;
        public object? RelatedData { get; set; } = null;
        public List<string> Errors { get; set; } = new List<string>();
        
        public ValidationViewModel(ModelStateDictionary model, object? data = null) 
        {
            IsValid = model.IsValid;
            RelatedData = data;
            foreach (var modelState in model.Values)
            {
                if (modelState.Errors == null) continue;

                foreach (ModelError error in modelState.Errors)
                {
                    Errors.Add(error.ErrorMessage);
                }
            }
            
        }
    }
}
