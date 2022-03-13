/*****************************************************************************
*项目名称:AspNetCore_MVC.Models
*项目描述:
*类 名 称:Movie
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/3/13 22:48:25
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ Chuanming 2022. All rights reserved
******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_MVC.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Display(Name = "影片名称")]
        [Required, StringLength(60, MinimumLength = 4)]
        public string Title { get; set; }

        [Display(Name = "上映时间"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "影片类型")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Genre { get; set; } = string.Empty;

        [Display(Name = "票价"), Range(1, 100), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "分级"), Required, StringLength(5)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s]*$")]
        public string Rating { get; set; } = string.Empty;
    }
}
