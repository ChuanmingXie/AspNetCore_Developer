/*****************************************************************************
*项目名称:AspNetCore_RazorPages_EFCodeFirst.Models
*项目描述:
*类 名 称:Enrollment
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/4/30 17:55:08
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
    public class Instructor
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "老师姓氏")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        [Display(Name= "老师名称")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name ="受雇时间")]
        public DateTime HireDate { get; set; }

        [Display(Name ="全名")]
        public string FullName
        {
            get { return LastName + "," + FirstMidName; }
        }

        public ICollection<Course> Courses { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
