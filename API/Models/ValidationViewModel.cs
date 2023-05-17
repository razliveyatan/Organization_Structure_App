using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Models
{
    public class ValidationViewModel
    {
        public bool IsValid { get; set; } = true;
        public object? RelatedDate { get; set; } = null;
        public List<string> Errors { get; set; } = new List<string>();
        
        public ValidationViewModel(ModelStateDictionary model, object? data = null) 
        {
            IsValid = model.IsValid;
            RelatedDate = data;
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
