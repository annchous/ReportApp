using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ReportApp.Core.DTO;

namespace ReportApp.Client.Pages.Employees
{
    public partial class EmployeeCreationFormPage
    {
        private EmployeeDto _selectedEmployeeDto;
        private EmployeeDto _employeeDto;
        private List<EmployeeDto> _employees;
        private Boolean _noLeader;
        public Boolean Disabled => _noLeader;

        protected override async Task OnInitializedAsync()
        {
            _employees = await Http.GetFromJsonAsync<List<EmployeeDto>>("api/employee/get-all");
        }

        private async Task SubmitNewEmployee()
        {
            await Http.PostAsJsonAsync<EmployeeDto>("api/employee/add", _employeeDto);
        }

        private void ResetEmployee() => _employeeDto = new EmployeeDto();
    }
}
