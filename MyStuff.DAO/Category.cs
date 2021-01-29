using System;
using MyStuff.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStuff.DAO
{
    public class Categories
    {
        private mystuffdbContext context = new mystuffdbContext();
        public async Task<ResultModel<List<Category>>> GetCategory() {
            ResultModel<List<Category>> resultModel = new ResultModel<List<Category>>();
            try
            {
                var data = await context.Categories.ToListAsync();

                resultModel.SetSuccess("success", data);

            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Categories.GetCategory : " + ex.Message);
            }

            return resultModel;
        }

        public async Task<ResultModel<object>> Save(Category category) {
            ResultModel<object> resultModel = new ResultModel<object>();
            try
            {
                context.Entry(category).State = EntityState.Added;
                await context.SaveChangesAsync();

                resultModel.SetSuccess("success");
            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Categories.Save : " + ex.Message);
            }
            return resultModel;
        }

        public async Task<ResultModel<object>> Update(Category category)
        {
            ResultModel<object> resultModel = new ResultModel<object>();
            try
            {
                context.Entry(category).State = EntityState.Modified;
                await context.SaveChangesAsync();

                resultModel.SetSuccess("success");

            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Categories.Update : " + ex.Message);
            }
            return resultModel;
        }

        public async Task<ResultModel<object>> Delete(int id)
        {
            ResultModel<object> resultModel = new ResultModel<object>();
            try
            {
                var category = await context.Categories.FindAsync(id);
                if (category == null) {
                    resultModel.SetFailed("Not Found!");
                }

                context.Categories.Remove(category);
                await context.SaveChangesAsync();
             
                resultModel.SetSuccess("success");
            }
            catch (Exception ex)
            {
                resultModel.SetFailed("Categories.Delete: " + ex.Message);
            }
            return resultModel;
        }
    }
}
