using System;
using System.ComponentModel.DataAnnotations;

namespace ModelStudent.Models
{
    public enum Branch { IT, BE, CE, EE }
    public enum Gender { Male, Female, Other }

    public class Student
    {
        public int Id { get; set; } // Mã sinh viên

        [Required(ErrorMessage = "Họ tên bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi @gmail.com")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).+$",
            ErrorMessage = "Mật khẩu phải chứa chữ hoa, chữ thường, số và ký tự đặc biệt")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Ngành học bắt buộc phải chọn")]
        public Branch Branch { get; set; }

        [Required(ErrorMessage = "Giới tính bắt buộc phải chọn")]
        public Gender Gender { get; set; }

        public bool IsRegular { get; set; } // true: chính quy, false: phi chính quy

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ bắt buộc phải nhập")]
        public string? Address { get; set; }

        [Range(typeof(DateTime), "1/1/1963", "12/31/2005", ErrorMessage = "Ngày sinh phải trong khoảng 1963 đến 2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh bắt buộc phải nhập")]
        public DateTime DateOfBorth { get; set; }

        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0")]
        [Required(ErrorMessage = "Điểm bắt buộc phải nhập")]
        public double Score { get; set; }
    }
}
