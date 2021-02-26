using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Client.Pages.Reports
{
    public partial class ReportsListPage
    {
        private List<ReportDto> _reports;
        private List<EmployeeDto> _employees;

        protected override async Task OnInitializedAsync()
        {
            _reports = await Http.GetFromJsonAsync<List<ReportDto>>("api/report/get-all");
            _employees = await Http.GetFromJsonAsync<List<EmployeeDto>>("api/employee/get-all");
        }

        private async Task OpenTask(Int32 taskId)
        {
            var task = await Http.GetFromJsonAsync<TaskDto>($"api/task/get-id/{taskId}");
            await MatDialogService.AlertAsync(new StringBuilder()
                .Append($"[{task.Id}] ")
                .Append(task.Name)
                .ToString());
        }
    }
}
