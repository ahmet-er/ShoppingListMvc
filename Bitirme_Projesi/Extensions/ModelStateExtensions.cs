using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bitirme_Projesi.Extensions
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<string> GetErrorMessages(this ModelStateDictionary modelState)
        {
            foreach (var modelStateEntry in modelState.Values)
            {
                foreach (var error in modelStateEntry.Errors)
                {
                    yield return error.ErrorMessage;
                }
            }
        }
    }
}
