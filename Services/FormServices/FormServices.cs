using AgentBuilderApi;
using AgentBuilderApi.Services.UserServices;
using DevPloyClasses.Dto.FormsDto;
using DevPloyClasses.Models;

namespace DevPloyApiApi.Services.FormServices
{
    public class FormServices : IFormServices
    {
        public DataContext _dataContext { get; set; }

        public FormServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<bool>> PostAdvandcedForm(AdvancedFormDto compiled_form)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                //TODO: Add Automapper
                AdvancedForm newForm = new AdvancedForm
                {
                    FullName = compiled_form.FullName,
                    EmailAddress = compiled_form.EmailAddress,
                    PhoneNumber = compiled_form.PhoneNumber,
                    LinkedInProfile = compiled_form.LinkedInProfile,
                    GitHubProfile = compiled_form.GitHubProfile,
                    Inspiration = compiled_form.Inspiration,
                    ProudProjectDescription = compiled_form.ProudProjectDescription,
                    EnjoymentDescription = compiled_form.EnjoymentDescription,
                    LearningMotivation = compiled_form.LearningMotivation,
                    MissionAdherence = compiled_form.MissionAdherence,
                    TeamExperienceDescription = compiled_form.TeamExperienceDescription,
                    PythonProficiency = compiled_form.PythonProficiency,
                    JavaProficiency = compiled_form.JavaProficiency,
                    CSharpProficiency = compiled_form.CSharpProficiency,
                    SQLProficiency = compiled_form.SQLProficiency,
                    StartDate = compiled_form.StartDate,
                    AdditionalInformation = compiled_form.AdditionalInformation
                };
            }
            catch (Exception)
            {

                throw;
            }

            return response;
            
        }
        public async Task<ServiceResponse<bool>> PostBaseForm(BaseFormDto compiled_form)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                //TODO: Add Automapper
                BaseFormModel newForm = new BaseFormModel
                {
                    Name = compiled_form.Name,
                    Email = compiled_form.Email,
                    LinkedIn = compiled_form.LinkedIn,
                    GitHub = compiled_form.GitHub,
                    SelectedProject = compiled_form.SelectedProject,
                    SkillExperience = compiled_form.SkillExperience,
                    ProgrammingLanguages = compiled_form.ProgrammingLanguages
                };
            }
            catch (Exception)
            {

                throw;
            }

            return response;
           
        }
    }
}
