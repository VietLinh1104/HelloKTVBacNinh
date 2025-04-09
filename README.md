/QuanCafe
│
├── /Forms                           → Các giao diện và code chính cho giao diện
│
├── /Models                          → Lớp Model: Định nghĩa các thực thể (là các class)
│   └── Ban.cs
│   └── SanPham.cs
│   └── HoaDon.cs
│   └── ...
│
├── /Data                            → Xử lý database, kết nối SQL
│   └── ConnectDB.cs                 → Lớp kết nối CSDL
│
├── /Repositories                    → Chứa các câu lệnh sql để getAll và insert ...
│   └── BanRepositories.cs           
│   └── SanPhamRepositories.cs
│   └── HoaDonRepositories.cs
│   └── ...
│
├── /Helpers                         → Hàm tiện ích (format tiền, validate,...)
│   └── FormatHelper.cs
│   └── ConvertHelper.cs
│
├── /Configs                         → Cấu hình ứng dụng (appsettings, chuỗi kết nối,...)
│   └── AppConfig.cs
│
├── /Tests                           → Unit test (nếu có)
│
└── QuanCafe.sln                     → Solution file
