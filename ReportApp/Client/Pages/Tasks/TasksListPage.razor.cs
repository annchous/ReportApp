using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Client.Pages.Tasks
{
    public partial class TasksListPage
    {
        private List<TaskDto> _tasks;
        private static String NavigateToEmployeeProfile(Int32? id) => $"/employee/profile/{id}";
        private static String NavigateToEditTaskPage(Int32 taskId) => $"/edittask/{taskId}";
        private static String NavigateToTaskChangePage(Int32 taskId) => $"/taskchanges/{taskId}";

        protected override async Task OnInitializedAsync()
        {
            _tasks = await Http.GetFromJsonAsync<List<TaskDto>>("api/task/get-all");
        }

        private async Task DeleteTask(TaskDto task)
        {
            var result = await MatDialogService.AskAsync("Are you sure you want to delete this task?", new[] { "Yes", "Cancel" });
            if (result == "Cancel") return;
            await Http.PostAsJsonAsync<TaskDto>($"api/task/delete/{task.Id}", task);
            NavigationManager.NavigateTo("/alltasks", true);
        }
    }
}
