/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.Models
*项目描述:
*类 名 称:Student
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/4/28 17:10:44
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_RazorPages_EFCodeFirst.Models
{
    public class Student
    {
        [Display(Name ="学生证号")]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "昵称")]
        public string NickName { get; set; }

        [Required]
        [StringLength(50,ErrorMessage ="用户名不应超过50个字符")]
        [Display(Name ="用户名")]
        [Column("UserName")]
        public string FirstMidName { get; set; }

        [Display(Name ="姓")]
        public string LastName { get; set; }

        [Display(Name ="籍贯")]
        [Column("NativePlace")]
        public string NativePlace { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name ="报名时间")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name="全名")]
        public string FullName {

            get { return LastName + "," + FirstMidName; }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
