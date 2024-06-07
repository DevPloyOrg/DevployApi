using DevPloyClasses.Dto.FormsDto;
using DevPloyClasses.Models;


namespace DevPloyApiApi.Services.FormServices
{
    public interface IFormServices
    {
        DataContext _dataContext { get; }

        Task<ServiceResponse<bool>> PostBaseForm(BaseFormDto compiled_form);
        Task<ServiceResponse<bool>> PostAdvandcedForm(AdvancedFormDto compiled_form);
    }
}
