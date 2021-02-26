using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Client.Pages.Tasks
{
    public partial class TaskChangesHistoryPage
    {
        private List<TaskChangeDto> _taskChanges;

        protected override async Task OnInitializedAsync()
        {
            _taskChanges = await Http.GetFromJsonAsync<List<TaskChangeDto>>($"api/taskchange/get-taskId/{TaskId}");
        }
    }
}
