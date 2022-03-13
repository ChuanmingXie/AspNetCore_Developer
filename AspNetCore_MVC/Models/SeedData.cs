/*****************************************************************************
*项目名称:AspNetCore_MVC.Models
*项目描述:
*类 名 称:SeedData
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/3/13 23:47:14
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ Chuanming 2022. All rights reserved
******************************************************************************/
using AspNetCore_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_MVC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieUniversityContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MovieUniversityContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title="红与黑",
                        ReleaseDate=DateTime.Parse("2018-2-23"),
                        Genre="喜剧",
                        Price=8.99M,
                        Rating="PG-8"
                    }, new Movie
                    {
                        Title = "朝花夕拾",
                        ReleaseDate = DateTime.Parse("2008-6-03"),
                        Genre = "乡土",
                        Price = 8.99M,
                        Rating = "PG-8"
                    }, new Movie
                    {
                        Title = "孔乙己",
                        ReleaseDate = DateTime.Parse("2021-8-2"),
                        Genre = "悲剧",
                        Price = 8.99M,
                        Rating = "PG-8"
                    }, new Movie
                    {
                        Title = "繁星春水",
                        ReleaseDate = DateTime.Parse("2019-10-23"),
                        Genre = "诗歌",
                        Price = 8.99M,
                        Rating = "PG-8"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
