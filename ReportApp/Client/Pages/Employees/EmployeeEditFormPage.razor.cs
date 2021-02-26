using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ReportApp.Core.DTO;
using System.Net.Http.Json;

namespace ReportApp.Client.Pages.Employees
{
    public partial class EmployeeEditFormPage
    {
        private EmployeeDto _selectedEmployeeDto;
        private EmployeeDto _employeeDto = new EmployeeDto();
        private List<EmployeeDto> _employees = new List<EmployeeDto>();

        private Boolean _noLeader;
        public Boolean Disabled => _noLeader;

        protected override async Task OnInitializedAsync()
        {
            _employeeDto = await Http.GetFromJsonAsync<EmployeeDto>($"api/employee/get-id/{EmployeeId}");
            _employees = await Http.GetFromJsonAsync<List<EmployeeDto>>("api/employee/get-all");
        }

        private async Task SubmitNewEmployee()
        {
            await Http.PostAsJsonAsync<EmployeeDto>("api/employee/add", _employeeDto);
        }

        private void ResetEmployee() => _employeeDto = new EmployeeDto();
    }
}
