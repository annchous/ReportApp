using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Client.Pages.Employees
{
    public partial class EmployeesListPage
    {
        private List<EmployeeDto> _employees;
        private static String NavigateToLeaderProfile(Int32? id) => $"/employee/profile/{id}";
        private static String NavigateToEditPage(Int32? id) => $"/editemployee/{id}";

        protected override async Task OnInitializedAsync()
        {
            _employees = await Http.GetFromJsonAsync<List<EmployeeDto>>("api/employee/get-all");
        }

        private async Task DeleteEmployee(EmployeeDto employee)
        {
            var result = await MatDialogService.AskAsync("Are you sure you want to delete this employee?", new[] { "Yes", "Cancel" });
            if (result == "Cancel") return;
            await Http.PostAsJsonAsync<EmployeeDto>($"api/employee/delete/{employee.Id}", employee);
            NavigationManager.NavigateTo("/allemployees", true);
        }
    }
}
