using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanCafe.Models;
using System.Security.Cryptography;
using System.Text;
using QuanCafe.Data;

namespace QuanCafe.Repositories
{
    public class NhanVienRepository
    {
        private readonly ConnectDB db = new ConnectDB();

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public bool Register(NhanVien nv)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"INSERT INTO NhanVien (ten_nhan_vien, chuc_vu, so_dien_thoai, email, password)
                                 VALUES (@Ten, @ChucVu, @SDT, @Email, @Password)";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
                cmd.Parameters.AddWithValue("@SDT", nv.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", nv.Email);
                cmd.Parameters.AddWithValue("@Password", HashPassword(nv.Password)); // Mã hóa mật khẩu

                conn.Open();
                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi đăng ký: " + ex.Message);
                    return false;
                }
            }
        }

        public string Login(string soDienThoai, string password)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"SELECT * FROM NhanVien WHERE so_dien_thoai = @SoDienThoai AND Password = @Password";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                cmd.Parameters.AddWithValue("@Password", HashPassword(password)); // Mã hóa mật khẩu

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string ten = reader["ten_nhan_vien"].ToString();
                    return Helpers.JwtHelper.GenerateToken(ten); // Tạo token
                }
                else
                {
                    return null; // Đăng nhập thất bại
                }
            }
        }

        public NhanVien GetBySoDienThoai(string soDienThoai)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM NhanVien WHERE SoDienThoai = @SoDienThoai";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new NhanVien
                    {
                        IdNhanVien = (int)reader["IdNhanVien"],
                        TenNhanVien = reader["TenNhanVien"].ToString(),
                        ChucVu = reader["ChucVu"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString() // Lấy mật khẩu từ DB
                    };
                }
                return null;
            }
        }

        public NhanVien GetByEmail(string email)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM NhanVien WHERE Email = @Email";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new NhanVien
                    {
                        IdNhanVien = (int)reader["IdNhanVien"],
                        TenNhanVien = reader["TenNhanVien"].ToString(),
                        ChucVu = reader["ChucVu"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString() // Lấy mật khẩu từ DB
                    };
                }
                return null;
            }
        }

        public List<NhanVien> GetAll()
        {
            var list = new List<NhanVien>();
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM NhanVien";
                var cmd = new SqlCommand(query, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new NhanVien
                    {
                        IdNhanVien = (int)reader["IdNhanVien"],
                        TenNhanVien = reader["TenNhanVien"].ToString(),
                        ChucVu = reader["ChucVu"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString() // Lấy mật khẩu từ DB
                    });
                }
            }
            return list;
        }
    }
}
