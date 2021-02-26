using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Client.Pages.Tasks
{
    public partial class TaskEditFormPage
    {
        private TaskDto _taskDto = new TaskDto();
        private EmployeeDto _selectedEmployeeDto;
        private TaskDto _newTaskDto = new TaskDto();
        private TaskChangeDto _taskChangeDto = new TaskChangeDto();
        private List<EmployeeDto> _employees = new List<EmployeeDto>();

        protected override async Task OnInitializedAsync()
        {
            _taskDto = await Http.GetFromJsonAsync<TaskDto>($"api/task/get-id/{TaskId}");
            _employees = await Http.GetFromJsonAsync<List<EmployeeDto>>("api/employee/get-all");
            _newTaskDto = _taskDto;
        }

        private async Task SubmitTaskChange()
        {
            _taskChangeDto.TaskId = TaskId;
            _taskDto.EmployeeId = _selectedEmployeeDto.Id == 0 ? _taskDto.Id : _selectedEmployeeDto.Id;
            await Http.PostAsJsonAsync<TaskDto>("api/task/update", _newTaskDto);
            await Http.PostAsJsonAsync<TaskChangeDto>("api/taskchange/add", _taskChangeDto);
        }

        private void ResetTaskChange()
        {
            _newTaskDto = new TaskDto();
            _taskChangeDto = new TaskChangeDto();
        }
    }
}
