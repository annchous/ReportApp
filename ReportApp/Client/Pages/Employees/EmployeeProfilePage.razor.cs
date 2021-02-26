using System.Net.Http.Json;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Client.Pages.Employees
{
    public partial class EmployeeProfilePage
    {
        private EmployeeDto _employee = new EmployeeDto();

        protected override async Task OnInitializedAsync()
        {
            _employee = await Http.GetFromJsonAsync<EmployeeDto>($"api/employee/get-id/{EmployeeId}");
        }
    }
}
