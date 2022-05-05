/*****************************************************************************
*项目名称:AspNetCore_MVC_EFCodeFirst.Models
*项目描述:
*类 名 称:Person
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/5/5 22:01:43
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ chuanming 2022. All rights reserved
******************************************************************************/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore_MVC_EFCodeFirst.Models
{
    public abstract class Person
    {
        public int ID { get; set; }

        [Display(Name = "姓")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "名")]
        [Required]
        [StringLength(50,ErrorMessage ="用户名不超过50个字符")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }

        [Display(Name ="姓名")]
        public string FullName { get { return LastName + "·" + FirstMidName; } }
    }
}
