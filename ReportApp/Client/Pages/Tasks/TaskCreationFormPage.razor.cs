using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Client.Pages.Tasks
{
    public partial  class TaskCreationFormPage
    {
        private TaskDto _taskDto = new TaskDto();
        private EmployeeDto _selectedEmployeeDto;
        private List<EmployeeDto> _employees = new List<EmployeeDto>();

        protected override async Task OnInitializedAsync()
        {
            _employees = await Http.GetFromJsonAsync<List<EmployeeDto>>("api/employee/get-all");
        }

        private async Task SubmitNewTask()
        {
            _taskDto.EmployeeId = _selectedEmployeeDto.Id;
            await Http.PostAsJsonAsync<TaskDto>("api/task/add", _taskDto);
        }

        private void ResetTask() => _taskDto = new TaskDto();
    }
}
