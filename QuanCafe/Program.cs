using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanCafe.Forms;
using QuanCafe.Helpers;
using QuanCafe.Models;
using QuanCafe.Repositories;

namespace QuanCafe
{


    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

            //string token = Session.JwtToken;
            //Console.WriteLine($"Expires at: {token}");

            //var (username, role, expiration) = JwtHelper.DecodeToken(token);
            //Console.WriteLine($"Username: {username}");
            //Console.WriteLine($"Role: {role}");
            //Console.WriteLine($"Expires at: {expiration}");

        }
    }
}
