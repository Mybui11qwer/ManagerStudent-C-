INSERT INTO SINHVIEN (MaSV, HoTen, GioiTinh, DiaChi, NienKhoa, CMND, SoDienThoai, Email, NgaySinh, MatKhau, MaKhoa, MaKH, ID_Status)
VALUES 
('22DH000001', N'Nguyễn Văn A', 1, N'Hà Nội', '2022-2026', '123456789012', '0912345678', 'nguyenvana@gmail.com', '2001-01-01', 'password', 'CNTT', 1, 1),
('22DH000002', N'Trần Thị B', 0, N'TP.HCM', '2022-2026', '123456789013', '0912345679', 'tranthib@gmail.com', '2002-02-02', 'password', 'NNA', 1, 1),
('22DH000003', N'Lê Văn C', 1, N'Đà Nẵng', '2022-2026', '123456789014', '0912345680', 'levanc@gmail.com', '2003-03-03', 'password', 'CNTT', 1, 1),
('22DH000004', N'Phạm Thị D', 0, N'Cần Thơ', '2022-2026', '123456789015', '0912345681', 'phamthid@gmail.com', '2004-04-04', 'password', 'TCM', 1, 1),
('22DH000005', N'Hoàng Văn E', 1, N'Hải Phòng', '2022-2026', '123456789016', '0912345682', 'hoangvane@gmail.com', '2001-05-05', 'password', 'DPH', 1, 1);

INSERT INTO KHOA (MaKhoa, TenKhoa)
VALUES 
('TMDT', N'Thương mại điện tử'),
('QTKD', N'Quản trị kinh doanh'),
('NNA', N'Ngôn ngữ Anh'),
('TCM', N'Tài chính Marketing'),
('DPH', N'Đông phương học');