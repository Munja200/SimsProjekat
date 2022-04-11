using System;

namespace Model
{
   public class WorkingTime
   {
        public bool startTime;
        public bool endTime;
        public int duration;

        public System.Collections.Generic.List<Employee> employee;

        public System.Collections.Generic.List<Employee> Employee
        {
            get
            {
                if (employee == null)
                    employee = new System.Collections.Generic.List<Employee>();
                return employee;
            }
            set
            {
                RemoveAllEmployee();
                if (value != null)
                {
                    foreach (Employee oEmployee in value)
                        AddEmployee(oEmployee);
                }
            }
        }


        public void AddEmployee(Employee newEmployee)
        {
            if (newEmployee == null)
                return;
            if (this.employee == null)
                this.employee = new System.Collections.Generic.List<Employee>();
            if (!this.employee.Contains(newEmployee))
            {
                this.employee.Add(newEmployee);
                newEmployee.WorkingTime = this;
            }
        }


        public void RemoveEmployee(Employee oldEmployee)
        {
            if (oldEmployee == null)
                return;
            if (this.employee != null)
                if (this.employee.Contains(oldEmployee))
                {
                    this.employee.Add(oldEmployee);
                    oldEmployee.WorkingTime = this;
                }
        }


        public void RemoveAllEmployee()
        {
            if (employee != null)
            {
                System.Collections.ArrayList tmpEmployee = new System.Collections.ArrayList();
                foreach (Employee oldEmployee in employee)
                    tmpEmployee.Add(oldEmployee);
                employee.Clear();
                foreach (Employee oldEmployee in tmpEmployee)
                    oldEmployee.WorkingTime = null;
                tmpEmployee.Clear();
            }
        }

    }
}