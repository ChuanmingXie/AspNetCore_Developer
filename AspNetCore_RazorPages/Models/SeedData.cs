/*****************************************************************************
*项目名称:AspNetCore_RazorPages.Models
*项目描述:
*类 名 称:SeedData
*类 描 述:
*创 建 人:Chuanmingxie
*创建时间:2022/3/13 11:44:59
*修 改 人:
*修改时间:
*作用描述:<FUNCTION>
*Copyright @ Chuanming 2022. All rights reserved
******************************************************************************/
using System;
using AspNetCore_RazorPages.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_RazorPages.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //提供一个上下文选项，这个选项：
            //由接口 IServiceProvider 通过GetRequiredService获得
            using (var context=new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title="傲慢与偏见",
                        ReleaseData=DateTime.Parse("2005-2-12"),
                        Genre="爱情喜剧",
                        Price=7.99M,
                        Rating= "PG-7"
                    }, new Movie
                    {
                        Title = "The Count Of Monte Cristo",
                        ReleaseData = DateTime.Parse("1961-3-13"),
                        Genre = "喜剧",
                        Price = 6.89M,
                        Rating = "PG-7"
                    }, new Movie
                    {
                        Title = "Cathédrale Notre Dame de Paris",
                        ReleaseData = DateTime.Parse("1988-2-22"),
                        Genre = "喜剧",
                        Price = 9.99M,
                        Rating = "PG-7"
                    }, new Movie
                    {
                        Title = "里约布拉沃",
                        ReleaseData = DateTime.Parse("2021-2-12"),
                        Genre = "爱情喜剧",
                        Price = 7.99M,
                        Rating = "PG-7"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
