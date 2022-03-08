using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FOS.Data.Authentication
{
    public class WindowsAuthentication
    {
        #region DllImportLogOnUser
        [DllImport("advapi32.dll")]
        public static extern bool LogonUser(string username, string domain, string password, int logType, int logpv, ref IntPtr intPtr);
        #endregion

        public Customer CustomerRequest { get; set; }

        public WindowsAuthentication(Customer customerRequest)
        {
            CustomerRequest = customerRequest;
        }        

        public bool Authenticate()
        {
            try
            {
                bool isAuthenticated = false;


                IntPtr ip = IntPtr.Zero;

                isAuthenticated = LogonUser(CustomerRequest.Username, CustomerRequest.Domain, CustomerRequest.Password, 2, 0, ref ip);

                return isAuthenticated;
            }
            catch
            {
                throw;
            }
        }
    }
}