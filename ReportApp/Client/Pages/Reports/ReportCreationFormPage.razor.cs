using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Client.Pages.Reports
{
    public partial class ReportCreationFormPage
    {
        private TaskDto _selectedTaskDto;
        private EmployeeDto _selectedEmployeeDto;
        private ReportDto _reportDto = new ReportDto();
        private List<TaskDto> _tasks = new List<TaskDto>();
        private List<EmployeeDto> _employees = new List<EmployeeDto>();


        protected override async Task OnInitializedAsync()
        {
            // _hasSprint = await Http.GetFromJsonAsync<Boolean>("api/report/has-sprint");
            _tasks = await Http.GetFromJsonAsync<List<TaskDto>>("api/task/get-all");
            _employees = await Http.GetFromJsonAsync<List<EmployeeDto>>("api/employee/get-all");
        }

        private async Task SubmitNewReport()
        {
            _reportDto.TaskId = _selectedTaskDto.Id;
            _reportDto.EmployeeId = _selectedEmployeeDto.Id;
            await Http.PostAsJsonAsync<ReportDto>("api/report/add", _reportDto);
        }

        private void ResetReport() => _reportDto = new ReportDto();
    }
}
