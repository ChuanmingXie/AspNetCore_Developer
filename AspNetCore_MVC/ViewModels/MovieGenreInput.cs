/*****************************************************************************
*项目名称:AspNetCore_MVC.ViewModels
*项目描述:
*类 名 称:MovieGenreInput
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/3/13 23:22:29
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ Chuanming 2022. All rights reserved
******************************************************************************/
using AspNetCore_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_MVC.ViewModels
{
    public class MovieGenreInput
    {
        public string SearchString { get; set; }

        public string MovieGenre { get; set; }

        public SelectList Genres { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
