using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using webapi.dao;
using System.Collections;

namespace webapi.model
{
    public class EmployeeDTO
    {
        public Boolean addEmployee(Employee emp)
        {
            DBConnection dBConnection = DBConnection.getDBConnectionObj();
            MySqlConnection con = dBConnection.getConnection();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("insert into employee (`name`, `age`, `address`, `mobile`, `email`, `department`, `salary`) values('" + emp.name + "'," + emp.age + ",'" + emp.address + "','" + emp.mobile + "','" + emp.email + "','" + emp.department + "'," + emp.salary + ");", con);
                cmd.ExecuteNonQuery();
                return true;
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            
        }

        public ArrayList getAllEmployee()
        {
            DBConnection dBConnection = DBConnection.getDBConnectionObj();
            MySqlConnection con = dBConnection.getConnection();
            ArrayList empList = new ArrayList();

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from employee;", con);
                MySqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    Employee employeeData = new Employee();
                    employeeData.name = data.GetString("name");
                    employeeData.age = data.GetInt32("age");
                    employeeData.address = data.GetString("address");
                    employeeData.mobile = data.GetString("mobile");
                    employeeData.email = data.GetString("email");
                    employeeData.department = data.GetString("department");
                    employeeData.salary = data.GetDecimal("salary");
                    empList.Add(employeeData);
                }
                return empList;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public Boolean deleteEmployee(int id)
        {
            DBConnection dBConnection = DBConnection.getDBConnectionObj();
            MySqlConnection con = dBConnection.getConnection();            

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("delete from employee where id = "+id+";", con);
                int res = cmd.ExecuteNonQuery();
                if (res >= 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }

        }
        public Boolean updateEmployee(Employee emp,int id)
        {
            DBConnection dBConnection = DBConnection.getDBConnectionObj();
            MySqlConnection con = dBConnection.getConnection();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("update employee set name ='" + emp.name + "', age =" + emp.age + ",address='" + emp.address + "', mobile = '" + emp.mobile + "', email = '" + emp.email + "', department = '" + emp.department + "', salary = " + emp.salary + " where id = " + id + "", con);
                int res = cmd.ExecuteNonQuery();
                if(res >= 1)
                {
                    return true;
                }
                    return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return true;
            }
            finally
            {
                con.Close();
            }

        }
    }
}
